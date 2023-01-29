namespace EasyPost.Extensions.Enums;

/// <summary>
///     An enum that represents the different non-delivery options available for EasyPost.
/// </summary>
public class NonDeliveryOption : NetTools.Common.ValueEnum
{
    /// <summary>
    ///     Abandon shipment
    /// </summary>
    public static readonly NonDeliveryOption Abandon = new(0, "abandon");

    /// <summary>
    ///     Return shipment
    /// </summary>
    public static readonly NonDeliveryOption Return = new(1, "return");

    private NonDeliveryOption(int id, string name) : base(id, name)
    {
    }
}
