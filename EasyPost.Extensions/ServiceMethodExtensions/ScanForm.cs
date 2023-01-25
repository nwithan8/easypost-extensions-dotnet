using EasyPost.Extensions.ModelMethodExtensions;
using EasyPost.Extensions.Parameters.V2;
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
        parameters.Validate();
        return await service.Create(parameters.Shipments!);
    }
    
    /// <summary>
    ///     Retrieve the next page of a <see cref="EasyPost.Models.API.ScanFormCollection"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.ScanFormService"/> to use for the API call.</param>
    /// <param name="collection">The <see cref="EasyPost.Models.API.ScanFormCollection"/> to iterate on.</param>
    /// <returns>A <see cref="EasyPost.Models.API.ScanFormCollection"/> object.</returns>
    public static async Task<ScanFormCollection> GetNextPage(this ScanFormService service, ScanFormCollection collection)
    {
        var shipments = collection.ScanForms;

        var parameters = collection.BuildNextPageParameters<Parameters.V2.ScanForms.All, ScanForm>(shipments);

        return await service.All(parameters);
    }
}
