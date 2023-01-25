using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;

namespace EasyPost.Extensions.ModelMethodExtensions;

/// <summary>
///     Extension methods for a <see cref="EasyPost.Models.API.User"/>.
/// </summary>
public static class UserModelExtensions
{
    /// <summary>
    ///     Update a <see cref="EasyPost.Models.API.User"/>.
    /// </summary>
    /// <param name="user">The <see cref="EasyPost.Models.API.User"/> to update.</param>
    /// <param name="parameters">The <see cref="Users.Update"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An updated <see cref="EasyPost.Models.API.User"/> object.</returns>
    public static async Task<User> Update(this User user, Users.Update parameters, ApiVersion? apiVersion = null)
    {
        return await user.Update(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Update a <see cref="EasyPost.Models.API.User"/>'s <see cref="EasyPost.Models.API.Brand"/>.
    /// </summary>
    /// <param name="user">The <see cref="EasyPost.Models.API.User"/> to update the brand of.</param>
    /// <param name="parameters">The <see cref="Users.UpdateBrand"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An updated <see cref="EasyPost.Models.API.Brand"/> object.</returns>
    public static async Task<Brand> UpdateBrand(this User user, Users.UpdateBrand parameters, ApiVersion? apiVersion = null)
    {
        return await user.UpdateBrand(parameters.ToDictionary(apiVersion));
    }
}
