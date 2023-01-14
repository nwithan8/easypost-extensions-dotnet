using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.BatchService" /> class.
/// </summary>
public static class BatchServiceExtensions
{
    /// <summary>
    ///     List all <see cref="EasyPost.Models.API.Batch"/>es.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.BatchService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Batches.All"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.BatchCollection"/> object.</returns>
    public static async Task<BatchCollection> All(this BatchService service, Batches.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Create a <see cref="EasyPost.Models.API.Batch"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.BatchService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Batches.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.Batch"/> object.</returns>
    public static async Task<EasyPost.Models.API.Batch> Create(this BatchService service, Batches.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Simultaneously create and buy a <see cref="EasyPost.Models.API.Batch"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.BatchService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Batches.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.Batch"/> object.</returns>
    public static async Task<Batch> CreateAndBuy(this BatchService service, Batches.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.CreateAndBuy(parameters.ToDictionary(apiVersion));
    }
}
