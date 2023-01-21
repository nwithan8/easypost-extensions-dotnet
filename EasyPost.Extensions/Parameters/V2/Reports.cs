using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Parameters.V2;

public static class Reports
{
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "report", "additional_columns")]
        public List<string>? AdditionalColumns { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "report", "columns")]
        public List<string>? Columns { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "report", "end_date")]
        public string? EndDate { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "report", "include_children")]
        public bool? IncludeChildren { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "report", "send_email")]
        public bool? SendEmail { get; set; }

        
        [JsonRequestParameter(Necessity.Required, "report", "start_date")]
        public string? StartDate { get; set; }

        #endregion

        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }

        public bool MatchesExistingObject(EasyPost.Models.API.Report report)
        {
            var pairs = new Pairs
            {
                { report.StartDate, StartDate },
                { report.EndDate, EndDate },
                { report.IncludeChildren, IncludeChildren },
            };

            return pairs.AllMatch();
        }
    }

    public sealed class All : AllRequestParameters
    {}
}
