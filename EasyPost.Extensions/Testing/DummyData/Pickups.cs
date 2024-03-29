using EasyPost.Extensions.Utilities;
using EasyPost.Models.API;

namespace EasyPost.Extensions.Testing.DummyData;

/// <summary>
///     Functions for dummy <see cref="Pickup"/>s.
/// </summary>
public abstract class Pickups : DummyDataCreator
{
    /// <summary>
    ///     Create a dummy <see cref="Pickup"/>.
    /// </summary>
    /// <param name="client">The <see cref="EasyPost.Client"/> to make the API call with.</param>
    /// <returns>A <see cref="Pickup"/> object.</returns>
    public static async Task<Pickup> CreatePickup(Client client)
    {
        var shipment = await Shipments.CreateShipment(client);
        var time = DateTime.Now;

        var parameters = new EasyPost.Parameters.Pickup.Create
        {
            Address = shipment.ToAddress,
            Shipment = shipment,
            MinDatetime = time.ToEasyPostDateString(),
            MaxDatetime = time.AddDays(3).ToEasyPostDateString(),
            Instructions = "Please leave on the porch.",
        };

        return await client.Pickup.Create(parameters);
    }
}
