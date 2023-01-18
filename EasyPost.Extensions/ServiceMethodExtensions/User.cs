using EasyPost.Extensions.Parameters;
using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.UserService" /> class.
/// </summary>
public static class UserServiceExtensions
{
    /// <summary>
    ///     Create a child <see cref="EasyPost.Models.API.User"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.UserService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Users.Create"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.User"/> object.</returns>
    public static async Task<User> CreateChild(this UserService service, Users.Create parameters, ApiVersion? apiVersion = null)
    {
        return await service.CreateChild(parameters.ToDictionary(apiVersion));
    }
}
