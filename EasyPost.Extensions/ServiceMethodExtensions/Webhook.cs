using EasyPost.Extensions.Parameters.Webhook;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.WebhookService" /> class.
/// </summary>
public static class WebhookServiceExtensions
{
    /// <summary>
    ///     Toggle the enabled status of a <see cref="EasyPost.Models.API.Webhook"/>.
    /// </summary>
    /// <param name="service">The <see cref="WebhookService"/> to use for the API call.</param>
    /// <param name="webhook">The <see cref="EasyPost.Models.API.Webhook"/> to toggle.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/> to use for the HTTP request.</param>
    /// <returns>An updated <see cref="EasyPost.Models.API.Webhook"/> object.</returns>
    public static async Task<Webhook> Toggle(this WebhookService service, Webhook webhook, CancellationToken cancellationToken = default)
    {
        return await service.Update(webhook.Id!, new Update(), cancellationToken: cancellationToken);
    }
}
