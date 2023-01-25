using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;

namespace EasyPost.Extensions.ModelMethodExtensions;

/// <summary>
///     Extension methods for a <see cref="EasyPost.Models.API.Webhook"/>.
/// </summary>
public static class WebhookModelExtensions
{
    /// <summary>
    ///     Update a <see cref="EasyPost.Models.API.Webhook"/>.
    /// </summary>
    /// <param name="webhook">The <see cref="EasyPost.Models.API.Webhook"/> to update.</param>
    /// <param name="parameters">The <see cref="Webhooks.Update"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An updated <see cref="EasyPost.Models.API.Webhook"/> object.</returns>
    public static async Task<Webhook> Update(this Webhook webhook, Webhooks.Update parameters, ApiVersion? apiVersion = null)
    {
        return await webhook.Update(parameters.ToDictionary(apiVersion));
    }
}
