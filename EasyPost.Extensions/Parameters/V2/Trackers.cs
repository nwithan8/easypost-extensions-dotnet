using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;
using NetTools.Common;

namespace EasyPost.Extensions.Parameters.V2;

public static class Trackers
{
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters
        
        
        [Parameter(Necessity.Optional)]
        public string? Carrier { get; set; }


        [Parameter(Necessity.Required)]
        public string? TrackingCode { get; set; }

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

        
        [JsonRequestParameter(Necessity.Optional, "trackers")]
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

        
        [JsonRequestParameter(Necessity.Optional, "carrier")]
        public string? Carrier { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "tracking_code")]
        public string? TrackingCode { get; set; }

        #endregion

        public All(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
}
