using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for DPD <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateDpd : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "customer_number")]
        public string? CustomerNumber { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "password")]
        public string? Password { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "username")]
        public string? Username { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "test_credentials", "customer_number")]
        public string? TestCustomerNumber { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "test_credentials", "password")]
        public string? TestPassword { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "test_credentials", "username")]
        public string? TestUsername { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateDpd"/> parameters.
        /// </summary>
        public CreateDpd() : base(Constants.CarrierAccountTypes.Dpd)
        {
        }
    }
}
