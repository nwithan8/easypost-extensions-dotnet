using EasyPost.Models.API;

namespace EasyPost.Extensions.Testing.DummyData;

/// <summary>
///     Functions for dummy <see cref="Tracker"/>s.
/// </summary>
public abstract class Trackers : DummyDataCreator
{
    /// <summary>
    ///     Create a dummy <see cref="Tracker"/>.
    /// </summary>
    /// <param name="client">The <see cref="EasyPost.Client"/> to make the API call with.</param>
    /// <returns>A <see cref="Tracker"/> object.</returns>
    public static async Task<Tracker> CreateTracker(Client client)
    {
        var carrier = Carriers.GetCarrier();
        var trackingCode = $"EZ{Internal.Random.RandomStringOfLength(12)}";

        return await client.Tracker.Create(carrier, trackingCode);
    }
}
