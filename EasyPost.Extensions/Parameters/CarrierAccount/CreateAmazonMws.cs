using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for Amazon MWS <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateAmazonMws : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "access_key_id")]
        public string? AccessKeyId { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "merchant_id")]
        public string? MerchantId { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "secret_key")]
        public string? SecretKey { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateAmazonMws"/> parameters.
        /// </summary>
        public CreateAmazonMws() : base(Constants.CarrierAccountTypes.AmazonMws)
        {
        }
    }
}

