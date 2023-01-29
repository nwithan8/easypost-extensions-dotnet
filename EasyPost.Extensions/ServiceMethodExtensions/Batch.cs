using EasyPost.Extensions.ModelMethodExtensions;
using EasyPost.Extensions.Parameters.V2;
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
    /// <param name="apiVersion">The <see cref="Enums.ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.BatchCollection"/> object.</returns>
    public static async Task<BatchCollection> All(this BatchService service, Batches.All parameters, Enums.ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Create a <see cref="EasyPost.Models.API.Batch"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.BatchService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Batches.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="Enums.ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.Batch"/> object.</returns>
    public static async Task<EasyPost.Models.API.Batch> Create(this BatchService service, Batches.Create parameters, Enums.ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Simultaneously create and buy a <see cref="EasyPost.Models.API.Batch"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.BatchService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Batches.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="Enums.ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.Batch"/> object.</returns>
    public static async Task<Batch> CreateAndBuy(this BatchService service, Batches.Create parameters, Enums.ApiVersion? apiVersion = null)
    {
        return await service.CreateAndBuy(parameters.ToDictionary(apiVersion));
    }
    
    /// <summary>
    ///     Retrieve the next page of a <see cref="EasyPost.Models.API.BatchCollection"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.BatchService"/> to use for the API call.</param>
    /// <param name="collection">The <see cref="EasyPost.Models.API.BatchCollection"/> to iterate on.</param>
    /// <returns>A <see cref="EasyPost.Models.API.BatchCollection"/> object.</returns>
    public static async Task<BatchCollection> GetNextPage(this BatchService service, BatchCollection collection)
    {
        var batches = collection.Batches;

        var parameters = collection.BuildNextPageParameters<Parameters.V2.Batches.All, Batch>(batches);

        return await service.All(parameters);
    }
}
