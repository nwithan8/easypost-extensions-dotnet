using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.OrderService" /> class.
/// </summary>
public static class OrderServiceExtensions
{
    /// <summary>
    ///     Create an <see cref="EasyPost.Models.API.Order"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.OrderService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Orders.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An <see cref="EasyPost.Models.API.Order"/> object.</returns>
    public static async Task<Order> Create(this OrderService service, Orders.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }
}
