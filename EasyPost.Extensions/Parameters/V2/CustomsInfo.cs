using EasyPost.Extensions.Attributes;

namespace EasyPost.Extensions.Parameters.V2;

public static class CustomsInfo
{
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "customs_info", "contents_explanation")]
        public string? ContentsExplanation { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "customs_info", "contents_type")]
        public string? ContentsType { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "customs_info", "customs_certify")]
        public bool? CustomsCertify { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "customs_info", "customs_items")]
        public List<EasyPost.Models.API.CustomsItem>? CustomsItems { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "customs_info", "customs_signer")]
        public string? CustomsSigner { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "customs_info", "eel_pfc")]
        public string? EelPfc { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "customs_info", "non_delivery_option")]
        public string? NonDeliveryOption { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "customs_info", "restriction_type")]
        public string? RestrictionType { get; set; }

        #endregion

        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }

        public bool MatchesExistingObject(EasyPost.Models.API.CustomsInfo customsInfo)
        {
            var pairs = new Pairs
            {
                { customsInfo.CustomsCertify.ToBoolean(), CustomsCertify },
                { customsInfo.CustomsSigner, CustomsSigner },
                { customsInfo.ContentsType, ContentsType },
                { customsInfo.EelPfc, EelPfc },
                { customsInfo.ContentsExplanation, ContentsExplanation },
                { customsInfo.RestrictionType, RestrictionType },
                { customsInfo.NonDeliveryOption, NonDeliveryOption },
                { customsInfo.RestrictionType, RestrictionType },
                { customsInfo.CustomsItems, CustomsItems }
            };

            return pairs.AllMatch();
        }
    }

    public sealed class All : AllRequestParameters
    {}
}
