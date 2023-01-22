namespace EasyPost.Extensions.Internal.Attributes;

/// <summary>
///     An enum to represent the necessity of a parameter.
/// </summary>
internal enum Necessity
{
    /// <summary>
    ///     Required parameters are required for a request. They do not need a default value, since they are required to be set.
    /// </summary>
    Required,
    /// <summary>
    ///     Optional parameters are optional for a request. Default value for these should be null.
    /// </summary>
    Optional,
}

/// <summary>
///     An attribute to label a parameter of a function.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
internal class ParameterAttribute : NetTools.Common.Attributes.CustomAttribute
{
    /// <summary>
    ///     The <see cref="Necessity"/> of the parameter.
    /// </summary>
    internal Necessity Necessity { get; }

    /// <summary>
    ///     Constructs a new <see cref="ParameterAttribute"/> with the given <see cref="Necessity"/> and JSON path.
    /// </summary>
    /// <param name="necessity"></param>
    internal ParameterAttribute(Necessity necessity)
    {
        Necessity = necessity;
    }
}

/// <summary>
///     An attribute to label a parameter that will be sent in an HTTP request to the EasyPost API.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
internal class JsonRequestParameterAttribute : ParameterAttribute
{
    /// <summary>
    ///     The keys, in order, where the value of the property should be placed in the JSON data.
    /// </summary>
    internal string[] JsonPath { get; }
    
    /// <summary>
    ///     Constructs a new <see cref="JsonRequestParameterAttribute"/> with the given <see cref="Necessity"/> and JSON path.
    /// </summary>
    /// <param name="necessity"></param>
    /// <param name="jsonPath"></param>
    internal JsonRequestParameterAttribute(Necessity necessity, params string[] jsonPath) : base(necessity)
    {
        JsonPath = jsonPath;
    }
}
