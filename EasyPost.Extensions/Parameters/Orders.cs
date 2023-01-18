using System.Collections.Generic;
using EasyPost.Extensions.Attributes;

namespace EasyPost.Extensions.Parameters;

public static class Orders
{
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [JsonRequestParameter(Necessity.Optional, "order", "carrier_accounts")]
        public List<EasyPost.Models.API.CarrierAccount>? CarrierAccounts { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [JsonRequestParameter(Necessity.Optional, "order", "from_address")]
        public EasyPost.Models.API.Address? FromAddress { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [JsonRequestParameter(Necessity.Optional, "order", "reference")]
        public string? Reference { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [JsonRequestParameter(Necessity.Optional, "order", "shipments")]
        public List<EasyPost.Models.API.Shipment>? Shipments { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [JsonRequestParameter(Necessity.Optional, "order", "to_address")]
        public EasyPost.Models.API.Address? ToAddress { get; set; }

        #endregion

        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }

        public bool MatchesExistingObject(EasyPost.Models.API.Order order)
        {
            var pairs = new Pairs
            {
                { order.Reference, Reference },
                { order.ToAddress, ToAddress },
                { order.FromAddress, FromAddress },
                { order.Shipments, Shipments },
                { order.CarrierAccounts, CarrierAccounts },
            };

            return pairs.AllMatch();
        }
    }

    public sealed class Buy : RequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [JsonRequestParameter(Necessity.Required, "carrier")]
        public string? Carrier { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [JsonRequestParameter(Necessity.Required, "service")]
        public string? Service { get; set; }

        #endregion

        public Buy(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
}
