using EasyPost.Models.API;
using NetTools.Common;

namespace EasyPost.Extensions.ModelMethodExtensions;

/// <summary>
///     Extension methods for a <see cref="EasyPost.Models.API.CustomsInfo"/>.
/// </summary>
public static class CustomsInfoModelExtensions
{
    /// <summary>
    ///     Get the <see cref="EasyPost.Models.API.CustomsInfo.EelPfc"/> as a <see cref="EasyPost.Extensions.CustomsFormType"/> enum.
    /// </summary>
    /// <returns>The related <see cref="EasyPost.Extensions.CustomsFormType"/> enum.</returns>
    public static CustomsFormType? FormTypeEnum(this CustomsInfo customsInfo)
    {
        return ValueEnum.FromValue<CustomsFormType>(customsInfo.EelPfc);
    }
    
    /// <summary>
    ///     Get the <see cref="EasyPost.Models.API.CustomsInfo.NonDeliveryOption"/> as a <see cref="EasyPost.Extensions.NonDeliveryOption"/> enum.
    /// </summary>
    /// <returns>The related <see cref="EasyPost.Extensions.CustomsFormType"/> enum.</returns>
    public static NonDeliveryOption? NonDeliveryOptionEnum(this CustomsInfo customsInfo)
    {
        return ValueEnum.FromValue<NonDeliveryOption>(customsInfo.NonDeliveryOption);
    }
    
    /// <summary>
    ///     Get the <see cref="EasyPost.Models.API.CustomsInfo.RestrictionType"/> as a <see cref="EasyPost.Extensions.CustomsRestrictionType"/> enum.
    /// </summary>
    /// <returns>The related <see cref="EasyPost.Extensions.CustomsFormType"/> enum.</returns>
    public static CustomsRestrictionType? RestrictionTypeEnum(this CustomsInfo customsInfo)
    {
        return ValueEnum.FromValue<CustomsRestrictionType>(customsInfo.RestrictionType);
    }
}
