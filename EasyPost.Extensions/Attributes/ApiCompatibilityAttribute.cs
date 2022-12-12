using System;
using System.Collections;

namespace EasyPost.Extensions.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Module | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
internal class ApiCompatibilityAttribute : NetTools.Common.Attributes.CustomAttribute
{
    /// <summary>
    ///     The API versions that this property is compatible with.
    /// </summary>
    private ApiVersionEnum[] ApiVersions { get; }

    /// <summary>
    ///     Constructor.
    /// </summary>
    /// <param name="apiVersions">API versions that is property is compatible with.</param>
    internal ApiCompatibilityAttribute(params ApiVersionEnum[] apiVersions)
    {
        ApiVersions = apiVersions;
    }

    /// <summary>
    ///     Get whether the property is compatible with the specified API version.
    /// </summary>
    /// <param name="apiVersion">Attempted API version.</param>
    /// <returns>True if the property is compatible with the provided API version.</returns>
    private bool IsCompatible(ApiVersion apiVersion)
    {
        var apiVersionEnum = apiVersion.Enum;
        return ((IList)ApiVersions).Contains(apiVersionEnum);
    }

    /// <summary>
    ///     Check if a parameter is compatible with the current API version.
    /// </summary>
    /// <param name="parameterName">Name of parameter attempting to retrieve.</param>
    /// <param name="parameterSourceType">Type of object the parameter is being retrieved from.</param>
    /// <param name="apiVersion">Attempted API version.</param>
    /// <returns>Whether the parameter is compatible with the current API version.</returns>
    internal static bool CheckParameterCompatible(string parameterName, Type parameterSourceType, ApiVersion apiVersion)
    {
        var property = parameterSourceType.GetProperty(parameterName);
        if (property == null)
        {
            throw new ArgumentException($"Could not find method {property} on type {parameterSourceType.Name}");
        }

        var apiCompatibilityAttribute = NetTools.Common.Attributes.CustomAttribute.GetAttribute<ApiCompatibilityAttribute>(property);
        // ReSharper disable once ConvertIfStatementToReturnStatement
        if (apiCompatibilityAttribute == null)
        {
            // if property does not have an API compatibility attribute, it is compatible with all API versions
            return true;
        }

        return apiCompatibilityAttribute.IsCompatible(apiVersion);
    }
}
