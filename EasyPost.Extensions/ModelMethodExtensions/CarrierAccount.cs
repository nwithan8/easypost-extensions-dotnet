using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;

namespace EasyPost.Extensions.ModelMethodExtensions;

/// <summary>
///     Extension methods for a <see cref="EasyPost.Models.API.CarrierAccount"/>.
/// </summary>
public static class CarrierAccountModelExtensions
{
    /// <summary>
    ///     Update a <see cref="EasyPost.Models.API.CarrierAccount"/>.
    /// </summary>
    /// <param name="carrierAccount">The <see cref="EasyPost.Models.API.CarrierAccount"/> to update.</param>
    /// <param name="parameters">The <see cref="CarrierAccounts.Update"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="Enums.ApiVersion"/> to target.</param>
    /// <returns>An updated <see cref="EasyPost.Models.API.CarrierAccount"/> object.</returns>
    public static async Task<CarrierAccount> Update(this CarrierAccount carrierAccount, CarrierAccounts.Update parameters, Enums.ApiVersion? apiVersion = null)
    {
        return await carrierAccount.Update(parameters.ToDictionary(apiVersion));
    }
}
