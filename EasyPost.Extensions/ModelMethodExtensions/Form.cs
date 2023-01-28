using EasyPost.Models.API;
using NetTools.Common;

namespace EasyPost.Extensions.ModelMethodExtensions;

/// <summary>
///     Extension methods for a <see cref="EasyPost.Models.API.Form"/>.
/// </summary>
public static class FormModelExtensions
{
    /// <summary>
    ///     Get the <see cref="EasyPost.Models.API.Form.FormType"/> as a <see cref="EasyPost.Extensions.FormType"/> enum.
    /// </summary>
    /// <returns>The related <see cref="EasyPost.Extensions.FormType"/> enum.</returns>
    public static FormType? FormTypeEnum(this Form form)
    {
        return ValueEnum.FromValue<FormType>(form.FormType);
    }
}
