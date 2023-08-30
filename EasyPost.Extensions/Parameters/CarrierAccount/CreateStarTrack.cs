using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for Star Track <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateStarTrack : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "account_number")]
        public string? AccountNumber { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "api_key")]
        public string? ApiKey { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "api_secret")]
        public string? ApiSecret { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "print_as_you_go")]
        public string? PrintAsYouGo { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateStarTrack"/> parameters.
        /// </summary>
        public CreateStarTrack() : base(Constants.CarrierAccountTypes.StarTrack)
        {
        }
    }
}
