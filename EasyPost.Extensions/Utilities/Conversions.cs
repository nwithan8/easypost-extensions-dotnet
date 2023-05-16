using System.Globalization;

namespace EasyPost.Extensions.Utilities;

public static class Conversions
{
    // EasyPost uses "YYYY-MM-DD" format for dates.
    private const string EasyPostDateFormat = "yyyy-MM-dd";
    
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
    
    /// <summary>
    ///     Converts an EasyPost date string to a <see cref="DateTime"/> equivalent.
    /// </summary>
    /// <param name="value">EasyPost date string to convert to a <see cref="DateTime"/> object.</param>
    /// <returns>Equivalent <see cref="DateTime"/> object.</returns>
    public static DateTime ToDateTime(this string value)
    {
        return DateTime.ParseExact(value, EasyPostDateFormat, CultureInfo.InvariantCulture);
    }
    
    /// <summary>
    ///     Converts a <see cref="DateTime"/> to an EasyPost date string.
    /// </summary>
    /// <param name="value"><see cref="DateTime"/> item to convert to EasyPost date string.</param>
    /// <returns>EasyPost-compatible date string.</returns>
    public static string ToEasyPostDateString(this DateTime value)
    {
        return value.ToString(EasyPostDateFormat);
    }
}
