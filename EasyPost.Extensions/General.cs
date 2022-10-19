using System.Collections.Generic;

namespace EasyPost.Extensions;

public static class General
{
    /// <summary>
    ///     Build the default EasyPost API base URL using a given API version.
    /// </summary>
    /// <param name="apiVersion">A <see cref="EasyPost._base.ApiVersion"/></param>
    /// <returns>A formatted EasyPost API base URL string.</returns>
    public static string BuildApiBaseUrl(EasyPost._base.ApiVersion apiVersion)
    {
        return $"https://api.easypost.com/{apiVersion}/";
    }

    /// <summary>
    ///     Build the default EasyPost API base URL using a given API version.
    /// </summary>
    /// <param name="apiVersion">A <see cref="EasyPost.Extensions.ApiVersion"/></param>
    /// <returns>A formatted EasyPost API base URL string.</returns>
    public static string BuildApiBaseUrl(ApiVersion apiVersion)
    {
        return $"https://api.easypost.com/{apiVersion}/";
    }

    /// <summary>
    ///     Converts a dictionary of string, object key-value pairs to a dictionary of string, object? (nullable) key-value pairs.
    /// </summary>
    /// <param name="dictionary">Dictionary to convert.</param>
    /// <returns>A Dictionary of string, object? pairs.</returns>
    public static Dictionary<string, object?> ConvertToStringNullableObjectDictionary(Dictionary<string, object> dictionary)
    {
        var newDictionary = new Dictionary<string, object?>();
        foreach (var item in dictionary)
        {
            newDictionary.Add(item.Key, item.Value);
        }

        return newDictionary;
    }

    /// <summary>
    ///     Converts a dictionary of string, object key-value pairs to a dictionary of string, object? (nullable) key-value pairs.
    /// </summary>
    /// <param name="dictionary">Dictionary to convert.</param>
    /// <returns>A Dictionary of string, object? pairs.</returns>
    public static Dictionary<string, object?> ToStringNullableObjectDictionary(this Dictionary<string, object> dictionary)
    {
        return ConvertToStringNullableObjectDictionary(dictionary);
    }

    /// <summary>
    ///     Converts a dictionary of string, object? (nullable) key-value pairs to a dictionary of string, object key-value pairs
    ///     by omitting key-value pairs with null values.
    /// </summary>
    /// <param name="dictionary"></param>
    /// <returns>A dictionary of string, object pairs.</returns>
    public static Dictionary<string, object> ConvertToStringNonNullableObjectDictionary(Dictionary<string, object?> dictionary)
    {
        var newDictionary = new Dictionary<string, object>();
        foreach (var item in dictionary)
        {
            if (item.Value != null)
            {
                newDictionary.Add(item.Key, item.Value);
            }
        }

        return newDictionary;
    }

    /// <summary>
    ///     Converts a dictionary of string, object? (nullable) key-value pairs to a dictionary of string, object key-value pairs
    ///     by omitting key-value pairs with null values.
    /// </summary>
    /// <param name="dictionary"></param>
    /// <returns>A dictionary of string, object pairs.</returns>
    public static Dictionary<string, object> ToStringNonNullableObjectDictionary(this Dictionary<string, object?> dictionary)
    {
        return ConvertToStringNonNullableObjectDictionary(dictionary);
    }
}
