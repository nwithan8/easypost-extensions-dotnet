using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

public static class BatchServiceExtensions
{
    public static async Task<BatchCollection> All(this BatchService service, Batches.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    public static async Task<Batch> Create(this BatchService service, Batches.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }

    public static async Task<Batch> CreateAndBuy(this BatchService service, Batches.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.CreateAndBuy(parameters.ToDictionary(apiVersion));
    }
}
