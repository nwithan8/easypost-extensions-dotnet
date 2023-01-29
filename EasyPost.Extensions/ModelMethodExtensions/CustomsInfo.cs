using EasyPost.Models.API;
using NetTools.Common;

namespace EasyPost.Extensions.ModelMethodExtensions;

/// <summary>
///     Extension methods for a <see cref="EasyPost.Models.API.CustomsInfo"/>.
/// </summary>
public static class CustomsInfoModelExtensions
{
    /// <summary>
    ///     Get the <see cref="EasyPost.Models.API.CustomsInfo.EelPfc"/> as a <see cref="EasyPost.Extensions.Enums.CustomsFormType"/> enum.
    /// </summary>
    /// <returns>The related <see cref="EasyPost.Extensions.Enums.CustomsFormType"/> enum.</returns>
    public static Enums.CustomsFormType? FormTypeEnum(this CustomsInfo customsInfo)
    {
        return ValueEnum.FromValue<Enums.CustomsFormType>(customsInfo.EelPfc);
    }
    
    /// <summary>
    ///     Get the <see cref="EasyPost.Models.API.CustomsInfo.NonDeliveryOption"/> as a <see cref="EasyPost.Extensions.Enums.NonDeliveryOption"/> enum.
    /// </summary>
    /// <returns>The related <see cref="EasyPost.Extensions.Enums.NonDeliveryOption"/> enum.</returns>
    public static Enums.NonDeliveryOption? NonDeliveryOptionEnum(this CustomsInfo customsInfo)
    {
        return ValueEnum.FromValue<Enums.NonDeliveryOption>(customsInfo.NonDeliveryOption);
    }
    
    /// <summary>
    ///     Get the <see cref="EasyPost.Models.API.CustomsInfo.RestrictionType"/> as a <see cref="EasyPost.Extensions.Enums.CustomsRestrictionType"/> enum.
    /// </summary>
    /// <returns>The related <see cref="EasyPost.Extensions.Enums.CustomsRestrictionType"/> enum.</returns>
    public static Enums.CustomsRestrictionType? RestrictionTypeEnum(this CustomsInfo customsInfo)
    {
        return ValueEnum.FromValue<Enums.CustomsRestrictionType>(customsInfo.RestrictionType);
    }
}
