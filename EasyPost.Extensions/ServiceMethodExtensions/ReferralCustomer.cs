using EasyPost.Extensions.Parameters;
using EasyPost.Models.API.Beta;
using EasyPost.Services.Beta;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.Beta.ReferralService" /> class.
/// </summary>
public static class ReferralCustomerServiceExtensions
{
    /// <summary>
    ///     Refund a <see cref="EasyPost.Models.API.ReferralCustomer"/>'s wallet.
    ///     Refund will be issued to the user's original payment method.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.Beta.ReferralService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Billing.Refund"/> parameters to use for the API call.</param>
    /// <returns>A <see cref="EasyPost.Models.API.Beta.PaymentRefund"/> object.</returns>
    /// <exception cref="ArgumentException">Thrown if a required parameter is missing.</exception>
    public static async Task<PaymentRefund> Refund(this ReferralService service, Billing.Refund parameters)
    {
        // Use Amount if provided
        if (parameters.Amount != null)
        {
            return await service.RefundByAmount((int)parameters.Amount!);
        }

        // Use PaymentId if provided
        if (parameters.PaymentLogId != null)
        {
            return await service.RefundByPaymentLog(parameters.PaymentLogId!);
        }

        throw new ArgumentException($"Either {nameof(parameters.Amount)} or {nameof(parameters.PaymentLogId)} must be provided.");
    }
}
