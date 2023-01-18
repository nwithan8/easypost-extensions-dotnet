using EasyPost.Extensions.Parameters;
using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.CarrierAccountService" /> class.
/// </summary>
public static class CarrierAccountServiceExtensions
{
    /// <summary>
    ///     Create a <see cref="EasyPost.Models.API.CarrierAccount"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.CarrierAccountService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="CarrierAccounts.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.CarrierAccount"/> object.</returns>
    public static async Task<CarrierAccount> Create(this CarrierAccountService service, CarrierAccounts.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Create a <see cref="EasyPost.Models.API.CarrierAccount"/> tied to a FedEx account.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.CarrierAccountService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="CarrierAccounts.CreateFedEx"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.CarrierAccount"/> object.</returns>
    public static async Task<CarrierAccount> Create(this CarrierAccountService service, CarrierAccounts.CreateFedEx parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Create a <see cref="EasyPost.Models.API.CarrierAccount"/> tied to a UPS account.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.CarrierAccountService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="CarrierAccounts.CreateUps"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.CarrierAccount"/> object.</returns>
    public static async Task<CarrierAccount> Create(this CarrierAccountService service, CarrierAccounts.CreateUps parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Create a <see cref="EasyPost.Models.API.CarrierAccount"/> tied to a FedEx account.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.CarrierAccountService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="CarrierAccounts.CreateFedEx"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.CarrierAccount"/> object.</returns>
    public static async Task<CarrierAccount> CreateFedEx(this CarrierAccountService service, CarrierAccounts.CreateFedEx parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Create a <see cref="EasyPost.Models.API.CarrierAccount"/> tied to a UPS account.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.CarrierAccountService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="CarrierAccounts.CreateUps"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.CarrierAccount"/> object.</returns>
    public static async Task<CarrierAccount> CreateUps(this CarrierAccountService service, CarrierAccounts.CreateUps parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }
}
