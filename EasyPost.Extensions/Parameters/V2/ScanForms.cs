using EasyPost.Extensions.Attributes;

namespace EasyPost.Extensions.Parameters.V2;

public static class ScanForms
{
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        
        [Parameter(Necessity.Required)]
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
