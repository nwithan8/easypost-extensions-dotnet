using System.Collections.Generic;
using EasyPost.Extensions.Attributes;
using NetTools;

namespace EasyPost.Extensions.Parameters;

public static class Trackers
{
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "tracker", "carrier")]
        public string? Carrier { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "tracker", "tracking_code")]
        public string? TrackingCode { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "tracker", "amount")]
        public string? Amount { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "options", "carrier_account")]
        public string? CarrierAccount { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "options", "is_return")]
        public bool? IsReturn { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "options", "full_test_tracker")]
        public bool? FullTestTracker { get; set; }

        #endregion

        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
        
        public bool MatchesExistingObject(EasyPost.Models.API.Tracker tracker)
        {
            var pairs = new Pairs
            {
                { tracker.Carrier, Carrier },
                { tracker.TrackingCode, TrackingCode },
            };

            return pairs.AllMatch();
        }
    }

    public sealed class CreateList : RequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "trackers")]
        public List<EasyPost.Models.API.Tracker>? Trackers { get; set; }

        #endregion

        public CreateList(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }

        public override Dictionary<string, object> ToDictionary(ApiVersion? apiVersion = null)
        {
            // TODO: This custom overload does not check for API compatibility.
            // TODO: Please, fix this hack in the API?
            var trackersDictionary = new Dictionary<string, object>
            {
            };
            Trackers?.Each((index, tracker) => { trackersDictionary.Add(index.ToString(), tracker); });
            return new Dictionary<string, object>
            {
                {
                    "trackers", trackersDictionary
                }
            };
        }

        public override Dictionary<string, object> ToDictionary(EasyPost._base.ApiVersion apiVersion)
        {
            // TODO: This custom overload does not check for API compatibility.
            // TODO: Please, fix this hack in the API?
            var trackersDictionary = new Dictionary<string, object>
            {
            };
            Trackers?.Each((index, tracker) => { trackersDictionary.Add(index.ToString(), tracker); });
            return new Dictionary<string, object>
            {
                {
                    "trackers", trackersDictionary
                }
            };
        }
    }

    public sealed class All : AllRequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "tracking_code")]
        public string? TrackingCode { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier")]
        public string? Carrier { get; set; }

        #endregion

        public All(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
}
