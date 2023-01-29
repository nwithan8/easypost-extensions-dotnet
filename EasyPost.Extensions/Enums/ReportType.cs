using EasyPost.Extensions.ModelMethodExtensions;
using EasyPost.Models.API;

namespace EasyPost.Extensions.Enums;

/// <summary>
///     An enum that represents the different report types available for EasyPost.
/// </summary>
public class ReportType : NetTools.Common.MultiValueEnum
{
    /// <summary>
    ///     The report type for a cash flow report
    /// </summary>
    public static readonly ReportType CashFlow = new(0, "cash_flow", "cfrep");
    /// <summary>
    ///     The report type for a payment log report
    /// </summary>
    public static readonly ReportType PaymentLog = new(1, "payment_log", "plrep");
    /// <summary>
    ///     The report type for a refund report
    /// </summary>
    public static readonly ReportType Refund = new(2, "refund", "refrep");
    /// <summary>
    ///     The report type for a shipment report
    /// </summary>
    public static readonly ReportType Shipment = new(3, "shipment", "shprep");
    /// <summary>
    ///     The report type for a shipment invoice report
    /// </summary>
    public static readonly ReportType ShipmentInvoice = new(4, "shipment_invoice", "shpinvrep");
    /// <summary>
    ///     The report type for a tracker report
    /// </summary>
    public static readonly ReportType Tracker = new(5, "tracker", "trkrep");

    private ReportType(int id, string reportType, string prefix) : base(id, reportType, prefix)
    {
    }

    public static implicit operator ReportType?(string reportType)
    {
        return FromValue<ReportType>(reportType);
    }

    public static implicit operator ReportType?(Report report)
    {
        return FromReport(report);
    }

    public static ReportType? FromReport(Report report)
    {
        var prefix = report.GetIdPrefix();

        return FromValue<ReportType>(prefix);
    }
}
