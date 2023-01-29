using EasyPost.Extensions.ModelMethodExtensions;
using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;
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
    /// <param name="apiVersion">The <see cref="Enums.ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.RefundCollection"/> object.</returns>
    public static async Task<RefundCollection> All(this RefundService service, Refunds.All parameters, Enums.ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Create <see cref="EasyPost.Models.API.Refund"/>s.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.RefundService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Refunds.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="Enums.ApiVersion"/> to target.</param>
    /// <returns>A list of <see cref="EasyPost.Models.API.Refund"/> objects.</returns>
    public static async Task<List<Refund>> Create(this RefundService service, Refunds.Create parameters, Enums.ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }
    
    /// <summary>
    ///     Retrieve the next page of a <see cref="EasyPost.Models.API.RefundCollection"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.RefundService"/> to use for the API call.</param>
    /// <param name="collection">The <see cref="EasyPost.Models.API.RefundCollection"/> to iterate on.</param>
    /// <returns>An <see cref="EasyPost.Models.API.RefundCollection"/> object.</returns>
    public static async Task<RefundCollection> GetNextPage(this RefundService service, RefundCollection collection)
    {
        var shipments = collection.Refunds;

        var parameters = collection.BuildNextPageParameters<Parameters.V2.Refunds.All, Refund>(shipments);

        return await service.All(parameters);
    }
}
