using EasyPost.Extensions.Attributes;
using EasyPost.Models.API;

namespace EasyPost.Extensions.Parameters.V2;

public static class Shipments
{
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "carbon_offset")]
        public bool CarbonOffset { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "shipment", "carrier")]
        public string? Carrier { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "shipment", "carrier_accounts")]
        public List<EasyPost.Models.API.CarrierAccount>? CarrierAccounts { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "shipment", "customs_info")]
        public EasyPost.Models.API.CustomsInfo? CustomsInfo { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "shipment", "from_address")]
        public EasyPost.Models.API.Address? FromAddress { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "shipment", "insurance")]
        public double Insurance { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "shipment", "is_return")]
        public bool? IsReturn { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "shipment", "options")]
        public EasyPost.Models.API.Options? Options { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "shipment", "parcel")]
        public EasyPost.Models.API.Parcel? Parcel { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "shipment", "reference")]
        public string? Reference { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "shipment", "service")]
        public string? Service { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "shipment", "tax_identifiers")]
        public List<EasyPost.Models.API.TaxIdentifier>? TaxIdentifiers { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "shipment", "to_address")]
        public EasyPost.Models.API.Address? ToAddress { get; set; }

        #endregion

        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }

        public bool MatchesExistingObject(EasyPost.Models.API.Shipment shipment)
        {
            var pairs = new Pairs
            {
                { shipment.CustomsInfo, CustomsInfo },
                { shipment.FromAddress, FromAddress },
                { shipment.Insurance, Insurance },
                { shipment.IsReturn, IsReturn },
                { shipment.Options, Options },
                { shipment.Parcel, Parcel },
                { shipment.Reference, Reference },
                { shipment.Service, Service },
                { shipment.ToAddress, ToAddress },
            };

            return pairs.AllMatch();
        }
    }

    public sealed class GenerateRates : RequestParameters
    {
        // TODO: What are these parameters?

        public GenerateRates(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    public sealed class CreateDocument : RequestParameters
    {
        #region Request Parameters

        
        [Parameter(Necessity.Required)]
        public string? FileFormat { get; set; }

        #endregion

        public CreateDocument(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    public sealed class Insure : RequestParameters
    {
        #region Request Parameters

        
        [Parameter(Necessity.Required)]
        public double? Amount { get; set; }

        #endregion

        public Insure(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    public sealed class Label : RequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Required, "file_format")]
        public string? FileFormat { get; set; }

        #endregion

        public Label(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    public sealed class Buy : RequestParameters
    {
        #region Request Parameters

        
        [Parameter(Necessity.Optional)]
        public EndShipper? EndShipper { get; set; }

        
        [Parameter(Necessity.Optional)]
        public string? InsuranceValue { get; set; }

        
        [Parameter(Necessity.Required)]
        public EasyPost.Models.API.Rate? Rate { get; set; }

        
        [Parameter(Necessity.Optional)]
        public bool? WithCarbonOffset { get; set; }

        #endregion

        public Buy(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    public sealed class All : AllRequestParameters
    {}
}
