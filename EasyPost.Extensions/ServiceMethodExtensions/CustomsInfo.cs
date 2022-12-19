using System.Threading.Tasks;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

public static class CustomsInfoServiceExtensions
{
    public static async Task<CustomsInfo> Create(this CustomsInfoService service, Parameters.CustomsInfo.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }
}