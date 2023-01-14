namespace EasyPost.Extensions;

// This is the enum that will actually be used in the ApiCompatibility attributes
// We unfortunately have to use this because attributes can only take compile-time variables as properties
// The ValueEnum from NetTools is not a true enum
internal enum ApiVersionEnum
{
    Beta,
    V2,
}

public class ApiVersion : NetTools.Common.ValueEnum
{
    public static readonly ApiVersion Beta = new(0, "beta", ApiVersionEnum.Beta);
    public static readonly ApiVersion V2 = new(1, "v2", ApiVersionEnum.V2);

    internal ApiVersionEnum Enum { get; private set; }

    private ApiVersion(int id, string version, ApiVersionEnum @enum) : base(id, version)
    {
        Enum = @enum;
    }

    public static implicit operator ApiVersion?(EasyPost._base.ApiVersion apiVersion)
    {
        return FromEasyPostLibraryApiVersion(apiVersion);
    }

    internal static ApiVersion? FromEasyPostLibraryApiVersion(EasyPost._base.ApiVersion apiVersion)
    {
        ApiVersion? version = null;
        var @switch = new NetTools.Common.SwitchCase
        {
            // we always want to check if it matches "Current" first, since this value in the EasyPost library can change.
            // There's no "Current" in this utility, so we want to map it to the latest version manually.
            { EasyPost._base.ApiVersion.Current.ToString(), () => version = V2 },
            { EasyPost._base.ApiVersion.Beta.ToString(), () => version = Beta },
            { NetTools.Common.Scenario.Default, () => version = null }
        };
        @switch.MatchFirst(apiVersion.ToString());

        return version;
    }
}

public class ReportType : NetTools.Common.ValueEnum
{
    public static readonly ReportType CashFlow = new(0, "cash_flow");
    public static readonly ReportType PaymentLog = new(1, "payment_log");
    public static readonly ReportType Refund = new(2, "refund");
    public static readonly ReportType Shipment = new(3, "shipment");
    public static readonly ReportType ShipmentInvoice = new(4, "shipment_invoice");
    public static readonly ReportType Tracker = new(5, "tracker");

    private ReportType(int id, string reportType) : base(id, reportType)
    {
    }
}
