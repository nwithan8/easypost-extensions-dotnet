using EasyPost.Models.API;
using EasyPost.Extensions.ServiceMethodExtensions;

namespace EasyPost.Extensions.Testing.DummyData;

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

        await shipment.RegenerateRates();

        return shipment.Rates!;
    }
}
