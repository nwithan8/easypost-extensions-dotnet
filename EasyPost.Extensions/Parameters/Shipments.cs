using System.Collections.Generic;
using EasyPost.Extensions.Attributes;

namespace EasyPost.Extensions.Parameters;

public static class Shipments
    {
        public sealed class Create : CreateRequestParameters
        {
            #region Request Parameters

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "carbon_offset")]
            public bool CarbonOffset { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "shipment", "carrier")]
            public string? Carrier { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "shipment", "carrier_accounts")]
            public List<EasyPost.Models.API.CarrierAccount>? CarrierAccounts { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "shipment", "customs_info")]
            public EasyPost.Models.API.CustomsInfo? CustomsInfo { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "shipment", "from_address")]
            public EasyPost.Models.API.Address? FromAddress { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "shipment", "insurance")]
            public double Insurance { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "shipment", "is_return")]
            public bool? IsReturn { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "shipment", "options")]
            public EasyPost.Models.API.Options? Options { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "shipment", "parcel")]
            public EasyPost.Models.API.Parcel? Parcel { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "shipment", "reference")]
            public string? Reference { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "shipment", "service")]
            public string? Service { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "shipment", "tax_identifiers")]
            public List<EasyPost.Models.API.TaxIdentifier>? TaxIdentifiers { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "shipment", "to_address")]
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

        public sealed class Insure : RequestParameters
        {
            #region Request Parameters

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Required, "amount")]
            public double? Amount { get; set; }

            #endregion

            public Insure(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
            {
            }
        }

        public sealed class Label : RequestParameters
        {
            #region Request Parameters

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Required, "file_format")]
            public string? FileFormat { get; set; }

            #endregion

            public Label(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
            {
            }
        }

        public sealed class Buy : RequestParameters
        {
            #region Request Parameters

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "insurance")]
            public string? InsuranceValue { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Required, "rate")]
            public EasyPost.Models.API.Rate? Rate { get; set; }

            #endregion

            public Buy(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
            {
            }
        }
    }
