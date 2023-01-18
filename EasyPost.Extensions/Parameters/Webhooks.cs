using System.Collections.Generic;
using EasyPost.Extensions.Attributes;

namespace EasyPost.Extensions.Parameters;

public static class Webhooks
{
    public sealed class Update : UpdateRequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [JsonRequestParameter(Necessity.Optional, "webhook_secret")]
        public string? Secret { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [JsonRequestParameter(Necessity.Optional, "url")]
        public string? Url { get; set; }

        #endregion

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

    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [JsonRequestParameter(Necessity.Optional, "webhook_secret")]
        public string? Secret { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [JsonRequestParameter(Necessity.Required, "url")]
        public string? Url { get; set; }

        #endregion

        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    public sealed class All : AllRequestParameters
    {}
}
