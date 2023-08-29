using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for RR Donnelley <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateRRDonnelley : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "account_number")]
        public string? AccountNumber { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateRRDonnelley"/> parameters.
        /// </summary>
        public CreateRRDonnelley() : base(Constants.CarrierAccountTypes.RRDonnelley)
        {
        }
    }
}
