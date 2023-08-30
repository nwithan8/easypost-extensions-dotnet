using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for UPS I-Parcel <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateUpsIparcel : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "api_key")]
        public string? ApiKey { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateUpsIparcel"/> parameters.
        /// </summary>
        public CreateUpsIparcel() : base(Constants.CarrierAccountTypes.UpsIparcel)
        {
        }
    }
}
