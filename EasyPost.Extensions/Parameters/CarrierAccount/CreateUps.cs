using EasyPost.Utilities.Internal.Attributes;
using NetTools.Common.Attributes.PropertyGroups;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for UPS <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateUps : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "account_number")]
        public string? AccountNumber { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "city")]
        public string? City { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "company")]
        public string? CompanyName { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "country")]
        public string? Country { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "email")]
        public string? Email { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Optional, "carrier_account", "registration_data", "invoice_amount")]
        [AllOrNothingGroup("ups_invoice_info")]
        public string? InvoiceAmount { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Optional, "carrier_account", "registration_data", "invoice_control_id")]
        [AllOrNothingGroup("ups_invoice_info")]
        public string? InvoiceControlId { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Optional, "carrier_account", "registration_data", "invoice_currency")]
        [AllOrNothingGroup("ups_invoice_info")]
        public string? InvoiceCurrency { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Optional, "carrier_account", "registration_data", "invoice_date")]
        [AllOrNothingGroup("ups_invoice_info")]
        public string? InvoiceDate { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Optional, "carrier_account", "registration_data", "invoice_number")]
        [AllOrNothingGroup("ups_invoice_info")]
        public string? InvoiceNumber { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "phone")]
        public string? PhoneNumber { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "postal_code")]
        public string? PostalCode { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "title")]
        public string? RegistrarJobTitle { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "name")]
        public string? RegistrarName { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "state")]
        public string? State { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "street1")]
        public string? Street { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Optional, "carrier_account", "registration_data", "street2")]
        public string? Street2 { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "website")]
        public string? Website { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateUps"/> parameters.
        /// </summary>
        public CreateUps() : base(Constants.CarrierAccountTypes.Ups)
        {
        }
    }
}
