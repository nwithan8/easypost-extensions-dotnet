using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

public static class ShipmentServiceExtensions
{
    public static async Task<ShipmentCollection> All(this ShipmentService service, Shipments.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    public static async Task<Shipment> Create(this ShipmentService service, Shipments.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion)); // don't need to split out carbon_offset, will be set properly by dictionary
    }
}
