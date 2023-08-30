using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for Smart Kargo <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateSmartKargo : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "account_number")]
        public string? AccountNumber { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "test_credentials", "account_number")]
        public string? TestAccountNumber { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateSmartKargo"/> parameters.
        /// </summary>
        public CreateSmartKargo() : base(Constants.CarrierAccountTypes.SmartKargo)
        {
        }
    }
}
