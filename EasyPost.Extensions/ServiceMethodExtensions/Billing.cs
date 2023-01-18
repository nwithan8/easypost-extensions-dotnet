using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.BillingService" /> class.
/// </summary>
public static class BillingServiceExtensions
{
    /// <summary>
    ///     Fund your wallet from a specific payment method.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.BillingService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Billing.Fund"/> parameters to use for the API call.</param>
    /// <param name="priority">The <see cref="EasyPost.Models.API.PaymentMethod.Priority"/> to pull funds from.</param>
    /// <returns>None</returns>
    public static async Task FundWallet(this BillingService service, Billing.Fund parameters, PaymentMethod.Priority? priority = null)
    {
        parameters.Validate(); // Verify that the parameters are valid before we pass them to the service
        await service.FundWallet(parameters.Amount!, priority);
    }
}
