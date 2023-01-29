

namespace EasyPost.Extensions;

/// <summary>
///     General, non-categorized helper methods.
/// </summary>
public static class General
{
    /// <summary>
    ///     Build the default EasyPost API base URL using a given API version.
    /// </summary>
    /// <param name="apiVersion">A <see cref="EasyPost._base.ApiVersion"/></param>
    /// <returns>A formatted EasyPost API base URL string.</returns>
    public static string BuildApiBaseUrl(EasyPost._base.ApiVersion apiVersion)
    {
        return $"https://api.easypost.com/{apiVersion}/";
    }

    /// <summary>
    ///     Build the default EasyPost API base URL using a given API version.
    /// </summary>
    /// <param name="apiVersion">A <see cref="EasyPost.Extensions.Enums.ApiVersion"/></param>
    /// <returns>A formatted EasyPost API base URL string.</returns>
    public static string BuildApiBaseUrl(Enums.ApiVersion apiVersion)
    {
        return $"https://api.easypost.com/{apiVersion}/";
    }
}
