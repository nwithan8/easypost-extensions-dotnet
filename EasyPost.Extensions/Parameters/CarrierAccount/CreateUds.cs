using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for UDS <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateUds : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "ftp_password")]
        public string? FtpPassword { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "ftp_username")]
        public string? FtpUsername { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateUds"/> parameters.
        /// </summary>
        public CreateUds() : base(Constants.CarrierAccountTypes.Uds)
        {
        }
    }
}
