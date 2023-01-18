using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.InsuranceService" /> class.
/// </summary>
public static class InsuranceServiceExtensions
{
    /// <summary>
    ///     List all <see cref="EasyPost.Models.API.Insurance"/>s.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.InsuranceService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Parameters.V2.Insurance.All"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An <see cref="EasyPost.Models.API.InsuranceCollection"/> object.</returns>
    public static async Task<InsuranceCollection> All(this InsuranceService service, Parameters.V2.Insurance.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Create <see cref="EasyPost.Models.API.Insurance"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.InsuranceService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Parameters.V2.Insurance.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An <see cref="EasyPost.Models.API.Insurance"/> object.</returns>
    public static async Task<Insurance> Create(this InsuranceService service, Parameters.V2.Insurance.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }
}
