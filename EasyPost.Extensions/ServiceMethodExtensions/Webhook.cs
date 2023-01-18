using EasyPost.Extensions.Parameters;
using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.WebhookService" /> class.
/// </summary>
public static class WebhookServiceExtensions
{
    /// <summary>
    ///     List all <see cref="EasyPost.Models.API.Webhook"/>s.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.WebhookService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Webhooks.All"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A list of <see cref="EasyPost.Models.API.Webhook"/> objects.</returns>
    public static async Task<List<Webhook>> All(this WebhookService service, Webhooks.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Create a <see cref="EasyPost.Models.API.Webhook"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.WebhookService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Webhooks.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.Webhook"/> object.</returns>
    public static async Task<Webhook> Create(this WebhookService service, Webhooks.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }
}
