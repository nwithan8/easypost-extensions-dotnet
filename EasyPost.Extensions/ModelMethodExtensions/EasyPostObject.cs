namespace EasyPost.Extensions.ModelMethodExtensions;

/// <summary>
///     Extensions for the base <see cref="EasyPost._base.EasyPostObject"/> class.
/// </summary>
public static class EasyPostObject
{
    /// <summary>
    ///     Get the prefix of the ID of an <see cref="EasyPost._base.EasyPostObject"/>.
    /// </summary>
    /// <param name="easyPostObject">The <see cref="EasyPost._base.EasyPostObject"/> to extract the prefix of.</param>
    /// <returns>The prefix of the object's ID.</returns>
    public static string? GetIdPrefix(this EasyPost._base.EasyPostObject easyPostObject)
    {
        return easyPostObject.Id?.Split('_').First();
    }
}
