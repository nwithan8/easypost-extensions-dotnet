using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

public static class OrderServiceExtensions
{
    public static async Task<Order> Create(this OrderService service, Orders.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }
}
