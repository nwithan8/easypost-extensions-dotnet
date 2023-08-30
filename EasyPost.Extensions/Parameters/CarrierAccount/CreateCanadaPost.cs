using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for Canada Post <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateCanadaPost : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "api_key")]
        public string? ApiKey { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "contract_id")]
        public string? ContractId { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "customer_number")]
        public string? CustomerNumber { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "has_credit_card")]
        public string? HasCreditCard { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "not_platform")]
        public string? NotPlatform { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "test_credentials", "api_key")]
        public string? TestApiKey { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "test_credentials", "contract_id")]
        public string? TestContractId { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "test_credentials", "customer_number")]
        public string? TestCustomerNumber { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "test_credentials", "has_credit_card")]
        public string? TestHasCreditCard { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "test_credentials", "not_platform")]
        public string? TestNotPlatform { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateCanadaPost"/> parameters.
        /// </summary>
        public CreateCanadaPost() : base(Constants.CarrierAccountTypes.CanadaPost)
        {
        }
    }
}
