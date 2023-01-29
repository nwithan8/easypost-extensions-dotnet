namespace EasyPost.Extensions.Enums;

/// <summary>
///     An enum that represents the different batch states available for EasyPost.
/// </summary>
public class BatchState : NetTools.Common.ValueEnum
{
    /// <summary>
    ///     The batch is being created
    /// </summary>
    public static readonly BatchState Creating = new(0, "creating");

    /// <summary>
    ///     Creation of the batch failed
    /// </summary>
    public static readonly BatchState CreationFailed = new(1, "creation_failed");

    /// <summary>
    ///     The batch has been created
    /// </summary>
    public static readonly BatchState Created = new(2, "created");

    /// <summary>
    ///     The batch is being purchased
    /// </summary>
    public static readonly BatchState Purchasing = new(3, "purchasing");

    /// <summary>
    ///     Purchase of the batch failed
    /// </summary>
    public static readonly BatchState PurchaseFailed = new(4, "purchase_failed");

    /// <summary>
    ///     The batch has been purchased
    /// </summary>
    public static readonly BatchState Purchased = new(5, "purchased");

    /// <summary>
    ///     The label for the batch is being generated
    /// </summary>
    public static readonly BatchState LabelGenerating = new(6, "label_generating");

    /// <summary>
    ///     The label for the batch has been generated
    /// </summary>
    public static readonly BatchState LabelGenerated = new(7, "label_generated");

    private BatchState(int id, string name) : base(id, name)
    {
    }
}
