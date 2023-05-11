using EasyPost.Models.API.Beta;
using EasyPost.Services.Beta;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.ReferralCustomerService" /> class.
/// </summary>
public static class ReferralCustomerServiceExtensions
{
    /// <summary>
    ///     Refund a <see cref="EasyPost.Models.API.ReferralCustomer"/>'s wallet.
    ///     Refund will be issued to the user's original payment method.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.ReferralCustomerService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="EasyPost.Extensions.Parameters.Billing.Refund"/> parameters to use for the API call.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/> to use for the HTTP request.</param>
    /// <returns>A <see cref="EasyPost.Models.API.Beta.PaymentRefund"/> object.</returns>
    /// <exception cref="ArgumentException">Thrown if a required parameter is missing.</exception>
    public static async Task<PaymentRefund> Refund(this ReferralCustomerService service, EasyPost.Extensions.Parameters.Billing.Refund parameters, CancellationToken cancellationToken = default)
    {
        // Use Amount if provided
        if (parameters.Amount != null)
        {
            return await service.RefundByAmount((int)parameters.Amount!, cancellationToken);
        }

        // Use PaymentId if provided
        if (parameters.PaymentLogId != null)
        {
            return await service.RefundByPaymentLog(parameters.PaymentLogId!, cancellationToken);
        }

        throw new ArgumentException($"Either {nameof(parameters.Amount)} or {nameof(parameters.PaymentLogId)} must be provided.");
    }
}
