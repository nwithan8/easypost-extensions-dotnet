using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Parameters.V2;

public static class Orders
{
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "order", "carrier_accounts")]
        public List<EasyPost.Models.API.CarrierAccount>? CarrierAccounts { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "order", "from_address")]
        public EasyPost.Models.API.Address? FromAddress { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "order", "reference")]
        public string? Reference { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "order", "shipments")]
        public List<EasyPost.Models.API.Shipment>? Shipments { get; set; }

        
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

        
        [Parameter(Necessity.Required)]
        public string? Carrier { get; set; }

        
        [Parameter(Necessity.Required)]
        public string? Service { get; set; }

        #endregion

        public Buy(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
}
