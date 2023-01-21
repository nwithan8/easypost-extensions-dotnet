using EasyPost.Extensions.Internal;

namespace EasyPost.Extensions.Testing.DummyData;

public abstract class DummyDataCreator
{
    protected static List<Dictionary<string, object>> GetRandomMapsFromJsonFile(string filePath, int amount, bool allowDuplicates)
    {
        var data = JsonReader.ReadJsonFileJson(filePath);

        return Internal.Random.RandomItemsFromList(data, amount, allowDuplicates).Cast<Dictionary<string, object>>().ToList();
    }

    protected static List<object> GetRandomItemsFromJsonFile(string filePath, int amount, bool allowDuplicates)
    {
        var data = JsonReader.ReadJsonFileArray(filePath);
        return Internal.Random.RandomItemsFromList(data, amount, allowDuplicates);
    }
}
