using EasyPost.Extensions.Parameters;
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
    /// <param name="type">The <see cref="ReportType"/> to retrieve.</param>
    /// <param name="parameters">The <see cref="Reports.All"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.RefundCollection"/> object.</returns>
    public static async Task<ReportCollection> All(this ReportService service, ReportType type, Reports.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(type.ToString()!, parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Create a <see cref="EasyPost.Models.API.Report"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.ReportService"/> to use for the API call.</param>
    /// <param name="type">The <see cref="ReportType"/> to create.</param>
    /// <param name="parameters">The <see cref="Reports.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.Report"/> object.</returns>
    public static async Task<Report> Create(this ReportService service, ReportType type, Reports.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(type.ToString()!, parameters.ToDictionary(apiVersion));
    }
}
