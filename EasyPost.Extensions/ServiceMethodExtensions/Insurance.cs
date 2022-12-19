using System.Threading.Tasks;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

public static class InsuranceServiceExtensions
{
    public static async Task<InsuranceCollection> All(this InsuranceService service, Parameters.Insurance.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    public static async Task<Insurance> Create(this InsuranceService service, Parameters.Insurance.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }
}
