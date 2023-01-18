using EasyPost.Extensions.Attributes;

namespace EasyPost.Extensions.Parameters.Beta
{
    public abstract class RequestParameters : Parameters
    {
        public override ApiVersion ApiVersion => ApiVersion.Beta;
        
        internal RequestParameters(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
    
    public abstract class CreateRequestParameters : RequestParameters
    {
        internal CreateRequestParameters(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    public abstract class UpdateRequestParameters : RequestParameters
    {
        internal UpdateRequestParameters(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    public abstract class AllRequestParameters : RequestParameters
    {
        #region Request Parameters
        
        [JsonRequestParameter(Necessity.Optional, "after_id")]
        public string? AfterId { get; set; }

        [JsonRequestParameter(Necessity.Optional, "before_id")]
        public string? BeforeId { get; set; }

        [JsonRequestParameter(Necessity.Optional, "end_datetime")]
        public string? EndDatetime { get; set; }

        [JsonRequestParameter(Necessity.Optional, "page_size")]
        public int? PageSize { get; set; }

        [JsonRequestParameter(Necessity.Optional, "start_datetime")]
        public string? StartDatetime { get; set; }

        #endregion

        internal AllRequestParameters(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
}
