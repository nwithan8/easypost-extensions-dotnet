using EasyPost.Extensions.Attributes;

namespace EasyPost.Extensions.Parameters.V2;

public static class Batches
    {
        public sealed class Create : CreateRequestParameters
        {
            #region Request Parameters

            
            [JsonRequestParameter(Necessity.Optional, "shipment", "carrier")]
            public string? Carrier { get; set; }

            
            [JsonRequestParameter(Necessity.Optional, "shipment", "carrier_accounts")]
            public List<EasyPost.Models.API.CarrierAccount>? CarrierAccounts { get; set; }

            
            [JsonRequestParameter(Necessity.Optional, "shipment", "service")]
            public string? Service { get; set; }

            
            [JsonRequestParameter(Necessity.Required, "batch", "shipments")]
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

            
            [JsonRequestParameter(Necessity.Required, "shipments")]
            public List<EasyPost.Models.API.Shipment>? Shipments { get; set; }

            #endregion

            public UpdateShipments(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
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

        public sealed class All : AllRequestParameters
        {}
    }
