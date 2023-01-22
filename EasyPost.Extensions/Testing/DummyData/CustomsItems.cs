using EasyPost.Models.API;

namespace EasyPost.Extensions.Testing.DummyData;

/// <summary>
///     Functions for dummy <see cref="CustomsItem"/>s.
/// </summary>
public abstract class CustomsItems : DummyDataCreator
{
    private static string JsonFile => "assets/dummy_data/customs_items.json";
    
    /// <summary>
    ///     Get a list of random <see cref="CustomsItem"/> data.
    /// </summary>
    /// <param name="count">How many elements to retrieve from JSON.</param>
    /// <returns>A list of <see cref="Dictionary{TKey,TValue}"/>s representing <see cref="CustomsItem"/> parameters.</returns>
    internal static List<Dictionary<string, object>> GetCustomsItemsData(int count = 1)
    {
        return GetRandomMapsFromJsonFile(JsonFile, count, true);
    }

    /// <summary>
    ///     Create a dummy <see cref="CustomsItem"/>.
    /// </summary>
    /// <param name="client">The <see cref="EasyPost.Client"/> to make the API call with.</param>
    /// <returns>A <see cref="CustomsItem"/> object.</returns>
    public static async Task<CustomsItem> CreateCustomsItem(Client client)
    {
        var data = GetCustomsItemsData(1);
        var customsItemData = data[0];
        
        return await client.CustomsItem.Create(customsItemData);
    }
}
