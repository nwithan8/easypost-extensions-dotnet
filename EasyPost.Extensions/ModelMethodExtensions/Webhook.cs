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
    /// <param name="apiVersion">The <see cref="Enums.ApiVersion"/> to target.</param>
    /// <returns>An updated <see cref="EasyPost.Models.API.Webhook"/> object.</returns>
    public static async Task<Webhook> Update(this Webhook webhook, Webhooks.Update parameters, Enums.ApiVersion? apiVersion = null)
    {
        return await webhook.Update(parameters.ToDictionary(apiVersion));
    }
    
    /// <summary>
    ///     Toggle the enabled status of a <see cref="EasyPost.Models.API.Webhook"/>.
    /// </summary>
    /// <param name="webhook">The <see cref="EasyPost.Models.API.Webhook"/> to toggle.</param>
    /// <returns>An updated <see cref="EasyPost.Models.API.Webhook"/> object.</returns>
    public static async Task<Webhook> Toggle(this Webhook webhook)
    {
        return await webhook.Update(new Dictionary<string, object>());
    }
}
