namespace EasyPost.Extensions.Enums;

/// <summary>
///     An enum that represents the different types of customs forms available for EasyPost.
/// </summary>
public class CustomsFormType : NetTools.Common.ValueEnum
{
    /// <summary>
    ///     EEL form
    /// </summary>
    public static readonly CustomsFormType Eel = new(0, "EEL");

    /// <summary>
    ///     PFC form
    /// </summary>
    public static readonly CustomsFormType Pfc = new(1, "PFC");

    private CustomsFormType(int id, string name) : base(id, name)
    {
    }
}
