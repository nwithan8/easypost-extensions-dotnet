using EasyPost.Extensions.ModelMethodExtensions;
using EasyPost.Extensions.Models;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.UserService" /> class.
/// </summary>
public static class UserServiceExtensions
{
    /// <summary>
    ///     Retrieve the account balance for a <see cref="EasyPost.Models.API.User"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.UserService"/> to use for the API call.</param>
    /// <param name="childUserId">The <see cref="EasyPost.Models.API.User.Id"/> of the child user to retrieve the balance for. Exclude to retrieve account balance for self.</param>
    /// <returns>A <see cref="string"/> representing the account balance for the user.</returns>
    public static async Task<Money?> GetAccountBalance(this UserService service, string? childUserId = null)
    {
        var user = await service.Retrieve(childUserId);

        return user.BalanceMoney();
    }
}
