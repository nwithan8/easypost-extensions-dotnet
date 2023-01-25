using EasyPost._base;
using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Parameters.V2;

public static class Refunds
{
    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Refund"/> creation API calls.
    /// </summary>
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Required, "refund", "carrier")]
        public string? Carrier { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "refund", "tracking_codes")] // yes, the param name is plural when it's really just one code
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
            if (existingObject is not EasyPost.Models.API.Refund refund)
            {
                return false;
            }

            var pairs = new Pairs
            {
                { refund.Carrier, Carrier },
                { refund.TrackingCode, TrackingCode }
            };

            return pairs.AllMatch();
        }
    }
    
    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Refund"/> list API calls.
    /// </summary>
    public sealed class All : AllRequestParameters
    {}
}
