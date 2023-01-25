using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;

namespace EasyPost.Extensions.ModelMethodExtensions;

/// <summary>
///     Extension methods for a <see cref="EasyPost.Models.API.Pickup"/>.
/// </summary>
public static class PickupModelExtensions
{
    /// <summary>
    ///     Buy a <see cref="EasyPost.Models.API.Pickup"/>.
    /// </summary>
    /// <param name="pickup">The <see cref="EasyPost.Models.API.Pickup"/> to buy.</param>
    /// <param name="parameters">The <see cref="CarrierAccounts.Update"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An updated <see cref="EasyPost.Models.API.Pickup"/> object.</returns>
    public static async Task<Pickup> Buy(this Pickup pickup, Pickups.Buy parameters, ApiVersion? apiVersion = null)
    {
        parameters.Validate();
        return await pickup.Buy(parameters.Carrier!, parameters.Service!);
    }
}
