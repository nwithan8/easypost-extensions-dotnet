using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

public static class CustomsItemServiceExtensions
{
    public static async Task<CustomsItem> Create(this CustomsItemService service, CustomsItems.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }
}