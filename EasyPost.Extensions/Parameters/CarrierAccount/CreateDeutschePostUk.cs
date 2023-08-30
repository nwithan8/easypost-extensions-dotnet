using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for Deutsche Post UK <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateDeutschePostUk : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "account_number")]
        public string? AccountNumber { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "client_id")]
        public string? ClientId { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "client_secret")]
        public string? ClientSecret { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "test_credentials", "account_number")]
        public string? TestAccountNumber { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "test_credentials", "client_id")]
        public string? TestClientId { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "test_credentials", "client_secret")]
        public string? TestClientSecret { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateDeutschePostUk"/> parameters.
        /// </summary>
        public CreateDeutschePostUk() : base(Constants.CarrierAccountTypes.DeutschePostUk)
        {
        }
    }
}
