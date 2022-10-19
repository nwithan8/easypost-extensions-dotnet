using System;

namespace EasyPost.Extensions.Attributes;

internal enum Necessity
{
    /// <summary>
    ///     Required parameters are required for a request. They do not need a default value, since they are required to be set.
    /// </summary>
    Required,
    /// <summary>
    ///     Optional parameters are optional for a request. Default value for these should be null.
    /// </summary>
    Optional
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
internal class RequestParameterAttribute : NetTools.Attributes.CustomAttribute
{
    /// <summary>
    ///     The keys, in order, where the value of the property should be placed in the JSON data.
    /// </summary>
    internal string[] JsonPath { get; }

    /// <summary>
    ///     The <see cref="Necessity"/> of the parameter.
    /// </summary>
    internal Necessity Necessity { get; }

    /// <summary>
    ///     Constructs a new <see cref="RequestParameterAttribute"/> with the given <see cref="Necessity"/> and <see cref="JsonPath"/>.
    /// </summary>
    /// <param name="necessity"></param>
    /// <param name="jsonPath"></param>
    internal RequestParameterAttribute(Necessity necessity, params string[] jsonPath)
    {
        Necessity = necessity;
        JsonPath = jsonPath;
    }
}
