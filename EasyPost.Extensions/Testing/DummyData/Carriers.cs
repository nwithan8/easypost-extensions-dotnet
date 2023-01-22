namespace EasyPost.Extensions.Testing.DummyData;

/// <summary>
///     Functions for dummy carriers.
/// </summary>
public abstract class Carriers : DummyDataCreator
{
    private static string JsonFile => "assets/dummy_data/carriers.json";

    /// <summary>
    ///     Get a dummy carrier name.
    /// </summary>
    /// <returns>A dummy carrier name</returns>
    public static string GetCarrier()
    {
        var data = GetRandomItemsFromJsonFile(JsonFile, 1, true);
        return (data[0] as string)!;
    }
}
