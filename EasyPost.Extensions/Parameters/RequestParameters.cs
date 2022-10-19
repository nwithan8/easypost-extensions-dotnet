using System;
using System.Collections.Generic;
using System.Linq;
using EasyPost.Extensions.Attributes;
using EasyPost.Extensions.Exceptions;

namespace EasyPost.Extensions.Parameters;

internal interface IRequestParameters
{
}

/// <summary>
///     Class for parameters for EasyPost API calls.
/// </summary>
public abstract class RequestParameters : IRequestParameters
{
    /*
     * NOTES:
     * Per https://www.informit.com/articles/article.aspx?p=1997935&seqNum=5 and https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/default-values,
     * Any nullable object (non-primitive) will default to `null`
     * Any nullable primitive will default to `null`
     * No need to set a default value for Optional parameters, will be `null` if not set, which is what the internal validator expects
     */

    private Dictionary<string, object?> _parameterDictionary;

    /// <summary>
    ///     Create a new set of request parameters.
    /// </summary>
    /// <param name="overrideParameters">Use a dictionary of parameters as a base for these parameters, optional.
    /// Parameters in this dictionary take precedence over explicitly-defined parameters.</param>
    protected RequestParameters(Dictionary<string, object>? overrideParameters = null)
    {
        _parameterDictionary = overrideParameters != null ? overrideParameters.ToStringNullableObjectDictionary() : new Dictionary<string, object?>();
    }

    /// <summary>
    ///     Convert the parameters to a dictionary for an HTTP request.
    /// </summary>
    /// <param name="apiVersion">Optionally pass in <see cref="EasyPost.Extensions.ApiVersion"/> to check API compatibility pre-request.</param>
    /// <returns>Dictionary of parameters.</returns>
    public virtual Dictionary<string, object> ToDictionary(ApiVersion? apiVersion = null)
    {
        // Construct the dictionary of all parameters for this API version
        RegisterParameters(apiVersion);

        // Verify that all required parameters are set in the dictionary
        VerifyParameters();
        
        // Return the dictionary, removing any null values now that we've verified all required parameters are set
        // Anything still null at this point is an optional parameter that was not set that can be stripped from the request

        return _parameterDictionary.ToStringNonNullableObjectDictionary();
    }

    /// <summary>
    ///     Convert the parameters to a dictionary for an HTTP request.
    /// </summary>
    /// <param name="apiVersion">Pass in <see cref="EasyPost._base.ApiVersion"/> to check API compatibility pre-request.</param>
    /// <returns>Dictionary of parameters.</returns>
    public virtual Dictionary<string, object> ToDictionary(EasyPost._base.ApiVersion apiVersion)
    {
        var convertedApiVersion = ApiVersion.FromEasyPostLibraryApiVersion(apiVersion);

        return ToDictionary(convertedApiVersion);
    }

    /// <summary>
    ///     Add a parameter to the dictionary.
    /// </summary>
    /// <param name="requestParameterAttribute">Attribute of parameter.</param>
    /// <param name="value">Value of parameter.</param>
    private void Add(RequestParameterAttribute requestParameterAttribute, object? value)
    {
        // If a given property is an EasyPostObject, the JsonProperty attributes will serialize the object as a dictionary (later, during RestRequest)
        // Otherwise, simply add the primitive value to the dictionary.
        _parameterDictionary = UpdateDictionary(this._parameterDictionary, requestParameterAttribute.JsonPath, value);
    }

    /// <summary>
    ///     Build a dictionary from the parameters.
    /// </summary>
    /// <param name="apiVersion">Optionally pass in ApiVersion to check API compatibility pre-request.</param>
    private void RegisterParameters(ApiVersion? apiVersion = null)
    {
        var properties = GetType().GetProperties();
        foreach (var property in properties)
        {
            var parameterAttribute = NetTools.Attributes.CustomAttribute.GetAttribute<RequestParameterAttribute>(property);
            if (parameterAttribute == null)
            {
                // Ignore any properties that are not annotated with a ParameterAttribute
                continue;
            }

            // Check if the parameter is compatible with the API version, if provided
            if (apiVersion != null && !ApiCompatibilityAttribute.CheckParameterCompatible(property.Name, GetType(), apiVersion))
            {
                // Ignore any parameters that are not compatible with this API version
                continue;
            }

            var value = property.GetValue(this);
            if (value == null && parameterAttribute.Necessity == Necessity.Optional)
            {
                // Ignore any optional parameters that are null
                continue;
            }

            Add(parameterAttribute, value);
        }
    }

    /// <summary>
    ///     Check that all required parameters are set.
    /// </summary>
    /// <exception cref="MissingRequiredParameterException">If a required parameter is missing.</exception>
    private void VerifyParameters()
    {
        var properties = this.GetType().GetProperties();
        foreach (var property in properties)
        {
            var parameterAttribute = NetTools.Attributes.CustomAttribute.GetAttribute<RequestParameterAttribute>(property);
            if (parameterAttribute == null)
            {
                continue;
            }

            if (parameterAttribute.Necessity == Necessity.Required && !ValueExistsInDictionary(_parameterDictionary, parameterAttribute.JsonPath))
            {
                throw new MissingRequiredParameterException(property);
            }
        }
    }

    /// <summary>
    ///     Update a dictionary with a new value.
    /// </summary>
    /// <param name="dictionary">Dictionary to update.</param>
    /// <param name="keys">Path of new value to add.</param>
    /// <param name="value">New value to add.</param>
    /// <returns>Updated dictionary.</returns>
    /// <exception cref="Exception">Could not add value to dictionary.</exception>
    private static Dictionary<string, object?> UpdateDictionary(Dictionary<string, object?>? dictionary, string[] keys, object? value)
    {
        dictionary ??= new Dictionary<string, object?>();

        switch (keys.Length)
        {
            // Don't need to go down
            case 0:
                return dictionary;
            // Last key left
            case 1:
                var soloKey = keys[0];
                if (dictionary.ContainsKey(soloKey))
                {
                    // Key-value pair already exists in dictionary (likely because of override parameters)
                    // Only change the value if the existing value is null
                    dictionary[soloKey] ??= value;
                }
                else
                {
                    dictionary.Add(soloKey, value);
                }

                return dictionary;
        }

        // Need to go down another level
        // Get the key and update the list of keys
        var key = keys[0];
        keys = keys.Skip(1).ToArray();
        if (!dictionary.ContainsKey(key))
        {
            dictionary[key] = UpdateDictionary(new Dictionary<string, object?>(), keys, value);
        }

        var subDirectory = dictionary[key];
        if (subDirectory is Dictionary<string, object?> subDictionary)
        {
            dictionary[key] = UpdateDictionary(subDictionary, keys, value);
        }
        else
        {
            throw new Exception("Found a non-dictionary while traversing the dictionary");
        }

        return dictionary;
    }

    /// <summary>
    ///     Check that a value exists in the dictionary at a given path.
    /// </summary>
    /// <param name="dictionary">Dictionary to check.</param>
    /// <param name="keys">Path to look for.</param>
    /// <returns>True if value exists, false otherwise.</returns>
    private static bool ValueExistsInDictionary(IReadOnlyDictionary<string, object?>? dictionary, IReadOnlyList<string> keys)
    {
        if (keys.Count == 0)
        {
            return true; // no keys to check (this is the end of recursion), so return true
        }

        if (dictionary == null)
        {
            return false; // no dictionary, can't be in the dictionary
        }

        var key = keys[0];

        if (!dictionary.ContainsKey(key))
        {
            return false; // key does not exist in the dictionary
        }

        var valueRetrieved = dictionary.TryGetValue(key, out var value);

        if (!valueRetrieved)
        {
            return false; // could not retrieve value of the key
        }

        return value switch
        {
            null => false, // value of the key is null
            Dictionary<string, object?> nestedDictionary when keys.Count > 1 => ValueExistsInDictionary(nestedDictionary, keys.Skip(1).ToList()), // we need to go down another level and check this nested dictionary, only because we have more keys to check
            var _ => true // If we haven't failed yet, then the key exists, the value is not null and we have no more keys to check
        };
    }
}

public abstract class CreateRequestParameters : RequestParameters
{
    internal CreateRequestParameters(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
    {
    }
}

public abstract class UpdateRequestParameters : RequestParameters
{
    internal UpdateRequestParameters(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
    {
    }
}

public abstract class AllRequestParameters : RequestParameters
{
    #region Request Parameters

    [ApiCompatibility(ApiVersionEnum.V2, ApiVersionEnum.Beta)]
    [RequestParameter(Necessity.Optional, "after_id")]
    public string? AfterId { get; set; }

    [ApiCompatibility(ApiVersionEnum.V2, ApiVersionEnum.Beta)]
    [RequestParameter(Necessity.Optional, "before_id")]
    public string? BeforeId { get; set; }

    [ApiCompatibility(ApiVersionEnum.V2, ApiVersionEnum.Beta)]
    [RequestParameter(Necessity.Optional, "end_datetime")]
    public string? EndDatetime { get; set; }

    [ApiCompatibility(ApiVersionEnum.V2, ApiVersionEnum.Beta)]
    [RequestParameter(Necessity.Optional, "page_size")]
    public int? PageSize { get; set; }

    [ApiCompatibility(ApiVersionEnum.V2, ApiVersionEnum.Beta)]
    [RequestParameter(Necessity.Optional, "start_datetime")]
    public string? StartDatetime { get; set; }

    #endregion

    internal AllRequestParameters(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
    {
    }
}
