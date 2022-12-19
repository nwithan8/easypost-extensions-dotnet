using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

public static class ReportServiceExtensions
{
    public static async Task<ReportCollection> All(this ReportService service, string type, Reports.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(type, parameters.ToDictionary(apiVersion));
    }

    public static async Task<Report> Create(this ReportService service, string type, Reports.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(type, parameters.ToDictionary(apiVersion));
    }
}
