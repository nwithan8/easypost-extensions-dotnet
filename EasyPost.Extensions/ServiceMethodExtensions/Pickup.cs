using EasyPost.Extensions.Parameters;
using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.PickupService" /> class.
/// </summary>
public static class PickupServiceExtensions
{
    /// <summary>
    ///     Create a <see cref="EasyPost.Models.API.Pickup"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.PickupService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Pickups.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.Pickup"/> object.</returns>
    public static async Task<Pickup> Create(this PickupService service, Pickups.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }
    
    /// <summary>
    ///     List all <see cref="EasyPost.Models.API.Pickup"/>s.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.PickupService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Pickups.All"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.PickupCollection"/> object.</returns>
    public static async Task<PickupCollection> All(this PickupService service, Pickups.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }
}
