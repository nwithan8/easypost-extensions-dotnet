namespace EasyPost.Extensions.Internal;

internal abstract class Random
{
    private static readonly System.Random _random = new();

    internal static bool RandomBool => _random.Next(0, 2) == 0;

    internal static int RandomIntInRange(int min, int max) => _random.Next(min, max);

    internal static int RandomInt => _random.Next();

    internal static double RandomDoubleInRange(double min, double max) => _random.NextDouble() * (max - min) + min;

    internal static double RandomDouble => _random.NextDouble();

    internal static float RandomFloatInRange(float min, float max) => (float)(_random.NextDouble() * (max - min) + min);

    internal static float RandomFloat => (float)_random.NextDouble();

    internal static char RandomChar => (char)(_random.Next(0, 26) + 'a');

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

    internal static string RandomString => RandomStringOfLength(RandomIntInRange(3, 10));

    internal static List<object> RandomItemsFromList<T>(List<T> list, int amount, bool allowDuplicates)
    {
        if (!allowDuplicates && amount > list.Count)
        {
            throw new Exception("Amount must be less than or equal to list size when unique is true");
        }

        var items = new List<object>();
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

    internal static object RandomItemFromList<T>(List<T> list)
    {
        var items = RandomItemsFromList<T>(list, 1, false);
        return items[0];
    }
}
