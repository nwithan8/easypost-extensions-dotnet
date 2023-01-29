using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;

namespace EasyPost.Extensions.ModelMethodExtensions;

/// <summary>
///     Extension methods for an <see cref="EasyPost.Models.API.EndShipper"/>.
/// </summary>
public static class EndShipperModelExtensions
{
    /// <summary>
    ///     Update an <see cref="EasyPost.Models.API.EndShipper"/>.
    /// </summary>
    /// <param name="endShipper">The <see cref="EasyPost.Models.API.EndShipper"/> to update.</param>
    /// <param name="parameters">The <see cref="EndShippers.Update"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="Enums.ApiVersion"/> to target.</param>
    /// <returns>An updated <see cref="EasyPost.Models.API.EndShipper"/> object.</returns>
    public static async Task<EndShipper> Update(this EndShipper endShipper, EndShippers.Update parameters, Enums.ApiVersion? apiVersion = null)
    {
        return await endShipper.Update(parameters.ToDictionary(apiVersion));
    }
}

/// <summary>
///     Extension methods for an <see cref="EasyPost.Models.API.EndShipperCollection"/>.
/// </summary>
public static class EndShipperCollectionModelExtensions
{}
