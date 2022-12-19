using System.Collections.Generic;
using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

public static class WebhookServiceExtensions
{
    public static async Task<List<Webhook>> All(this WebhookService service, Webhooks.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    public static async Task<Webhook> Create(this WebhookService service, Webhooks.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.Create(parameters.ToDictionary(apiVersion));
    }
}
