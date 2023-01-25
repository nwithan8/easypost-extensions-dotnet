using EasyPost._base;
using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Parameters.V2;

public static class Insurance
{
    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Insurance"/> creation API calls.
    /// </summary>
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "insurance", "amount")]
        public double? Amount { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "insurance", "carrier")]
        public string? Carrier { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "insurance", "from_address")]
        public EasyPost.Models.API.Address? FromAddress { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "insurance", "reference")]
        public string? Reference { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "insurance", "to_address")]
        public EasyPost.Models.API.Address? ToAddress { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "insurance", "tracking_code")]
        public string? TrackingCode { get; set; }

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
            if (existingObject is not EasyPost.Models.API.Insurance insurance)
            {
                return false;
            }
                
            var pairs = new Pairs
            {
                { insurance.ToAddress, ToAddress },
                { insurance.FromAddress, FromAddress },
                { insurance.TrackingCode, TrackingCode },
                { insurance.Reference, Reference },
                { insurance.Amount, Amount },
            };

            return pairs.AllMatch();
        }
    }

    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Insurance"/> list API calls.
    /// </summary>
    public sealed class All : AllRequestParameters
    {}
}
