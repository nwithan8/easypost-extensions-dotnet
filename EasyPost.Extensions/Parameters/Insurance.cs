using System.Collections.Generic;
using EasyPost.Extensions.Attributes;

namespace EasyPost.Extensions.Parameters;

public static class Insurance
{
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [JsonRequestParameter(Necessity.Optional, "insurance", "amount")]
        public double? Amount { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [JsonRequestParameter(Necessity.Optional, "insurance", "carrier")]
        public string? Carrier { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [JsonRequestParameter(Necessity.Optional, "insurance", "from_address")]
        public EasyPost.Models.API.Address? FromAddress { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [JsonRequestParameter(Necessity.Optional, "insurance", "reference")]
        public string? Reference { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [JsonRequestParameter(Necessity.Optional, "insurance", "to_address")]
        public EasyPost.Models.API.Address? ToAddress { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [JsonRequestParameter(Necessity.Optional, "insurance", "tracking_code")]
        public string? TrackingCode { get; set; }

        #endregion

        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }

        public bool MatchesExistingObject(EasyPost.Models.API.Insurance insurance)
        {
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

    public sealed class All : AllRequestParameters
    {}
}
