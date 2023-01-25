using EasyPost._base;
using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Parameters.V2;

public static class Pickups
{
    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Pickup"/> creation API calls.
    /// </summary>
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "pickup", "address")]
        public EasyPost.Models.API.Address? Address { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "pickup", "batch")]
        public EasyPost.Models.API.Batch? Batch { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "pickup", "carrier_accounts")]
        public List<EasyPost.Models.API.CarrierAccount>? CarrierAccounts { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "pickup", "instructions")]
        public string? Instructions { get; set; }


        [JsonRequestParameter(Necessity.Optional, "pickup", "is_account_address")]
        public bool IsAccountAddress { get; set; } = false;

        
        [JsonRequestParameter(Necessity.Optional, "pickup", "max_datetime")]
        public DateTime? MaxDatetime { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "pickup", "min_datetime")]
        public DateTime? MinDatetime { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "pickup", "reference")]
        public string? Reference { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "pickup", "shipment")]
        public EasyPost.Models.API.Shipment? Shipment { get; set; }

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
            if (existingObject is not EasyPost.Models.API.Pickup pickup)
            {
                return false;
            }
                
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

    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Pickup"/> buy API calls.
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

    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Pickup"/> list API calls.
    /// </summary>
    public sealed class All : AllRequestParameters
    {
    }
}
