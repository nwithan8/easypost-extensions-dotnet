using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;

namespace EasyPost.Extensions.ModelMethodExtensions;

/// <summary>
///     Extension methods for an <see cref="EasyPost.Models.API.Order"/>.
/// </summary>
public static class OrderModelExtensions
{
    /// <summary>
    ///     Buy an <see cref="EasyPost.Models.API.Order"/>.
    /// </summary>
    /// <param name="order">The <see cref="EasyPost.Models.API.Order"/> to buy.</param>
    /// <param name="parameters">The <see cref="Orders.Buy"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An updated <see cref="EasyPost.Models.API.Order"/> object.</returns>
    public static async Task<Order> Buy(this Order order, Orders.Buy parameters, ApiVersion? apiVersion = null)
    {
        parameters.Validate();
        return await order.Buy(parameters.Carrier!, parameters.Service!);
    }
}
