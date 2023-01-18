using EasyPost.Extensions.Attributes;
using NetTools.Common.Attributes.PropertyGroups;

namespace EasyPost.Extensions.Parameters.V2;

public static class CarrierAccounts
{
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "carrier_account", "credentials")]
        public Dictionary<string, object?>? Credentials { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "carrier_account", "description")]
        public string? Description { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "carrier_account", "reference")]
        public string? Reference { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "carrier_account", "test_credentials")]
        // ReSharper disable once InconsistentNaming
        public Dictionary<string, object?>? TestCredentials { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "carrier_account", "type")]
        public string? Type { get; set; }

        #endregion

        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }

        public bool MatchesExistingObject(EasyPost.Models.API.CarrierAccount carrierAccount)
        {
            var pairs = new Pairs
            {
                { carrierAccount.Credentials, Credentials },
                { carrierAccount.Description, Description },
                { carrierAccount.TestCredentials, TestCredentials },
                { carrierAccount.Type, Type }
            };

            return pairs.AllMatch();
        }
    }

    public sealed class CreateFedEx : CreateRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "type")]
        internal string Type => "FedexAccount";

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "account_number")]
        public string? AccountNumber { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_city")]
        public string? CorporateAddressCity { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_country_code")]
        public string? CorporateAddressCountryCode { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_postal_code")]
        public string? CorporateAddressPostalCode { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_state")]
        public string? CorporateAddressState { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_streets")]
        public string? CorporateAddressStreet { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_company_name")]
        public string? CorporateCompanyName { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_email_address")]
        public string? CorporateEmailAddress { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_first_name")]
        public string? CorporateFirstName { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_job_title")]
        public string? CorporateJobTitle { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_last_name")]
        public string? CorporateLastName { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_phone_number")]
        public string? CorporatePhoneNumber { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "carrier_account", "description")]
        public string? Description { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "carrier_account", "reference")]
        public string? Reference { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "shipping_city")]
        public string? ShippingAddressCity { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "shipping_country_code")]
        public string? ShippingAddressCountryCode { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "shipping_postal_code")]
        public string? ShippingAddressPostalCode { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "shipping_state")]
        public string? ShippingAddressState { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "shipping_streets")]
        public string? ShippingAddressStreet { get; set; }

        #endregion

        public CreateFedEx(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    public sealed class CreateUps : CreateRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "type")]
        internal string Type => "UpsAccount";

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "account_number")]
        public string? AccountNumber { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "city")]
        public string? City { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "company")]
        public string? CompanyName { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "country")]
        public string? Country { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "carrier_account", "description")]
        public string? Description { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "email")]
        public string? Email { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "carrier_account", "registration_data", "invoice_amount")]
        [AllOrNothingGroup("ups_invoice_info")]
        public string? InvoiceAmount { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "carrier_account", "registration_data", "invoice_control_id")]
        [AllOrNothingGroup("ups_invoice_info")]
        public string? InvoiceControlId { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "carrier_account", "registration_data", "invoice_currency")]
        [AllOrNothingGroup("ups_invoice_info")]
        public string? InvoiceCurrency { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "carrier_account", "registration_data", "invoice_date")]
        [AllOrNothingGroup("ups_invoice_info")]
        public string? InvoiceDate { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "carrier_account", "registration_data", "invoice_number")]
        [AllOrNothingGroup("ups_invoice_info")]
        public string? InvoiceNumber { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "phone")]
        public string? PhoneNumber { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "postal_code")]
        public string? PostalCode { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "carrier_account", "reference")]
        public string? Reference { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "title")]
        public string? RegistrarJobTitle { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "name")]
        public string? RegistrarName { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "state")]
        public string? State { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "street1")]
        public string? Street { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "carrier_account", "registration_data", "street2")]
        public string? Street2 { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "carrier_account", "registration_data", "website")]
        public string? Website { get; set; }

        #endregion

        public CreateUps(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    public sealed class Update : UpdateRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "carrier_account", "credentials")]
        public Dictionary<string, object?>? Credentials { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "carrier_account", "description")]
        public string? Description { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "carrier_account", "reference")]
        public string? Reference { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "carrier_account", "test_credentials")]
        // ReSharper disable once InconsistentNaming
        public Dictionary<string, object?>? TestCredentials { get; set; }

        #endregion

        public Update(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    public sealed class All : AllRequestParameters
    {}
}
