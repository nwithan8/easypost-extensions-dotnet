using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for DPD UK <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateDpdUk : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "account_number")]
        public string? AccountNumber { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "password")]
        public string? Password { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "username")]
        public string? Username { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateDpdUk"/> parameters.
        /// </summary>
        public CreateDpdUk() : base(Constants.CarrierAccountTypes.DpdUk)
        {
        }
    }
}
