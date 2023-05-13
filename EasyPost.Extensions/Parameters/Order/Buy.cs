using System.Diagnostics.CodeAnalysis;
using EasyPost.Models.API;

namespace EasyPost.Extensions.Parameters.Order
{
    /// <summary>
    ///     <a href="https://www.easypost.com/docs/api#buy-an-order">Parameters</a> for <see cref="EasyPost.Services.OrderService.Buy(string, Buy, System.Threading.CancellationToken)"/> API calls.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Buy : EasyPost.Parameters.Order.Buy
    {
        public Buy(string withCarrier, string withService) : base(withCarrier, withService)
        {
        }

        public Buy(Rate rate) : base(rate)
        {
        }
    }
}
