using EasyPost._base;
using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Parameters.V2;

public static class Reports
{
    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Report"/> creation API calls.
    /// </summary>
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
        public bool IncludeChildren { get; set; } = false;


        [JsonRequestParameter(Necessity.Optional, "report", "send_email")]
        public bool SendEmail { get; set; } = false;

        
        [JsonRequestParameter(Necessity.Required, "report", "start_date")]
        public string? StartDate { get; set; }

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
            if (existingObject is not EasyPost.Models.API.Report report)
            {
                return false;
            }

            var pairs = new Pairs
            {
                { report.StartDate, StartDate },
                { report.EndDate, EndDate },
                { report.IncludeChildren, IncludeChildren },
            };

            return pairs.AllMatch();
        }
    }

    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Report"/> list API calls.
    /// </summary>
    public sealed class All : AllRequestParameters
    {}
}
