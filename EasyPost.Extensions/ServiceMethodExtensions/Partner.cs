using EasyPost.Extensions.ModelMethodExtensions;
using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;
using EasyPost.Services;

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
    
    /// <summary>
    ///     Retrieve the next page of an <see cref="EasyPost.Models.API.ReferralCustomerCollection"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.PartnerService"/> to use for the API call.</param>
    /// <param name="collection">The <see cref="EasyPost.Models.API.ReferralCustomerCollection"/> to iterate on.</param>
    /// <returns>An <see cref="EasyPost.Models.API.ReferralCustomerCollection"/> object.</returns>
    public static async Task<ReferralCustomerCollection> GetNextPage(this PartnerService service, ReferralCustomerCollection collection)
    {
        var shipments = collection.ReferralCustomers;

        var parameters = collection.BuildNextPageParameters<Parameters.V2.ReferralCustomers.All, ReferralCustomer>(shipments);

        return await service.All(parameters);
    }
}
