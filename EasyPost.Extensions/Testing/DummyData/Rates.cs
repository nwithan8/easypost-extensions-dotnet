using EasyPost.Models.API;
using EasyPost.Extensions.ServiceMethodExtensions;

namespace EasyPost.Extensions.Testing.DummyData;

/// <summary>
///     Functions for dummy <see cref="Rate"/>s.
/// </summary>
public abstract class Rates : DummyDataCreator
{
    /// <summary>
    ///     Create a list of dummy <see cref="Rate"/>s.
    /// </summary>
    /// <param name="client">The <see cref="EasyPost.Client"/> to make the API call with.</param>
    /// <returns>A list of <see cref="Rate"/> objects.</returns>
    public static async Task<List<Rate>> CreateRates(Client client)
    {
        // Get a shipment (shipping inside state lines)
        var shipment = await Shipments.CreateShipment(client);

        shipment = await client.Shipment.RegenerateRates(shipment.Id!);

        return shipment.Rates!;
    }
}
