using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;

namespace EasyPost.Extensions.ModelMethodExtensions;

public static class WebhookModelExtensions
{
    public static async Task<Webhook> Update(this Webhook obj, Webhooks.Update parameters, ApiVersion? apiVersion = null)
    {
        return await obj.Update(parameters.ToDictionary(apiVersion));
    }
}
