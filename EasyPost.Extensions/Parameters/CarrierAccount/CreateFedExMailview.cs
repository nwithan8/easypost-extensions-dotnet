using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for FedEx Mailview <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public class CreateFedExMailview : CreateCustom
    {
        #region Request Parameters

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "customer_id")]
        public string? CustomerId { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "fimspremium")]
        public string? FimsPremium { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "fimsstandard")]
        public string? FimsStandard { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "mailviewlight")]
        public string? MailviewLight { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "mailviewpremium")]
        public string? MailviewPremium { get; set; }

        [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "carrier_account", "credentials", "service_id")]
        public string? ServiceId { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateFedExMailview"/> parameters.
        /// </summary>
        public CreateFedExMailview() : base(Constants.CarrierAccountTypes.FedExMailview)
        {
        }
    }
}
