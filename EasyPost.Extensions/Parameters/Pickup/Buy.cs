using System.Diagnostics.CodeAnalysis;
using EasyPost.Models.API;

namespace EasyPost.Extensions.Parameters.Pickup
{
    /// <summary>
    ///     <a href="https://www.easypost.com/docs/api#buy-a-pickup">Parameters</a> for <see cref="EasyPost.Services.PickupService.Buy(string, Buy, System.Threading.CancellationToken)"/> API calls.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Buy : EasyPost.Parameters.Pickup.Buy
    {
        public Buy(string withCarrier, string withService) : base(withCarrier, withService)
        {
        }

        public Buy(Rate rate) : base(rate)
        {
        }
    }
}
