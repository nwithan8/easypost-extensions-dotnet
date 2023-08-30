using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    // TODO: Requires hitting /register endpoint
    
    /// <summary>
    ///     Parameters for FedEx Smartpost <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateFedExSmartpost : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "account_number")]
        public string? AccountNumber { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "hub_id")]
        public string? HubId { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "corporate_city")]
        public string? CorporateAddressCity { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "corporate_country_code")]
        public string? CorporateAddressCountryCode { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "corporate_postal_code")]
        public string? CorporateAddressPostalCode { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "corporate_state")]
        public string? CorporateAddressState { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "corporate_streets")]
        public string? CorporateAddressStreet { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "corporate_company_name")]
        public string? CorporateCompanyName { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "corporate_email_address")]
        public string? CorporateEmailAddress { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "corporate_first_name")]
        public string? CorporateFirstName { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "corporate_job_title")]
        public string? CorporateJobTitle { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "corporate_last_name")]
        public string? CorporateLastName { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "corporate_phone_number")]
        public string? CorporatePhoneNumber { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "shipping_city")]
        public string? ShippingAddressCity { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "shipping_country_code")]
        public string? ShippingAddressCountryCode { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "shipping_postal_code")]
        public string? ShippingAddressPostalCode { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "shipping_state")]
        public string? ShippingAddressState { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "registration_data", "shipping_streets")]
        public string? ShippingAddressStreet { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateFedExSmartpost"/> parameters.
        /// </summary>
        internal CreateFedExSmartpost() : base(Constants.CarrierAccountTypes.FedExSmartPost)
        {
            // TODO: Make public when endpoint is fixed
        }
    }
}
