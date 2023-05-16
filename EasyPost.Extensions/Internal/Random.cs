namespace EasyPost.Extensions.Internal;

/// <summary>
///     Functions to generate random data.
/// </summary>
internal abstract class Random
{
    /// <summary>
    ///     Random generator.
    /// </summary>
    private static readonly System.Random _random = new();

    /// <summary>
    ///     Generate a random boolean.
    /// </summary>
    internal static bool RandomBool => _random.Next(0, 2) == 0;

    /// <summary>
    ///     Generate a random integer between min and max.
    /// </summary>
    /// <param name="min">Minimum, inclusive.</param>
    /// <param name="max">Maximum, inclusive.</param>
    /// <returns>An integer between min and max.</returns>
    internal static int RandomIntInRange(int min, int max) => _random.Next(min, max);

    /// <summary>
    ///     Generate a random integer.
    /// </summary>
    internal static int RandomInt => _random.Next();

    /// <summary>
    ///     Generate a random double between min and max.
    /// </summary>
    /// <param name="min">Minimum, inclusive.</param>
    /// <param name="max">Maximum, inclusive.</param>
    /// <returns>A double between min and max.</returns>
    internal static double RandomDoubleInRange(double min, double max) => _random.NextDouble() * (max - min) + min;

    /// <summary>
    ///     Generate a random double.
    /// </summary>
    internal static double RandomDouble => _random.NextDouble();

    /// <summary>
    ///     Generate a random float between min and max.
    /// </summary>
    /// <param name="min">Minimum, inclusive.</param>
    /// <param name="max">Maximum, inclusive.</param>
    /// <returns>A float between min and max.</returns>
    internal static float RandomFloatInRange(float min, float max) => (float)(_random.NextDouble() * (max - min) + min);

    /// <summary>
    ///     Generate a random float.
    /// </summary>
    internal static float RandomFloat => (float)_random.NextDouble();
    
    /// <summary>
    ///     Generate a random char.
    /// </summary>
    internal static char RandomChar => (char)(_random.Next(0, 26) + 'a');

    /// <summary>
    ///     Generate a random string of length.
    /// </summary>
    /// <param name="length">Length of string to generate.</param>
    /// <returns>A string of the specified length.</returns>
    internal static string RandomStringOfLength(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringChars = new char[length];
        for (var i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[_random.Next(chars.Length)];
        }

        return new string(stringChars);
    }

    /// <summary>
    ///     Generate a random string.
    /// </summary>
    internal static string RandomString => RandomStringOfLength(RandomIntInRange(3, 10));

    /// <summary>
    ///     Get a random subset of items from a list.
    /// </summary>
    /// <param name="list">List to select from.</param>
    /// <param name="amount">Number of elements to select.</param>
    /// <param name="allowDuplicates">Whether to allow duplicate items in the subset. Use with caution, could cause perpetual hang.</param>
    /// <typeparam name="T">Type of objects in the list.</typeparam>
    /// <returns>A list of T-type objects of the specified amount.</returns>
    /// <exception cref="Exception">Thrown when the list cannot be filtered.</exception>
    internal static List<T> RandomItemsFromList<T>(List<T> list, int amount, bool allowDuplicates)
    {
        if (list == null || list.Count == 0)
        {
            throw new Exception("List cannot be empty or null");
        }
        
        if (!allowDuplicates && amount > list.Count)
        {
            throw new Exception("Amount must be less than or equal to list size when unique is true");
        }

        var items = new List<T>();
        for (var i = 0; i < amount; i++)
        {
            var item = list[RandomIntInRange(0, list.Count - 1)];
            items.Add(item);
            if (!allowDuplicates)
            {
                list.Remove(item);
            }
        }

        return items;
    }

    /// <summary>
    ///     Get a random item from a list.
    /// </summary>
    /// <param name="list">List to select from.</param>
    /// <typeparam name="T">Type of objects in the list.</typeparam>
    /// <returns>A T-type object</returns>
    internal static T RandomItemFromList<T>(List<T> list)
    {
        var items = RandomItemsFromList<T>(list, 1, false);
        return items[0];
    }
}
