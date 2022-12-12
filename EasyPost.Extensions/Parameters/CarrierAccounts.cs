using System.Collections.Generic;
using EasyPost.Extensions.Attributes;
using NetTools.Common.Attributes.PropertyGroups;

namespace EasyPost.Extensions.Parameters;

public static class CarrierAccounts
{
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "type")]
        public string? Type { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "description")]
        public string? Description { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "reference")]
        public string? Reference { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "credentials")]
        public Dictionary<string, object?>? Credentials { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "test_credentials")]
        // ReSharper disable once InconsistentNaming
        public Dictionary<string, object?>? TestCredentials { get; set; }

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

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "type")]
        internal string Type => "FedexAccount";

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "description")]
        public string? Description { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "reference")]
        public string? Reference { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "account_number")]
        public string? AccountNumber { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "shipping_streets")]
        public string? ShippingAddressStreet { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "shipping_city")]
        public string? ShippingAddressCity { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "shipping_state")]
        public string? ShippingAddressState { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "shipping_postal_code")]
        public string? ShippingAddressPostalCode { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "shipping_country_code")]
        public string? ShippingAddressCountryCode { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_first_name")]
        public string? CorporateFirstName { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_last_name")]
        public string? CorporateLastName { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_job_title")]
        public string? CorporateJobTitle { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_company_name")]
        public string? CorporateCompanyName { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_phone_number")]
        public string? CorporatePhoneNumber { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_email_address")]
        public string? CorporateEmailAddress { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_streets")]
        public string? CorporateAddressStreet { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_city")]
        public string? CorporateAddressCity { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_state")]
        public string? CorporateAddressState { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_postal_code")]
        public string? CorporateAddressPostalCode { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "corporate_country_code")]
        public string? CorporateAddressCountryCode { get; set; }

        #endregion

        public CreateFedEx(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    public sealed class CreateUps : CreateRequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "type")]
        internal string Type => "UpsAccount";

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "description")]
        public string? Description { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "reference")]
        public string? Reference { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "account_number")]
        public string? AccountNumber { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "city")]
        public string? City { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "company")]
        public string? CompanyName { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "country")]
        public string? Country { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "email")]
        public string? Email { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "name")]
        public string? RegistrarName { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "phone")]
        public string? PhoneNumber { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "postal_code")]
        public string? PostalCode { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "state")]
        public string? State { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "street1")]
        public string? Street { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "registration_data", "street2")]
        public string? Street2 { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "title")]
        public string? RegistrarJobTitle { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "carrier_account", "registration_data", "website")]
        public string? Website { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "registration_data", "invoice_amount")]
        [AllOrNothingGroup("ups_invoice_info")]
        public string? InvoiceAmount { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "registration_data", "invoice_control_id")]
        [AllOrNothingGroup("ups_invoice_info")]
        public string? InvoiceControlId { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "registration_data", "invoice_currency")]
        [AllOrNothingGroup("ups_invoice_info")]
        public string? InvoiceCurrency { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "registration_data", "invoice_date")]
        [AllOrNothingGroup("ups_invoice_info")]
        public string? InvoiceDate { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "registration_data", "invoice_number")]
        [AllOrNothingGroup("ups_invoice_info")]
        public string? InvoiceNumber { get; set; }

        #endregion

        public CreateUps(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    public sealed class Update : UpdateRequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "description")]
        public string? Description { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "reference")]
        public string? Reference { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "credentials")]
        public Dictionary<string, object?>? Credentials { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "test_credentials")]
        // ReSharper disable once InconsistentNaming
        public Dictionary<string, object?>? TestCredentials { get; set; }

        #endregion

        public Update(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    public sealed class All : AllRequestParameters
    {
    }
}
