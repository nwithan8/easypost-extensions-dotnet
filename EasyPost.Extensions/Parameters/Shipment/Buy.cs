using System.Diagnostics.CodeAnalysis;
using EasyPost.Models.API;

namespace EasyPost.Extensions.Parameters.Shipment
{
    /// <summary>
    ///     <a href="https://www.easypost.com/docs/api#buy-a-shipment">Parameters</a> for <see cref="EasyPost.Services.ShipmentService.Buy(string, Buy, System.Threading.CancellationToken)"/> API calls.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Buy : EasyPost.Parameters.Shipment.Buy
    {
        public Buy(Rate rate) : base(rate)
        {
        }

        public Buy(string rateId) : base(rateId)
        {
        }
    }
}
