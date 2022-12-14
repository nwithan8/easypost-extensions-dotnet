using System.Collections.Generic;
using EasyPost.Extensions.Attributes;

namespace EasyPost.Extensions.Parameters;

public static class Addresses
{
    public class Create : CreateRequestParameters
    {
        #region Request Parameters

        [RequestParameter(Necessity.Optional, "address", "carrier_facility")]
        public string? CarrierFacility { get; set; }

        [RequestParameter(Necessity.Optional, "address", "city")]
        public string? City { get; set; }

        [RequestParameter(Necessity.Optional, "address", "company")]
        public string? Company { get; set; }

        [RequestParameter(Necessity.Optional, "address", "country")]
        public string? Country { get; set; }

        [RequestParameter(Necessity.Optional, "address", "email")]
        public string? Email { get; set; }

        [RequestParameter(Necessity.Optional, "address", "federal_tax_id")]
        public string? FederalTaxId { get; set; }

        [RequestParameter(Necessity.Optional, "address", "name")]
        public string? Name { get; set; }

        [RequestParameter(Necessity.Optional, "address", "phone")]
        public string? Phone { get; set; }

        [RequestParameter(Necessity.Optional, "address", "residential")]
        public bool? Residential { get; set; }

        [RequestParameter(Necessity.Optional, "address", "state")]
        public string? State { get; set; }

        [RequestParameter(Necessity.Optional, "address", "state_tax_id")]
        public string? StateTaxId { get; set; }

        [RequestParameter(Necessity.Optional, "address", "street1")]
        public string? Street1 { get; set; }

        [RequestParameter(Necessity.Optional, "address", "street2")]
        public string? Street2 { get; set; }

        [RequestParameter(Necessity.Optional, "verify_strict")]
        public bool? ToStrictVerify { get; set; }

        [RequestParameter(Necessity.Optional, "verify")]
        public bool? ToVerify { get; set; }

        [RequestParameter(Necessity.Optional, "address", "zip")]
        public string? Zip { get; set; }

        #endregion

        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }

        public bool MatchesExistingObject(EasyPost.Models.API.Address address)
        {
            var pairs = new Pairs
            {
                { address.Street1, this.Street1 },
                { address.Street2, this.Street2 },
                { address.City, this.City },
                { address.State, this.State },
                { address.Zip, this.Zip },
                { address.Country, this.Country },
                { address.Name, this.Name },
                { address.Company, this.Company },
                { address.Phone, this.Phone },
                { address.Email, this.Email },
                { address.Residential, this.Residential },
                { address.CarrierFacility, this.CarrierFacility },
                { address.FederalTaxId, this.FederalTaxId },
                { address.StateTaxId, this.StateTaxId },
            };

            return pairs.AllMatch();
        }
    }

    public sealed class All : AllRequestParameters
    {}

    public class Update : Create
    {}
}
