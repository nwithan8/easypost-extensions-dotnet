using EasyPost.Models.API;

namespace EasyPost.Extensions.Testing.DummyData;

public sealed class Trackers : DummyDataCreator
{
    protected override string JsonFile => "assets/dummy_data/trackers.json";

    public async Task<Tracker> CreateTracker(Client client)
    {
        var data = GetRandomMapsFromJsonFile(1, true);
        var trackerData = data[0];
        
        // THIS IS SO INCONSISTENT, DICTIONARY VS EXPLICIT PARAMS
        var code = trackerData["tracking_code"] as string;
        var carrier = trackerData["carrier"] as string;

        return await client.Tracker.Create(carrier, code);
    }
}
