using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for FedEx Same-Day City <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateFedExSameDayCity : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "account_number")]
        public string? AccountNumber { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "api_key")]
        public string? ApiKey { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "tracking_api_key")]
        public string? TrackingApiKey { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateFedExSameDayCity"/> parameters.
        /// </summary>
        public CreateFedExSameDayCity() : base(Constants.CarrierAccountTypes.FedExSameDayCity)
        {
        }
    }
}
