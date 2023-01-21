using EasyPost.Models.API;

namespace EasyPost.Extensions.Testing.DummyData;

public abstract class Trackers : DummyDataCreator
{
    private static string JsonFile => "assets/dummy_data/trackers.json";

    /// <summary>
    ///     Create a dummy <see cref="Tracker"/>.
    /// </summary>
    /// <param name="client">The <see cref="EasyPost.Client"/> to make the API call with.</param>
    /// <returns>A <see cref="Tracker"/> object.</returns>
    public static async Task<Tracker> CreateTracker(Client client)
    {
        var data = GetRandomMapsFromJsonFile(JsonFile, 1, true);
        var trackerData = data[0];
        
        // THIS IS SO INCONSISTENT, DICTIONARY VS EXPLICIT PARAMS
        var code = trackerData["tracking_code"] as string;
        var carrier = trackerData["carrier"] as string;

        return await client.Tracker.Create(carrier, code);
    }
}
