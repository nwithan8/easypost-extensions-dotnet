using EasyPost.Extensions.ModelMethodExtensions;
using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.EndShipperService" /> class.
/// </summary>
public static class EndShipperServiceExtensions
{
    /// <summary>
    ///     List all <see cref="EasyPost.Models.API.EndShipper"/>s.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.EndShipperService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="EndShippers.All"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An <see cref="EasyPost.Models.API.EndShipperCollection"/> object.</returns>
    public static async Task<EndShipperCollection> All(this EndShipperService service, EndShippers.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Create an <see cref="EasyPost.Models.API.EndShipper"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.EndShipperService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="EndShippers.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An <see cref="EasyPost.Models.API.EndShipper"/> object.</returns>
    public static async Task<EndShipper> Create(this EndShipperService service, EndShippers.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }
    
    /// <summary>
    ///     Retrieve the next page of an <see cref="EasyPost.Models.API.EndShipperCollection"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.EndShipperService"/> to use for the API call.</param>
    /// <param name="collection">The <see cref="EasyPost.Models.API.EndShipperCollection"/> to iterate on.</param>
    /// <returns>An <see cref="EasyPost.Models.API.EndShipperCollection"/> object.</returns>
    public static async Task<EndShipperCollection> GetNextPage(this EndShipperService service, EndShipperCollection collection)
    {
        var endShippers = collection.EndShippers;

        var parameters = collection.BuildNextPageParameters<Parameters.V2.EndShippers.All, EndShipper>(endShippers);

        return await service.All(parameters);
    }
}
