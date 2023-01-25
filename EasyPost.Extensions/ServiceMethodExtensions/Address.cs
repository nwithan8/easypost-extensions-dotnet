using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;
using EasyPost.Services;
using EasyPost.Extensions.ModelMethodExtensions;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.AddressService" /> class.
/// </summary>
public static class AddressServiceExtensions
{
    /// <summary>
    ///     List all <see cref="EasyPost.Models.API.Address"/>es.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.AddressService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Addresses.All"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An <see cref="EasyPost.Models.API.AddressCollection"/> object.</returns>
    public static async Task<AddressCollection> All(this AddressService service, Addresses.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Create an <see cref="EasyPost.Models.API.Address"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.AddressService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Addresses.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An <see cref="EasyPost.Models.API.Address"/> object.</returns>
    public static async Task<Address> Create(this AddressService service, Addresses.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Simultaneously create and verify an <see cref="EasyPost.Models.API.Address"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.AddressService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Addresses.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An <see cref="EasyPost.Models.API.Address"/> object.</returns>
    public static async Task<Address> CreateAndVerify(this AddressService service, Addresses.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.CreateAndVerify(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Retrieve the next page of an <see cref="EasyPost.Models.API.AddressCollection"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.AddressService"/> to use for the API call.</param>
    /// <param name="collection">The <see cref="EasyPost.Models.API.AddressCollection"/> to iterate on.</param>
    /// <returns>An <see cref="EasyPost.Models.API.AddressCollection"/> object.</returns>
    public static async Task<AddressCollection> GetNextPage(this AddressService service, AddressCollection collection)
    {
        var addresses = collection.Addresses;

        var parameters = collection.BuildNextPageParameters<Addresses.All, Address>(addresses);

        return await service.All(parameters);
    }
}
