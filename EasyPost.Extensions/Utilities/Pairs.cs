using System.Collections;

namespace EasyPost.Extensions.Utilities;

/// <summary>
///     A class holding two values.
/// </summary>
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

/// <summary>
///     A class representing a collection of <see cref="Pair"/>s.
///     Useful for comparing two collections of values.
/// </summary>
public class Pairs : IEnumerable<Pair>
{
    private readonly List<Pair> _list = new();

    /// <summary>
    ///     Check if each pair of values in the collection are equal.
    /// </summary>
    /// <returns>True if each pair are equal, false otherwise.</returns>
    public bool AllMatch()
    {
        return _list.All(pair => pair.Value1 == pair.Value2);
    }

    /// <summary>
    ///     Add a new <see cref="Pair"/> to the collection.
    /// </summary>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
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
