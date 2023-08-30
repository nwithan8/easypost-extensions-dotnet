using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for Bond <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateBond : CreateCustom
    {
        #region Request Parameters
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "api_key")]
        public string? ApiKey { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "test_credentials", "api_key")]
        public string? TestApiKey { get; set; }
        
        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateBond"/> parameters.
        /// </summary>
        public CreateBond() : base(Constants.CarrierAccountTypes.Bond)
        {
        }
    }
}

