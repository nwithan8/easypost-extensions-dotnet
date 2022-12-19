using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;

namespace EasyPost.Extensions.ModelMethodExtensions;

public static class OrderModelExtensions
{
    public static async Task<Order> Buy(this Order obj, Orders.Buy parameters, ApiVersion? apiVersion = null)
    {
        parameters.VerifyParameters();
        return await obj.Buy(parameters.Carrier!, parameters.Service!);
    }
}
