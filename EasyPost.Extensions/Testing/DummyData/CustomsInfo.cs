namespace EasyPost.Extensions.Testing.DummyData;

/// <summary>
///     Functions for dummy <see cref="EasyPost.Models.API.CustomsInfo"/>.
/// </summary>
public abstract class CustomsInfo : DummyDataCreator
{
    private static string JsonFile => "assets/dummy_data/customs_info.json";

    /// <summary>
    ///     Create a dummy <see cref="EasyPost.Models.API.CustomsInfo"/>.
    /// </summary>
    /// <param name="client">The <see cref="EasyPost.Client"/> to make the API call with.</param>
    /// <returns>A <see cref="EasyPost.Models.API.CustomsInfo"/> object.</returns>
    public static async Task<EasyPost.Models.API.CustomsInfo> CreateCustomsItem(Client client)
    {
        var data = GetRandomMapsFromJsonFile(JsonFile, 1, true);
        var customsInfoData = data[0];

        var customsItemsData = CustomsItems.GetCustomsItemsData(1);
        customsInfoData["customs_items"] = customsItemsData;
        
        return await client.CustomsInfo.Create(customsInfoData);
    }
}
