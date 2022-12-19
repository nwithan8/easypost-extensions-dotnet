using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

public static class CarrierAccountServiceExtensions
{
    public static async Task<CarrierAccount> Create(this CarrierAccountService service, CarrierAccounts.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }

    public static async Task<CarrierAccount> Create(this CarrierAccountService service, CarrierAccounts.CreateFedEx parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }

    public static async Task<CarrierAccount> Create(this CarrierAccountService service, CarrierAccounts.CreateUps parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }

    public static async Task<CarrierAccount> CreateFedEx(this CarrierAccountService service, CarrierAccounts.CreateFedEx parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }

    public static async Task<CarrierAccount> CreateUps(this CarrierAccountService service, CarrierAccounts.CreateUps parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }
}
