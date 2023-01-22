using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.CustomsItemService" /> class.
/// </summary>
public static class CustomsItemServiceExtensions
{
    /// <summary>
    ///     Create a <see cref="EasyPost.Models.API.CustomsItem"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.CustomsItemService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="CustomsItems.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.CustomsItem"/> object.</returns>
    public static async Task<CustomsItem> Create(this CustomsItemService service, CustomsItems.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }
}
