using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for Better Trucks <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateBetterTrucks : CreateCustom
    {
        #region Request Parameters
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "api_key")]
        public string? ApiKey { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "test_credentials", "api_key")]
        public string? TestApiKey { get; set; }
        
        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateBetterTrucks"/> parameters.
        /// </summary>
        public CreateBetterTrucks() : base(Constants.CarrierAccountTypes.BetterTrucks)
        {
        }
    }
}

