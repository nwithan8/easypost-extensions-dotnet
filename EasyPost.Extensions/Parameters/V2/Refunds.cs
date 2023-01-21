using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Parameters.V2;

public static class Refunds
{
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Required, "refund", "carrier")]
        public string? Carrier { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "refund", "tracking_codes")] // yes, the param name is plural when it's really just one code
        public string? TrackingCode { get; set; }

        #endregion

        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }

        public bool MatchesExistingObject(EasyPost.Models.API.Refund refund)
        {
            var pairs = new Pairs
            {
                { refund.Carrier, Carrier },
                { refund.TrackingCode, TrackingCode }
            };

            return pairs.AllMatch();
        }
    }

    public sealed class All : AllRequestParameters
    {}
}
