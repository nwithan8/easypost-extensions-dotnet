using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Parameters.V2;

public static class CustomsItems
{
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "customs_item", "description")]
        public string? Description { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "customs_item", "hs_tariff_number")]
        public string? HsTariffNumber { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "customs_item", "origin_country")]
        public string? OriginCountry { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "customs_item", "quantity")]
        public int? Quantity { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "customs_item", "value")]
        public double? Value { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "customs_item", "weight")]
        public double? Weight { get; set; }

        #endregion

        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }

        public bool MatchesExistingObject(EasyPost.Models.API.CustomsItem customsItem)
        {
            var pairs = new Pairs
            {
                { customsItem.Description, Description },
                { customsItem.Quantity, Quantity },
                { customsItem.Weight, Weight },
                { customsItem.Value, Value },
                { customsItem.HsTariffNumber, HsTariffNumber },
                { customsItem.OriginCountry, OriginCountry },
            };

            return pairs.AllMatch();
        }
    }

    public sealed class All : AllRequestParameters
    {}
}
