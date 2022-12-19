using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

public static class ScanFormServiceExtensions
{
    public static async Task<ScanFormCollection> All(this ScanFormService service, ScanForms.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    public static async Task<ScanForm> Create(this ScanFormService service, ScanForms.Create parameters, ApiVersion? apiVersion = null)
    {
        parameters.VerifyParameters();
        return await service.Create(parameters.Shipments!);
    }
}
