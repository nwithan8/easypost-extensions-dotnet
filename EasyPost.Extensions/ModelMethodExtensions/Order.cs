using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;

namespace EasyPost.Extensions.ModelMethodExtensions;

public static class OrderModelExtensions
{
    public static async Task<Order> Buy(this Order obj, Orders.Buy parameters, ApiVersion? apiVersion = null)
    {
        parameters.Validate();
        return await obj.Buy(parameters.Carrier!, parameters.Service!);
    }
}
