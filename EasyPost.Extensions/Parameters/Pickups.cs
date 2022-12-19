using System;
using System.Collections.Generic;
using EasyPost.Extensions.Attributes;

namespace EasyPost.Extensions.Parameters;

public static class Pickups
    {
        public sealed class Create : CreateRequestParameters
        {
            #region Request Parameters

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "pickup", "address")]
            public EasyPost.Models.API.Address? Address { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "pickup", "batch")]
            public EasyPost.Models.API.Batch? Batch { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "pickup", "carrier_accounts")]
            public List<EasyPost.Models.API.CarrierAccount>? CarrierAccounts { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "pickup", "instructions")]
            public string? Instructions { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "pickup", "is_account_address")]
            public bool? IsAccountAddress { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "pickup", "max_datetime")]
            public DateTime? MaxDatetime { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "pickup", "min_datetime")]
            public DateTime? MinDatetime { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "pickup", "reference")]
            public string? Reference { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Optional, "pickup", "shipment")]
            public EasyPost.Models.API.Shipment? Shipment { get; set; }

            #endregion

            public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
            {
            }

            public bool MatchesExistingObject(EasyPost.Models.API.Pickup pickup)
            {
                var pairs = new Pairs
                {
                    { pickup.Address, Address },
                    { pickup.CarrierAccounts, CarrierAccounts },
                    { pickup.Instructions, Instructions },
                    { pickup.Reference, Reference },
                    { pickup.IsAccountAddress, IsAccountAddress },
                    { pickup.MinDatetime, MinDatetime },
                    { pickup.MaxDatetime, MaxDatetime },
                };

                return pairs.AllMatch();
            }
        }

        public sealed class Buy : RequestParameters
        {
            #region Request Parameters

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Required, "carrier")]
            public string? Carrier { get; set; }

            [ApiCompatibility(ApiVersionEnum.V2)]
            [RequestParameter(Necessity.Required, "service")]
            public string? Service { get; set; }

            #endregion

            public Buy(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
            {
            }
        }
    }
