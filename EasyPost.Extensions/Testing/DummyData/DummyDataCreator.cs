using EasyPost.Extensions.Internal;

namespace EasyPost.Extensions.Testing.DummyData;

public abstract class DummyDataCreator
{
    protected abstract string JsonFile { get; }

    protected List<Dictionary<string, object>> GetRandomMapsFromJsonFile(int amount, bool allowDuplicates)
    {
        var data = JsonReader.ReadJsonFileJson(JsonFile);

        return Internal.Random.RandomItemsFromList(data, amount, allowDuplicates).Cast<Dictionary<string, object>>().ToList();
    }

    protected List<object> GetRandomItemsFromJsonFile(int amount, bool allowDuplicates)
    {
        var data = JsonReader.ReadJsonFileArray(JsonFile);
        return Internal.Random.RandomItemsFromList(data, amount, allowDuplicates);
    }
}
