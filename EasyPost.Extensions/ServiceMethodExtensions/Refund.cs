using System.Collections.Generic;
using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Models.API.Beta;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.RefundService" /> class.
/// </summary>
public static class RefundServiceExtensions
{
    /// <summary>
    ///     List all <see cref="EasyPost.Models.API.Refund"/>s.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.RefundService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Refunds.All"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.RefundCollection"/> object.</returns>
    public static async Task<RefundCollection> All(this RefundService service, Refunds.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Create <see cref="EasyPost.Models.API.Refund"/>s.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.RefundService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Refunds.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A list of <see cref="EasyPost.Models.API.Refund"/> objects.</returns>
    public static async Task<List<Refund>> Create(this RefundService service, Refunds.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }
}
