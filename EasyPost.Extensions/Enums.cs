namespace EasyPost.Extensions;

// This is the enum that will actually be used in the ApiCompatibility attributes
// We unfortunately have to use this because attributes can only take compile-time variables as properties
// The ValueEnum from NetTools is not a true enum
internal enum ApiVersionEnum
{
    Beta,
    V2,
}

/// <summary>
///     An enum that represents the different versions of the EasyPost API
/// </summary>
public class ApiVersion : NetTools.Common.ValueEnum
{
    /// <summary>
    ///     The beta version of the EasyPost API
    /// </summary>
    public static readonly ApiVersion Beta = new(0, "beta", ApiVersionEnum.Beta);
    
    /// <summary>
    ///     The v2 version of the EasyPost API
    /// </summary>
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

    /// <summary>
    ///     Converts a <see cref="EasyPost._base.ApiVersion"/> to a <see cref="ApiVersion"/>. Returns null if the conversion fails.
    /// </summary>
    /// <param name="apiVersion">A <see cref="EasyPost._base.ApiVersion"/> to covert.</param>
    /// <returns>The <see cref="ApiVersion"/> equivalent.</returns>
    internal static ApiVersion? FromEasyPostLibraryApiVersion(EasyPost._base.ApiVersion apiVersion)
    {
        ApiVersion? version = null;
        var @switch = new NetTools.Common.SwitchCase
        {
            // we always want to check if it matches "Current" first, since this value in the EasyPost library can change.
            // There's no "Current" in this utility, so we want to map it to the latest version manually.
            { EasyPost._base.ApiVersion.Current.ToString(), () => version = V2 },
            { EasyPost._base.ApiVersion.Beta.ToString(), () => version = Beta },
            { NetTools.Common.Scenario.Default, () => version = null },
        };
        @switch.MatchFirst(apiVersion.ToString());

        return version;
    }

    public static bool operator ==(_base.ApiVersion? left, ApiVersion? right)
    {
        if (left is null && right is null)
            return true;
        if (left is null || right is null)
            return false;
        var convertedApiVersion = FromEasyPostLibraryApiVersion(left);
        return convertedApiVersion == right;
    }

    public static bool operator !=(_base.ApiVersion? left, ApiVersion? right)
    {
        return !(left == right);
    }

    public static bool operator <(EasyPost._base.ApiVersion? left, ApiVersion? right)
    {
        if (left is null && right is null)
            return true;
        if (left is null || right is null)
            return false;
        var convertedApiVersion = FromEasyPostLibraryApiVersion(left);
        return convertedApiVersion < right;
    }

    public static bool operator >(_base.ApiVersion? left, ApiVersion? right)
    {
        return !(left <= right);
    }

    public static bool operator <=(_base.ApiVersion? left, ApiVersion? right)
    {
        if (left is null && right is null)
            return true;
        if (left is null || right is null)
            return false;
        var convertedApiVersion = FromEasyPostLibraryApiVersion(left);
        return convertedApiVersion <= right;
    }

    public static bool operator >=(_base.ApiVersion? left, ApiVersion? right)
    {
        return !(left < right);
    }

    public static bool operator ==(ApiVersion? left, _base.ApiVersion? right)
    {
        if (left is null && right is null)
            return true;
        if (left is null || right is null)
            return false;
        var convertedApiVersion = FromEasyPostLibraryApiVersion(right);
        return left == convertedApiVersion;
    }

    public static bool operator !=(ApiVersion? left, _base.ApiVersion? right)
    {
        return !(left == right);
    }

    public static bool operator <(ApiVersion? left, _base.ApiVersion? right)
    {
        if (left is null && right is null)
            return true;
        if (left is null || right is null)
            return false;
        var convertedApiVersion = FromEasyPostLibraryApiVersion(right);
        return left < convertedApiVersion;
    }

    public static bool operator >(ApiVersion? left, _base.ApiVersion? right)
    {
        return !(left <= right);
    }

    public static bool operator <=(ApiVersion? left, _base.ApiVersion? right)
    {
        if (left is null && right is null)
            return true;
        if (left is null || right is null)
            return false;
        var convertedApiVersion = FromEasyPostLibraryApiVersion(right);
        return left <= convertedApiVersion;
    }

    public static bool operator >=(ApiVersion? left, _base.ApiVersion? right)
    {
        return !(left < right);
    }
}

/// <summary>
///     An enum that represents the different report types available for EasyPost
/// </summary>
public class ReportType : NetTools.Common.ValueEnum
{
    /// <summary>
    ///     The report type for a cash flow report
    /// </summary>
    public static readonly ReportType CashFlow = new(0, "cash_flow");
    /// <summary>
    ///     The report type for a payment log report
    /// </summary>
    public static readonly ReportType PaymentLog = new(1, "payment_log");
    /// <summary>
    ///     The report type for a refund report
    /// </summary>
    public static readonly ReportType Refund = new(2, "refund");
    /// <summary>
    ///     The report type for a shipment report
    /// </summary>
    public static readonly ReportType Shipment = new(3, "shipment");
    /// <summary>
    ///     The report type for a shipment invoice report
    /// </summary>
    public static readonly ReportType ShipmentInvoice = new(4, "shipment_invoice");
    /// <summary>
    ///     The report type for a tracker report
    /// </summary>
    public static readonly ReportType Tracker = new(5, "tracker");

    private ReportType(int id, string reportType) : base(id, reportType)
    {
    }
}
