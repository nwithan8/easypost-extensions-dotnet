using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

public static class ParcelServiceExtensions
{
    public static async Task<Parcel> Create(this ParcelService service, Parcels.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }
}
