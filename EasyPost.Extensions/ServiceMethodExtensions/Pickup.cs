using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

public static class PickupServiceExtensions
{
    public static async Task<Pickup> Create(this PickupService service, Pickups.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }
}
