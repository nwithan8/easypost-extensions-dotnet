using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.CustomsInfoService" /> class.
/// </summary>
public static class CustomsInfoServiceExtensions
{
    /// <summary>
    ///     Create a <see cref="EasyPost.Models.API.CustomsInfo"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.CustomsInfoService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Parameters.V2.CustomsInfo.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="Enums.ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.CustomsInfo"/> object.</returns>
    public static async Task<CustomsInfo> Create(this CustomsInfoService service, Parameters.V2.CustomsInfo.Create parameters, Enums.ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }
}
