namespace EasyPost.Extensions.Enums;

// This is the enum that will actually be used in the ApiCompatibility attributes
// We unfortunately have to use this because attributes can only take compile-time variables as properties
// The ValueEnum from NetTools is not a true enum
internal enum ApiVersionEnum
{
    Beta,
    V2,
}

/// <summary>
///     An enum that represents the different versions of the EasyPost API.
/// </summary>
public class ApiVersion : NetTools.Common.ValueEnum
{
    /// <summary>
    ///     The beta version of the EasyPost API
    /// </summary>
    public static readonly ApiVersion Beta = new(0, "beta", ApiVersionEnum.Beta);

    /// <summary>
    ///     The v2 version of the EasyPost API
    /// </summary>
    public static readonly ApiVersion V2 = new(1, "v2", ApiVersionEnum.V2);

    internal ApiVersionEnum Enum { get; private set; }

    private ApiVersion(int id, string version, ApiVersionEnum @enum) : base(id, version)
    {
        Enum = @enum;
    }

    public static implicit operator ApiVersion?(EasyPost._base.ApiVersion apiVersion)
    {
        return FromEasyPostLibraryApiVersion(apiVersion);
    }

    /// <summary>
    ///     Converts a <see cref="EasyPost._base.ApiVersion"/> to a <see cref="ApiVersion"/>. Returns null if the conversion fails.
    /// </summary>
    /// <param name="apiVersion">A <see cref="EasyPost._base.ApiVersion"/> to covert.</param>
    /// <returns>The <see cref="Enums.ApiVersion"/> equivalent.</returns>
    internal static ApiVersion? FromEasyPostLibraryApiVersion(EasyPost._base.ApiVersion apiVersion)
    {
        ApiVersion? version = null;
        var @switch = new NetTools.Common.SwitchCase
        {
            // we always want to check if it matches "Current" first, since this value in the EasyPost library can change.
            // There's no "Current" in this utility, so we want to map it to the latest version manually.
            { EasyPost._base.ApiVersion.Current.ToString(), () => version = V2 },
            { EasyPost._base.ApiVersion.Beta.ToString(), () => version = Beta },
            { NetTools.Common.Scenario.Default, () => version = null },
        };
        @switch.MatchFirst(apiVersion.ToString());

        return version;
    }

    public static bool operator ==(_base.ApiVersion? left, ApiVersion? right)
    {
        if (left is null && right is null)
            return true;
        if (left is null || right is null)
            return false;
        var convertedApiVersion = FromEasyPostLibraryApiVersion(left);
        return convertedApiVersion == right;
    }

    public static bool operator !=(_base.ApiVersion? left, ApiVersion? right)
    {
        return !(left == right);
    }

    public static bool operator <(EasyPost._base.ApiVersion? left, ApiVersion? right)
    {
        if (left is null && right is null)
            return true;
        if (left is null || right is null)
            return false;
        var convertedApiVersion = FromEasyPostLibraryApiVersion(left);
        return convertedApiVersion < right;
    }

    public static bool operator >(_base.ApiVersion? left, ApiVersion? right)
    {
        return !(left <= right);
    }

    public static bool operator <=(_base.ApiVersion? left, ApiVersion? right)
    {
        if (left is null && right is null)
            return true;
        if (left is null || right is null)
            return false;
        var convertedApiVersion = FromEasyPostLibraryApiVersion(left);
        return convertedApiVersion <= right;
    }

    public static bool operator >=(_base.ApiVersion? left, ApiVersion? right)
    {
        return !(left < right);
    }

    public static bool operator ==(ApiVersion? left, _base.ApiVersion? right)
    {
        if (left is null && right is null)
            return true;
        if (left is null || right is null)
            return false;
        var convertedApiVersion = FromEasyPostLibraryApiVersion(right);
        return left == convertedApiVersion;
    }

    public static bool operator !=(ApiVersion? left, _base.ApiVersion? right)
    {
        return !(left == right);
    }

    public static bool operator <(ApiVersion? left, _base.ApiVersion? right)
    {
        if (left is null && right is null)
            return true;
        if (left is null || right is null)
            return false;
        var convertedApiVersion = FromEasyPostLibraryApiVersion(right);
        return left < convertedApiVersion;
    }

    public static bool operator >(ApiVersion? left, _base.ApiVersion? right)
    {
        return !(left <= right);
    }

    public static bool operator <=(ApiVersion? left, _base.ApiVersion? right)
    {
        if (left is null && right is null)
            return true;
        if (left is null || right is null)
            return false;
        var convertedApiVersion = FromEasyPostLibraryApiVersion(right);
        return left <= convertedApiVersion;
    }

    public static bool operator >=(ApiVersion? left, _base.ApiVersion? right)
    {
        return !(left < right);
    }
}
