namespace EasyPost.Extensions.Enums;

/// <summary>
///     An enum that represents the different form types available for EasyPost.
/// </summary>
public class FormType : NetTools.Common.ValueEnum
{
    /// <summary>
    ///     CN22 form
    /// </summary>
    public static readonly FormType Cn22 = new(0, "cn22");

    /// <summary>
    ///     COD return label form
    /// </summary>
    public static readonly FormType CodReturnLabel = new(1, "cod_return_label");

    /// <summary>
    ///     Commercial invoice form
    /// </summary>
    public static readonly FormType CommercialInvoice = new(2, "commercial_invoice");

    /// <summary>
    ///     High value report form
    /// </summary>
    public static readonly FormType HighValueReport = new(3, "high_value_report");

    /// <summary>
    ///     Label QR code form
    /// </summary>
    public static readonly FormType LabelQrCode = new(4, "label_qr_code");

    /// <summary>
    ///     NAFTA certificate of origin form
    /// </summary>
    public static readonly FormType NaftaCertificateOfOrigin = new(5, "nafta_certificate_of_origin");

    /// <summary>
    ///     Order summary form
    /// </summary>
    public static readonly FormType OrderSummary = new(6, "order_summary");

    /// <summary>
    ///     Return packing slip form
    /// </summary>
    public static readonly FormType ReturnPackingSlip = new(7, "return_packing_slip");

    /// <summary>
    ///     RMA QR code form
    /// </summary>
    public static readonly FormType RmaQrCode = new(8, "rma_qr_code");

    private FormType(int id, string name) : base(id, name)
    {
    }
}
