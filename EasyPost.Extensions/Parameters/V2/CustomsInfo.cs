using EasyPost._base;
using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Parameters.V2;

public static class CustomsInfo
{
    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.CustomsInfo"/> creation API calls.
    /// </summary>
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        [JsonRequestParameter(Necessity.Optional, "customs_info", "contents_explanation")]
        public string? ContentsExplanation { get; set; }

        [JsonRequestParameter(Necessity.Optional, "customs_info", "contents_type")]
        public string? ContentsType { get; set; }

        [JsonRequestParameter(Necessity.Optional, "customs_info", "customs_certify")]
        public bool CustomsCertify { get; set; } = false;

        [JsonRequestParameter(Necessity.Optional, "customs_info", "customs_items")]
        public List<EasyPost.Models.API.CustomsItem>? CustomsItems { get; set; }

        [JsonRequestParameter(Necessity.Optional, "customs_info", "customs_signer")]
        public string? CustomsSigner { get; set; }

        public CustomsFormType? EelPfc { get; set; }

        [JsonRequestParameter(Necessity.Optional, "customs_info", "eel_pfc")]
        private string? EelPfcString => EelPfc?.ToString();

        public NonDeliveryOption? NonDeliveryOption { get; set; }

        [JsonRequestParameter(Necessity.Optional, "customs_info", "non_delivery_option")]
        private string? NonDeliveryOptionString => NonDeliveryOption?.ToString();

        public CustomsRestrictionType? RestrictionType { get; set; }

        [JsonRequestParameter(Necessity.Optional, "customs_info", "restriction_type")]
        private string? RestrictionTypeString => RestrictionType?.ToString();

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
            if (existingObject is not EasyPost.Models.API.CustomsInfo customsInfo)
            {
                return false;
            }

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

    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.CustomsInfo"/> list API calls.
    /// </summary>
    public sealed class All : AllRequestParameters
    {
    }
}
