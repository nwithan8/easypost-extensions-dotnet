using EasyPost.Models.API;

namespace EasyPost.Extensions.Testing.DummyData;

/// <summary>
///     Functions for dummy <see cref="Smartrate"/>s.
/// </summary>
public abstract class SmartRates : DummyDataCreator
{
    /// <summary>
    ///     Create a list of dummy <see cref="Smartrate"/>s.
    /// </summary>
    /// <param name="client">The <see cref="EasyPost.Client"/> to make the API call with.</param>
    /// <returns>A list of <see cref="Smartrate"/> objects.</returns>
    public static async Task<List<SmartRate>> CreateSmartRates(Client client)
    {
        // Get a shipment (shipping inside state lines)
        var shipment = await Shipments.CreateShipment(client);

        return await client.Shipment.GetSmartRates(shipment.Id!);
    }
}
