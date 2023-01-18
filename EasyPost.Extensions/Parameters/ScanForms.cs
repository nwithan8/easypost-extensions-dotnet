using System.Collections.Generic;
using EasyPost.Extensions.Attributes;

namespace EasyPost.Extensions.Parameters;

public static class ScanForms
{
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [JsonRequestParameter(Necessity.Required, "shipments")]
        public List<EasyPost.Models.API.Shipment>? Shipments { get; set; }

        #endregion

        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }

        public bool MatchesExistingObject(EasyPost.Models.API.ScanForm scanForm)
        {
            var pairs = new Pairs
            {
            };

            return pairs.AllMatch();
        }
    }

    public sealed class All : AllRequestParameters
    {}
}
