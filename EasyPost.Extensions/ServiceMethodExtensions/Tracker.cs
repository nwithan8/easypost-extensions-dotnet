using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

public static class TrackerServiceExtensions
{
    public static async Task<TrackerCollection> All(this TrackerService service, Trackers.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    public static async Task<Tracker> Create(this TrackerService service, Trackers.Create parameters, ApiVersion? apiVersion = null)
    {
        parameters.VerifyParameters();
        return await service.Create(parameters.Carrier!, parameters.TrackingCode!);
    }

    public static async Task CreateList(this TrackerService service, Trackers.CreateList parameters, ApiVersion? apiVersion = null)
    {
        await service.CreateList(parameters.ToDictionary(apiVersion));
    }
}
