using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Models.API.Beta;
using EasyPost.Services;
using EasyPost.Services.Beta;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.PartnerService" /> class.
/// </summary>
public static class PartnerServiceExtensions
{
    /// <summary>
    ///     List all <see cref="EasyPost.Models.API.ReferralCustomer"/>s.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.PartnerService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="ReferralCustomers.All"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.ReferralCustomerCollection"/> object.</returns>
    public static async Task<ReferralCustomerCollection> All(this PartnerService service, ReferralCustomers.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Create a <see cref="EasyPost.Models.API.ReferralCustomer"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.PartnerService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="ReferralCustomers.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.ReferralCustomer"/> object.</returns>
    public static async Task<ReferralCustomer> Create(this PartnerService service, ReferralCustomers.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.CreateReferral(parameters.ToDictionary(apiVersion));
    }
}
