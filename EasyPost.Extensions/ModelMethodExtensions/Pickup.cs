using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;

namespace EasyPost.Extensions.ModelMethodExtensions;

public static class PickupModelExtensions
{
    public static async Task<Pickup> Buy(this Pickup obj, Pickups.Buy parameters, ApiVersion? apiVersion = null)
    {
        parameters.Validate();
        return await obj.Buy(parameters.Carrier!, parameters.Service!);
    }
}
