using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for Omni Parcel <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateOmniParcel : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "api_access_key")]
        public string? ApiAccessKey { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "return_api_access_key")]
        public string? ReturnApiAccessKey { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "test_credentials", "api_access_key")]
        public string? TestApiAccessKey { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "test_credentials", "return_api_access_key")]
        public string? TestReturnApiAccessKey { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateOmniParcel"/> parameters.
        /// </summary>
        public CreateOmniParcel() : base(Constants.CarrierAccountTypes.OmniParcel)
        {
        }
    }
}
