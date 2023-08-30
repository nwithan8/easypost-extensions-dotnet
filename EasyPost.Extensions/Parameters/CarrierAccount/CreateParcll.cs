using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for Parcll <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateParcll : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "api_key")]
        public string? ApiKey { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "origin_hub")]
        public string? OriginHub { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "user_id")]
        public string? UserId { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "test_credentials", "api_key")]
        public string? TestApiKey { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "test_credentials", "origin_hub")]
        public string? TestOriginHub { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "test_credentials", "user_id")]
        public string? TestUserId { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateParcll"/> parameters.
        /// </summary>
        public CreateParcll() : base(Constants.CarrierAccountTypes.Parcll)
        {
        }
    }
}
