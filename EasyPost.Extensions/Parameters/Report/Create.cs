using EasyPost.Extensions.Enums;

namespace EasyPost.Extensions.Parameters.Report;

public class Create : EasyPost.Parameters.Report.Create
{
    /// <summary>
    ///     The columns to include in the report, as <see cref="ReportColumn"/> enums.
    /// </summary>
    public List<ReportColumn>? ColumnEnums { get; set; }
    
    /// <summary>
    ///     The additional columns to include in the report, as <see cref="ReportColumn"/> enums.
    /// </summary>
    public List<ReportColumn>? AdditionalColumnEnums { get; set; }

    public override Dictionary<string, object> ToDictionary()
    {
        // set the base parameters prior to serializing
        var columns = ColumnEnums?.Select(x => x.StringValue).ToList();
        if (columns != null)
        {
            Columns = new List<string>();
            foreach (var column in columns.Where(column => column != null))
            {
                Columns.Add(column!);
            }
        }
        
        var additionalColumns = AdditionalColumnEnums?.Select(x => x.StringValue).ToList();
        // ReSharper disable once InvertIf
        if (additionalColumns != null)
        {
            AdditionalColumns = new List<string>();
            foreach (var additionalColumn in additionalColumns.Where(additionalColumn => additionalColumn != null))
            {
                AdditionalColumns.Add(additionalColumn!);
            }
        }

        return base.ToDictionary();
    }
    
    /// <summary>
    ///     Construct a new set of <see cref="Report.Create"/> parameters.
    /// </summary>
    public Create()
    {
    }
}
