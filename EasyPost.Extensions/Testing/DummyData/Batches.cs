using EasyPost.Models.API;
using EasyPost.Extensions.ServiceMethodExtensions;

namespace EasyPost.Extensions.Testing.DummyData;

/// <summary>
///     Functions for dummy <see cref="Batch"/>es.
/// </summary>
public abstract class Batches : DummyDataCreator
{
    private static string JsonFile => "assets/dummy_data/trackers.json";

    /// <summary>
    ///     Create a dummy <see cref="Batch"/>.
    /// </summary>
    /// <param name="client">The <see cref="EasyPost.Client"/> to make the API call with.</param>
    /// <returns>A <see cref="Batch"/> object.</returns>
    public static async Task<Batch> CreateBatch(Client client)
    {
        var numberOfShipments = Internal.Random.RandomIntInRange(1, 5);

        // Create a list of shipments
        var shipments = new List<Shipment>();
        for (var i = 0; i < numberOfShipments; i++)
        {
            var shipment = await Shipments.CreateShipment(client);
            shipments.Add(shipment);
        }
        
        var parameters = new EasyPost.Parameters.Batch.Create
        {
            Shipments = shipments, // TODO: Something weird here
        };

        return await client.Batch.Create(parameters);
    }
}
