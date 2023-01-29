using EasyPost._base;
using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;
using NetTools.Common;

namespace EasyPost.Extensions.Parameters.V2;

public static class Trackers
{
    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Tracker"/> creation API calls.
    /// </summary>
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters
        
        
        [Parameter(Necessity.Optional)]
        public string? Carrier { get; set; }


        [Parameter(Necessity.Required)]
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
            if (existingObject is not EasyPost.Models.API.Tracker tracker)
            {
                return false;
            }

            var pairs = new Pairs
            {
                { tracker.Carrier, Carrier },
                { tracker.TrackingCode, TrackingCode },
            };

            return pairs.AllMatch();
        }
    }

    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Tracker"/> list creation API calls.
    /// </summary>
    public sealed class CreateList : RequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "trackers")]
        public List<EasyPost.Models.API.Tracker>? Trackers { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateList"/> parameters.
        /// </summary>
        /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>
        public CreateList(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }

        public override Dictionary<string, object> ToDictionary(Enums.ApiVersion? apiVersion = null)
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

    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Tracker"/> list API calls.
    /// </summary>
    public sealed class All : AllRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "carrier")]
        public string? Carrier { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "tracking_code")]
        public string? TrackingCode { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="All"/> parameters.
        /// </summary>
        /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>
        public All(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
}
