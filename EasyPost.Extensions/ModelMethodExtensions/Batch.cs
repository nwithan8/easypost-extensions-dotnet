using EasyPost.Models.API;
using NetTools.Common;

namespace EasyPost.Extensions.ModelMethodExtensions;

/// <summary>
///     Extension methods for a <see cref="EasyPost.Models.API.Batch"/>.
/// </summary>
public static class BatchModelExtensions
{
    /// <summary>
    ///     Get the <see cref="EasyPost.Models.API.Batch.State"/> as a <see cref="EasyPost.Extensions.Enums.BatchState"/> enum.
    /// </summary>
    /// <returns>The related <see cref="EasyPost.Extensions.Enums.BatchState"/> enum.</returns>
    public static Enums.BatchState? BatchStateEnum(this Batch batch)
    {
        return ValueEnum.FromValue<Enums.BatchState>(batch.State);
    }
}
