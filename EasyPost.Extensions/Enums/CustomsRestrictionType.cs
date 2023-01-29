namespace EasyPost.Extensions.Enums;

/// <summary>
///     An enum that represents the different customs restriction types available for EasyPost.
/// </summary>
public class CustomsRestrictionType : NetTools.Common.ValueEnum
{
    /// <summary>
    ///     None type
    /// </summary>
    public static readonly CustomsRestrictionType None = new(0, "none");

    /// <summary>
    ///     Quarantine type
    /// </summary>
    public static readonly CustomsRestrictionType Quarantine = new(1, "quarantine");

    /// <summary>
    ///     Sanitary or phytosanitary inspection type
    /// </summary>
    public static readonly CustomsRestrictionType SanitaryInspection = new(2, "sanitary_phytosanitary_inspection");

    /// <summary>
    ///     Other type
    /// </summary>
    public static readonly CustomsRestrictionType Other = new(3, "other");

    private CustomsRestrictionType(int id, string name) : base(id, name)
    {
    }
}
