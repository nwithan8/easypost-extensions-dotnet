using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;

namespace EasyPost.Extensions.ModelMethodExtensions;

public static class UserModelExtensions
{
    public static async Task<User> Update(this User obj, Users.Update parameters, ApiVersion? apiVersion = null)
    {
        return await obj.Update(parameters.ToDictionary(apiVersion));
    }

    public static async Task<Brand> UpdateBrand(this User obj, Users.UpdateBrand parameters, ApiVersion? apiVersion = null)
    {
        return await obj.UpdateBrand(parameters.ToDictionary(apiVersion));
    }
}

public static class UserCollectionModelExtensions
{}
