using EasyPost.Extensions.Models;
using EasyPost.Models.API;

namespace EasyPost.Extensions.ModelMethodExtensions;

/// <summary>
///     Extension methods for a <see cref="EasyPost.Models.API.User"/>.
/// </summary>
public static class UserModelExtensions
{
    /// <summary>
    ///     Get the <see cref="EasyPost.Models.API.User.Balance"/> as <see cref="EasyPost.Extensions.Models.Money"/>.
    /// </summary>
    /// <param name="user">The <see cref="EasyPost.Models.API.User"/> to get the <see cref="EasyPost.Models.API.User.Balance"/> from.</param>
    /// <returns>The related <see cref="EasyPost.Extensions.Models.Money"/> value.</returns>
    public static Money? BalanceMoney(this User user)
    {
        return Money.FromString(user.Balance, Currency.USD);
    }
    
    /// <summary>
    ///     Get the <see cref="EasyPost.Models.API.User.PricePerShipment"/> as <see cref="EasyPost.Extensions.Models.Money"/>.
    /// </summary>
    /// <param name="user">The <see cref="EasyPost.Models.API.User"/> to get the <see cref="EasyPost.Models.API.User.PricePerShipment"/> from.</param>
    /// <returns>The related <see cref="EasyPost.Extensions.Models.Money"/> value.</returns>
    public static Money? PricePerShipmentMoney(this User user)
    {
        return Money.FromString(user.PricePerShipment, Currency.USD);
    }
    
    /// <summary>
    ///     Get the <see cref="EasyPost.Models.API.User.RechargeAmount"/> as <see cref="EasyPost.Extensions.Models.Money"/>.
    /// </summary>
    /// <param name="user">The <see cref="EasyPost.Models.API.User"/> to get the <see cref="EasyPost.Models.API.User.RechargeAmount"/> from.</param>
    /// <returns>The related <see cref="EasyPost.Extensions.Models.Money"/> value.</returns>
    public static Money? RechargeAmountMoney(this User user)
    {
        return Money.FromString(user.RechargeAmount, Currency.USD);
    }
    
    /// <summary>
    ///     Get the <see cref="EasyPost.Models.API.User.SecondaryRechargeAmount"/> as <see cref="EasyPost.Extensions.Models.Money"/>.
    /// </summary>
    /// <param name="user">The <see cref="EasyPost.Models.API.User"/> to get the <see cref="EasyPost.Models.API.User.SecondaryRechargeAmount"/> from.</param>
    /// <returns>The related <see cref="EasyPost.Extensions.Models.Money"/> value.</returns>
    public static Money? SecondaryRechargeAmountMoney(this User user)
    {
        return Money.FromString(user.SecondaryRechargeAmount, Currency.USD);
    }
    
    /// <summary>
    ///     Get the <see cref="EasyPost.Models.API.User.RechargeThreshold"/> as <see cref="EasyPost.Extensions.Models.Money"/>.
    /// </summary>
    /// <param name="user">The <see cref="EasyPost.Models.API.User"/> to get the <see cref="EasyPost.Models.API.User.RechargeThreshold"/> from.</param>
    /// <returns>The related <see cref="EasyPost.Extensions.Models.Money"/> value.</returns>
    public static Money? RechargeThresholdMoney(this User user)
    {
        return Money.FromString(user.RechargeThreshold, Currency.USD);
    }
}
