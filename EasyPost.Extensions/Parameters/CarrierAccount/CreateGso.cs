using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for GSO <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateGso : CreateCustom
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
        ///     Construct a new set of <see cref="CreateGso"/> parameters.
        /// </summary>
        public CreateGso() : base(Constants.CarrierAccountTypes.Gso)
        {
        }
    }
}
