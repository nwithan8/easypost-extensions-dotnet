using EasyPost.Extensions.Parameters;
using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.ParcelService" /> class.
/// </summary>
public static class ParcelServiceExtensions
{
    /// <summary>
    ///     Create a <see cref="EasyPost.Models.API.Parcel"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.ParcelService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Parcels.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.Parcel"/> object.</returns>
    public static async Task<Parcel> Create(this ParcelService service, Parcels.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }
}
