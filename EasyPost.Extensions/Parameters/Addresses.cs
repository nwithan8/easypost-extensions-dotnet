using EasyPost.Extensions.Attributes;

namespace EasyPost.Extensions.Parameters;

public static class Address
{
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        [RequestParameter(Necessity.Optional, "address", "street1")]
        public string? Street1 { internal get; set; }

        [RequestParameter(Necessity.Optional, "address", "street2")]
        public string? Street2 { internal get; set; }

        [RequestParameter(Necessity.Optional, "address", "city")]
        public string? City { internal get; set; }

        [RequestParameter(Necessity.Optional, "address", "state")]
        public string? State { internal get; set; }

        [RequestParameter(Necessity.Optional, "address", "zip")]
        public string? Zip { internal get; set; }

        [RequestParameter(Necessity.Optional, "address", "country")]
        public string? Country { internal get; set; }

        [RequestParameter(Necessity.Optional, "address", "name")]
        public string? Name { internal get; set; }

        [RequestParameter(Necessity.Optional, "address", "company")]
        public string? Company { internal get; set; }

        [RequestParameter(Necessity.Optional, "address", "phone")]
        public string? Phone { internal get; set; }

        [RequestParameter(Necessity.Optional, "address", "email")]
        public string? Email { internal get; set; }

        [RequestParameter(Necessity.Optional, "address", "residential")]
        public bool? Residential { internal get; set; }

        [RequestParameter(Necessity.Optional, "address", "carrier_facility")]
        public string? CarrierFacility { internal get; set; }

        [RequestParameter(Necessity.Optional, "address", "federal_tax_id")]
        public string? FederalTaxId { internal get; set; }

        [RequestParameter(Necessity.Optional, "address", "state_tax_id")]
        public string? StateTaxId { internal get; set; }

        [RequestParameter(Necessity.Optional, "verify")]
        public bool? ToVerify { internal get; set; }

        [RequestParameter(Necessity.Optional, "verify_strict")]
        public bool? ToStrictVerify { internal get; set; }

        #endregion

        public Create(Dictionary<string, object?>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    public sealed class All : AllRequestParameters
    {
    }
}
