using System.Collections.Generic;
using System.Linq;
using EasyPost.Extensions.Attributes;

namespace EasyPost.Extensions.Parameters;

public static class Refunds
{
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "refund", "carrier")]
        public string? Carrier { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "refund", "tracking_codes")] // yes, the param name is plural when it's really just one code
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
