using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Parameters.V2;

public static class Webhooks
{
    public sealed class Update : UpdateRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "webhook_secret")]
        public string? Secret { get; set; }

        
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

        
        [JsonRequestParameter(Necessity.Optional, "webhook_secret")]
        public string? Secret { get; set; }

        
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
