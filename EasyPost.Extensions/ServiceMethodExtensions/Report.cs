using EasyPost.Extensions.ModelMethodExtensions;
using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.ReportService" /> class.
/// </summary>
public static class ReportServiceExtensions
{
    /// <summary>
    ///     List all <see cref="EasyPost.Models.API.Report"/>s of a specified type.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.ReportService"/> to use for the API call.</param>
    /// <param name="type">The <see cref="Enums.ReportType"/> to retrieve.</param>
    /// <param name="parameters">The <see cref="Reports.All"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="Enums.ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.RefundCollection"/> object.</returns>
    public static async Task<ReportCollection> All(this ReportService service, Enums.ReportType type, Reports.All parameters, Enums.ApiVersion? apiVersion = null)
    {
        return await service.All(type.ToString()!, parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Create a <see cref="EasyPost.Models.API.Report"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.ReportService"/> to use for the API call.</param>
    /// <param name="type">The <see cref="Enums.ReportType"/> to create.</param>
    /// <param name="parameters">The <see cref="Reports.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="Enums.ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.Report"/> object.</returns>
    public static async Task<Report> Create(this ReportService service, Enums.ReportType type, Reports.Create parameters, Enums.ApiVersion? apiVersion = null)
    {
        return await service.Create(type.ToString()!, parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Retrieve the next page of a <see cref="EasyPost.Models.API.ReportCollection"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.ReportService"/> to use for the API call.</param>
    /// <param name="collection">The <see cref="EasyPost.Models.API.ReportCollection"/> to iterate on.</param>
    /// <returns>A <see cref="EasyPost.Models.API.ReportCollection"/> object.</returns>
    public static async Task<ReportCollection> GetNextPage(this ReportService service, ReportCollection collection)
    {
        var reports = collection.Reports;

        var parameters = collection.BuildNextPageParameters<Parameters.V2.Reports.All, Report>(reports);

        // at this point, we know reports exists and is not empty
        var firstReport = reports!.First();
        var reportType = Enums.ReportType.FromReport(firstReport);

        if (reportType == null)
        {
            throw new InvalidOperationException("Unable to determine report type.");
        }

        return await service.All(reportType.ToString()!, parameters);
    }
}
