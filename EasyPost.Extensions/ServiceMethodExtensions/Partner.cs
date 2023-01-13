using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Models.API.Beta;
using EasyPost.Services;
using EasyPost.Services.Beta;

namespace EasyPost.Extensions.ServiceMethodExtensions;

public static class PartnerServiceExtensions
{
    public static async Task<ReferralCustomerCollection> All(this PartnerService service, ReferralCustomers.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    public static async Task<ReferralCustomer> Create(this PartnerService service, ReferralCustomers.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.CreateReferral(parameters.ToDictionary(apiVersion));
    }
}
