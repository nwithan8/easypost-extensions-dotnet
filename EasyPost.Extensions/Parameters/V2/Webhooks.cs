using EasyPost._base;
using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Parameters.V2;

public static class Webhooks
{
    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Webhook"/> update API calls.
    /// </summary>
    public sealed class Update : UpdateRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "webhook_secret")]
        public string? Secret { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "url")]
        public string? Url { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="Update"/> parameters.
        /// </summary>
        /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>
        public Update(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }

        public bool MatchesExistingObject(EasyPost.Models.API.Webhook webhook)
        {
            var pairs = new Pairs
            {
                { webhook.Url, Url },
            };

            return pairs.AllMatch();
        }
    }

    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Webhook"/> creation API calls.
    /// </summary>
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "webhook_secret")]
        public string? Secret { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "url")]
        public string? Url { get; set; }

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
            if (existingObject is not EasyPost.Models.API.Webhook webhook)
            {
                return false;
            }

            var pairs = new Pairs
            {
                { webhook.Url, Url },
            };

            return pairs.AllMatch();
        }
    }

    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Webhook"/> list API calls.
    /// </summary>
    public sealed class All : AllRequestParameters
    {}
}
