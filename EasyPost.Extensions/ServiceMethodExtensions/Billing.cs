using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

public static class BillingServiceExtensions
{
    public static async Task FundWallet(this BillingService service, Billing.Fund parameters, PaymentMethod.Priority? priority = null, ApiVersion? apiVersion = null)
    {
        parameters.VerifyParameters(); // Verify that the parameters are valid before we pass them to the service
        await service.FundWallet(parameters.Amount!, priority);
    }
}
