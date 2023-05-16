using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.ShipmentService" /> class.
/// </summary>
public static class ShipmentServiceExtensions
{
    /// <summary>
    ///     Return a <see cref="EasyPost.Models.API.Shipment"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.ShipmentService"/> to use for the API call.</param>
    /// <param name="shipment">The <see cref="EasyPost.Models.API.Shipment"/> to return.</param>
    /// <param name="to">Optional <see cref="EasyPost.Models.API.Address"/> to return shipment to. If not provided, uses shipment's return address or original from address.</param>
    /// <param name="from">Optional <see cref="EasyPost.Models.API.Address"/> to return shipment from. If not provided, uses shipment's buyer address or original to address.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/> to use for the HTTP request.</param>
    /// <returns>A <see cref="EasyPost.Models.API.Shipment"/> object.</returns>
    public static async Task<Shipment> Return(this ShipmentService service, Shipment shipment, Address? to = null, Address? from = null, CancellationToken cancellationToken = default)
    {
        var parameters = new EasyPost.Parameters.Shipment.Create
        {
            // Uses provided to address, otherwise specific return address if available, otherwise uses original from address
            ToAddress = to ?? shipment.ReturnAddress ?? shipment.FromAddress,
            // Uses provided from address, otherwise specific buyer address if available, otherwise uses original to address
            FromAddress = from ?? shipment.BuyerAddress ?? shipment.ToAddress,
            Parcel = shipment.Parcel,
            CustomsInfo = shipment.CustomsInfo,
            Options = shipment.Options,
            IsReturn = true,
        };

        return await service.Create(parameters, cancellationToken);
    }
}
