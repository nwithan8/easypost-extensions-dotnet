namespace EasyPost.Extensions.Utilities;

public static class Conversions
{
    /// <summary>
    ///     Converts a string to a boolean equivalent.
    /// </summary>
    /// <param name="value">String value to parse.</param>
    /// <returns>Boolean equivalent.</returns>
    public static bool? ToBoolean(this string? value)
    {
        value = value?.Trim().ToLower();

        if (value == null)
        {
            return null;
        }

        bool? result = null;

        var @switch = new NetTools.Common.SwitchCase
        {
            { new List<string> { "true", "t", "yes", "y", "1" }.Contains(value), () => result = true },
            { new List<string> { "false", "f", "no", "n", "0" }.Contains(value), () => result = false },
            { NetTools.Common.Scenario.Default, () => result = null },
        };

        @switch.MatchFirst(true);

        return result;
    }
}
