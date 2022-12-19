using System.Collections.Generic;
using EasyPost.Extensions.Attributes;

namespace EasyPost.Extensions.Parameters;

public static class Batches
    {
        public sealed class Create : CreateRequestParameters
        {
            #region Request Parameters

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "shipment", "carrier")]
            public string? Carrier { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "shipment", "carrier_accounts")]
            public List<EasyPost.Models.API.CarrierAccount>? CarrierAccounts { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "shipment", "service")]
            public string? Service { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Required, "batch", "shipments")]
            public List<EasyPost.Models.API.Shipment>? Shipments { get; set; }

            #endregion

            public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
            {
            }

            public bool MatchesExistingObject(EasyPost.Models.API.Batch batch)
            {
                var pairs = new Pairs
                {
                };

                return pairs.AllMatch();
            }
        }

        public sealed class UpdateShipments : RequestParameters
        {
            #region Request Parameters

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Required, "shipments")]
            public List<EasyPost.Models.API.Shipment>? Shipments { get; set; }

            #endregion

            public UpdateShipments(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
            {
            }
        }

        public sealed class CreateDocument : RequestParameters
        {
            #region Request Parameters

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Required, "file_format")]
            public string? FileFormat { get; set; }

            #endregion

            public CreateDocument(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
            {
            }
        }

        public sealed class All : AllRequestParameters
        {}
    }
