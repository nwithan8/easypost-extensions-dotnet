using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.ScanFormService" /> class.
/// </summary>
public static class ScanFormServiceExtensions
{
    /// <summary>
    ///     List all <see cref="EasyPost.Models.API.ScanForm"/>s.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.ScanFormService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="ScanForms.All"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.ScanFormCollection"/> object.</returns>
    public static async Task<ScanFormCollection> All(this ScanFormService service, ScanForms.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Create a <see cref="EasyPost.Models.API.ScanForm"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.ScanFormService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="ScanForms.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.ScanForm"/> object.</returns>
    public static async Task<ScanForm> Create(this ScanFormService service, ScanForms.Create parameters, ApiVersion? apiVersion = null)
    {
        parameters.VerifyParameters();
        return await service.Create(parameters.Shipments!);
    }
}
