using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for Swyft <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateSwyft : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "password")]
        public string? Password { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "test_credentials", "password")]
        public string? TestPassword { get; set; }
        
        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateSwyft"/> parameters.
        /// </summary>
        public CreateSwyft() : base(Constants.CarrierAccountTypes.Swyft)
        {
        }
    }
}
