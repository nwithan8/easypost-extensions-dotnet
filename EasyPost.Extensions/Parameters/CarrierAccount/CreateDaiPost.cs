using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for Dai Post <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateDaiPost : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "username")]
        public string? Username { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "password")]
        public string? Password { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "account_code")]
        public string? AccountCode { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "origin_terminal")]
        public string? OriginTerminal { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateDaiPost"/> parameters.
        /// </summary>
        public CreateDaiPost() : base(Constants.CarrierAccountTypes.DaiPost)
        {
        }
    }
}
