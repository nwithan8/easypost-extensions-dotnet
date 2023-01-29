using EasyPost.Extensions.ModelMethodExtensions;
using EasyPost.Models.API;

namespace EasyPost.Extensions;

/// <summary>
///     Various enums used throughout the EasyPost Extensions library.
/// </summary>
public static class Enums
{
    // This is the enum that will actually be used in the ApiCompatibility attributes
    // We unfortunately have to use this because attributes can only take compile-time variables as properties
    // The ValueEnum from NetTools is not a true enum
    internal enum ApiVersionEnum
    {
        Beta,
        V2,
    }

    /// <summary>
    ///     An enum that represents the different versions of the EasyPost API.
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
        /// <returns>The <see cref="Enums.ApiVersion"/> equivalent.</returns>
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

    /// <summary>
    ///     An enum that represents the different file formats available for EasyPost.
    /// </summary>
    public class FileFormat : NetTools.Common.ValueEnum
    {
        /// <summary>
        ///     PDF file format
        /// </summary>
        public static readonly FileFormat Pdf = new(0, "pdf");

        /// <summary>
        ///     ZPL file format
        /// </summary>
        public static readonly FileFormat Zpl = new(1, "zpl");

        /// <summary>
        ///     EPL2 file format
        /// </summary>
        public static readonly FileFormat Epl2 = new(2, "epl2");

        private FileFormat(int id, string name) : base(id, name)
        {
        }
    }

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
}
