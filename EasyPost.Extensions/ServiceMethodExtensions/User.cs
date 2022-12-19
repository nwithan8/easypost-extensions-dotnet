using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

public static class UserServiceExtensions
{
    public static async Task<User> CreateChild(this UserService service, Users.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.CreateChild(parameters.ToDictionary(apiVersion));
    }
}
