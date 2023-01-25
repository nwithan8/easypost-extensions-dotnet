using EasyPost.Extensions.ModelMethodExtensions;
using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.ShipmentService" /> class.
/// </summary>
public static class ShipmentServiceExtensions
{
    /// <summary>
    ///     List all <see cref="EasyPost.Models.API.Shipment"/>s.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.ShipmentService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Shipments.All"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.ShipmentCollection"/> object.</returns>
    public static async Task<ShipmentCollection> All(this ShipmentService service, Shipments.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Create a <see cref="EasyPost.Models.API.Shipment"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.ShipmentService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Shipments.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.Shipment"/> object.</returns>
    public static async Task<Shipment> Create(this ShipmentService service, Shipments.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion)); // don't need to split out carbon_offset, will be set properly by dictionary
    }
    
    /// <summary>
    ///     Create and buy a <see cref="EasyPost.Models.API.Shipment"/> in one API call.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.ShipmentService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Shipments.OneCallBuy"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.Shipment"/> object.</returns>
    public static async Task<Shipment> OneCallBuy(this ShipmentService service, Shipments.OneCallBuy parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion)); // don't need to split out carbon_offset, will be set properly by dictionary
    }

    /// <summary>
    ///     Return a <see cref="EasyPost.Models.API.Shipment"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.ShipmentService"/> to use for the API call.</param>
    /// <param name="shipment">The <see cref="EasyPost.Models.API.Shipment"/> to return.</param>
    /// <param name="to">Optional <see cref="EasyPost.Models.API.Address"/> to return shipment to. If not provided, uses shipment's return address or original from address.</param>
    /// <param name="from">Optional <see cref="EasyPost.Models.API.Address"/> to return shipment from. If not provided, uses shipment's buyer address or original to address.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.Shipment"/> object.</returns>
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
    
    /// <summary>
    ///     Retrieve the next page of a <see cref="EasyPost.Models.API.ShipmentCollection"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.ShipmentService"/> to use for the API call.</param>
    /// <param name="collection">The <see cref="EasyPost.Models.API.ShipmentCollection"/> to iterate on.</param>
    /// <returns>A <see cref="EasyPost.Models.API.ShipmentCollection"/> object.</returns>
    public static async Task<ShipmentCollection> GetNextPage(this ShipmentService service, ShipmentCollection collection)
    {
        var shipments = collection.Shipments;

        var parameters = collection.BuildNextPageParameters<Parameters.V2.Shipments.All, Shipment>(shipments);

        return await service.All(parameters);
    }
}
