using EasyPost._base;
using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Parameters.V2;

public static class Orders
{
    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Order"/> creation API calls.
    /// </summary>
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

        /// <summary>
        ///     Construct a new set of <see cref="Create"/> parameters.
        /// </summary>
        /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>
        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }

        public override bool MatchesExistingObject(EasyPostObject existingObject)
        {
            if (existingObject is not EasyPost.Models.API.Order order)
            {
                return false;
            }
                
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

    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Order"/> buy API calls.
    /// </summary>
    public sealed class Buy : RequestParameters
    {
        #region Request Parameters

        
        [Parameter(Necessity.Required)]
        public string? Carrier { get; set; }

        
        [Parameter(Necessity.Required)]
        public string? Service { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="Buy"/> parameters.
        /// </summary>
        /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>
        public Buy(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
}
