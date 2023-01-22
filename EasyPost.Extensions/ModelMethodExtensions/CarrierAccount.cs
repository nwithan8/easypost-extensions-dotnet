using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;

namespace EasyPost.Extensions.ModelMethodExtensions;

public static class CarrierAccountModelExtensions
{
    public static async Task<CarrierAccount> Update(this CarrierAccount obj, CarrierAccounts.Update parameters, ApiVersion? apiVersion = null)
    {
        return await obj.Update(parameters.ToDictionary(apiVersion));
    }
}
