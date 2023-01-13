using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

public static class ShipmentServiceExtensions
{
    /// <summary>
    ///     Get all shipments.
    /// </summary>
    /// <param name="service"><see cref="ShipmentService"/> to make API call against.</param>
    /// <param name="parameters"><see cref="Shipments.All"/> parameters to retrieve all shipments.</param>
    /// <param name="apiVersion">Override <see cref="ApiVersion"/> used for parameter validation.</param>
    /// <returns>A <see cref="ShipmentCollection"/> object.</returns>
    public static async Task<ShipmentCollection> All(this ShipmentService service, Shipments.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Create a shipment.
    /// </summary>
    /// <param name="service"><see cref="ShipmentService"/> to make API call against.</param>
    /// <param name="parameters"><see cref="Shipments.Create"/> parameters to create the shipment.</param>
    /// <param name="apiVersion">Override <see cref="ApiVersion"/> used for parameter validation.</param>
    /// <returns>A <see cref="Shipment"/> object.</returns>
    public static async Task<Shipment> Create(this ShipmentService service, Shipments.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion)); // don't need to split out carbon_offset, will be set properly by dictionary
    }
    
    /// <summary>
    ///     Return a shipment.
    /// </summary>
    /// <param name="service"><see cref="ShipmentService"/> to make API against.</param>
    /// <param name="shipment"><see cref="Shipment"/> to return.</param>
    /// <param name="to">Optional <see cref="Address"/> to return shipment to. If not provided, uses shipment's return address or original from address.</param>
    /// <param name="from">Optional <see cref="Address"/> to return shipment from. If not provided, uses shipment's buyer address or original to address.</param>
    /// <param name="apiVersion">Override <see cref="ApiVersion"/> used for parameter validation.</param>
    /// <returns>A <see cref="Shipment"/> object.</returns>
    public static async Task<Shipment> Return(this ShipmentService service, Shipment shipment, Address? to = null, Address? from = null, ApiVersion? apiVersion = null)
    {
        var parameters = new Shipments.Create
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

        return await service.Create(parameters, apiVersion);
    }
}
