using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for Globegistics <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateGlobegistics : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "account_number")]
        public string? AccountNumber { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "facility")]
        public string? Facility { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateGlobegistics"/> parameters.
        /// </summary>
        public CreateGlobegistics() : base(Constants.CarrierAccountTypes.Globegistics)
        {
        }
    }
}
