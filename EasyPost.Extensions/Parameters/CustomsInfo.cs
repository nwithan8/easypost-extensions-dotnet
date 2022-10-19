using System.Collections.Generic;
using EasyPost.Extensions.Attributes;

namespace EasyPost.Extensions.Parameters;

public static class CustomsInfo
{
    public sealed class Create : RequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "customs_info", "customs_certify")]
        public bool? CustomsCertify { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "customs_info", "customs_signer")]
        public string? CustomsSigner { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "customs_info", "contents_type")]
        public string? ContentsType { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "customs_info", "restrictions_type")]
        public string? RestrictionsType { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "customs_info", "eel_pfc")]
        public string? EelPfc { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "customs_info", "customs_items")]
        public List<EasyPost.Models.API.CustomsItem>? CustomsItems { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "customs_info", "contents_explanation")]
        public string? ContentsExplanation { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "customs_info", "restriction_type")]
        public string? RestrictionType { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "customs_info", "non_delivery_option")]
        public string? NonDeliveryOption { get; set; }

        #endregion

        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
    
    public sealed class All : AllRequestParameters
    {
    }
}
