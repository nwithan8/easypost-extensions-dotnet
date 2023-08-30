using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for USPS <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateUsps : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "address_city")]
        public string? AddressCity { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "address_state")]
        public string? AddressState { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "address_street")]
        public string? AddressStreet { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "address_zip")]
        public string? AddressZip { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "company_name")]
        public string? CompanyName { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "email")]
        public string? Email { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "phone")]
        public string? Phone { get; set; }
        
        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "shipper_id")]
        public string? ShipperId { get; set; }
        
        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateUsps"/> parameters.
        /// </summary>
        public CreateUsps() : base(Constants.CarrierAccountTypes.Usps)
        {
        }
    }
}
