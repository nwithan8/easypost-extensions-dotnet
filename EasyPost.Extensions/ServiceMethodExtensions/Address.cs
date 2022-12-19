using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

public static class AddressServiceExtensions
{
    public static async Task<AddressCollection> All(this AddressService service, Addresses.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    public static async Task<Address> Create(this AddressService service, Addresses.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }

    public static async Task<Address> CreateAndVerify(this AddressService service, Addresses.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.CreateAndVerify(parameters.ToDictionary(apiVersion));
    }
}
