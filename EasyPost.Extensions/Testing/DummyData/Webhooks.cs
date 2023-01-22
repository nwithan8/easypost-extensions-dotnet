using EasyPost.Models.API;
using EasyPost.Extensions.ServiceMethodExtensions;

namespace EasyPost.Extensions.Testing.DummyData;

/// <summary>
///     Functions for dummy <see cref="Webhook"/>s.
/// </summary>
public abstract class Webhooks : DummyDataCreator
{
    /// <summary>
    ///     Create a dummy <see cref="Webhook"/>.
    /// </summary>
    /// <param name="client">The <see cref="EasyPost.Client"/> to make the API call with.</param>
    /// <returns>A <see cref="Webhook"/> object.</returns>
    public static async Task<Webhook> CreateWebhook(Client client)
    {
        var domain = Internal.Random.RandomString;
        var url = $"https://{domain}.com";

        var parameters = new Parameters.V2.Webhooks.Create
        {
            Url = url,
        };

        return await client.Webhook.Create(parameters);
    }
}
