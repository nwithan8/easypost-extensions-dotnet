using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for OSM Worldwide <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateOsmWorldwide : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "account_number")]
        public string? AccountNumber { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "aws_sftp_username")]
        public string? AwsSftpUsername { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "company_name")]
        public string? CompanyName { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "facility_code")]
        public string? FacilityCode { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "mailer_id")]
        public string? MailerId { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateOsmWorldwide"/> parameters.
        /// </summary>
        public CreateOsmWorldwide() : base(Constants.CarrierAccountTypes.OsmWorldwide)
        {
        }
    }
}
