using EasyPost.Models.API;
using EasyPost.Extensions.ServiceMethodExtensions;

namespace EasyPost.Extensions.Testing.DummyData;

/// <summary>
///     Functions for dummy <see cref="Shipment"/>s.
/// </summary>
public abstract class Shipments : DummyDataCreator
{
    /// <summary>
    ///     Create a dummy <see cref="Shipment"/>.
    /// </summary>
    /// <param name="client">The <see cref="EasyPost.Client"/> to make the API call with.</param>
    /// <param name="differentStates">Optional whether the two addresses should be in different states.
    ///     True will use two different states (including possibly an international pair), false will use the same state for both addresses. Defaults to false.
    /// </param>
    /// <returns>A <see cref="Shipment"/> object.</returns>
    public static async Task<Shipment> CreateShipment(Client client, bool? differentStates = false)
    {
        // Get two addresses, one for to and one for from
        var addresses = await Addresses.CreateAddressPair(client, differentStates);
        // Get a parcel
        var parcel = await Parcels.CreateParcel(client);

        var parameters = new EasyPost.Parameters.Shipment.Create
        {
            ToAddress = addresses[0],
            FromAddress = addresses[1],
            Parcel = parcel,
        };

        return await client.Shipment.Create(parameters);
    }
}
