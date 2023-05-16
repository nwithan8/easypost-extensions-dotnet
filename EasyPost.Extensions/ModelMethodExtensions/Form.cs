using EasyPost.Models.API;
using NetTools.Common;

namespace EasyPost.Extensions.ModelMethodExtensions;

/// <summary>
///     Extension methods for a <see cref="EasyPost.Models.API.Form"/>.
/// </summary>
public static class FormModelExtensions
{
    /// <summary>
    ///     Get the <see cref="EasyPost.Models.API.Form.FormType"/> as a <see cref="EasyPost.Extensions.Enums.FormType"/> enum.
    /// </summary>
    /// <returns>The related <see cref="EasyPost.Extensions.Enums.FormType"/> enum.</returns>
    public static Enums.FormType? Type(this Form form)
    {
        return ValueEnum.FromValue<Enums.FormType>(form.FormType);
    }
}
