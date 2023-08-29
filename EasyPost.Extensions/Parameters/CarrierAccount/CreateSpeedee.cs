using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for Speedee <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateSpeedee : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "account_number")]
        public string? AccountNumber { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "ftp_password")]
        public string? FtpPassword { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "ftp_username")]
        public string? FtpUsername { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateSpeedee"/> parameters.
        /// </summary>
        public CreateSpeedee() : base(Constants.CarrierAccountTypes.Speedee)
        {
        }
    }
}
