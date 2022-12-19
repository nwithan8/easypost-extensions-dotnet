using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EasyPost.Extensions;

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
    /// <param name="apiVersion">A <see cref="EasyPost.Extensions.ApiVersion"/></param>
    /// <returns>A formatted EasyPost API base URL string.</returns>
    public static string BuildApiBaseUrl(ApiVersion apiVersion)
    {
        return $"https://api.easypost.com/{apiVersion}/";
    }
}

internal class Pair
{
    internal object? Value1 { get; set; }
    internal object? Value2 { get; set; }

    internal Pair(object? value1, object? value2)
    {
        Value1 = value1;
        Value2 = value2;
    }
}

public class Pairs : IEnumerable<Pair>
{
    private readonly List<Pair> _list = new List<Pair>();

    public bool AllMatch()
    {
        return _list.All(pair => pair.Value1 == pair.Value2);
    }

    internal void Add(object? value1, object? value2)
    {
        _list.Add(new Pair(value1, value2));
    }

    IEnumerator<Pair> IEnumerable<Pair>.GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _list.GetEnumerator();
    }
}
