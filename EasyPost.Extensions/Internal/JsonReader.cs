using System.Reflection;
using Newtonsoft.Json;

namespace EasyPost.Extensions.Internal;

/// <summary>
///     Functions to read JSON files.
/// </summary>
internal abstract class JsonReader
{
    /// <summary>
    ///     Get the path to the file in the resources folder.
    /// </summary>
    /// <param name="filename">Path of the file from the resources root folder.</param>
    /// <returns>The full path of the file.</returns>
    private static string GetFilePathFromResources(string filename)
    {
        return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"{filename}");
    }

    /// <summary>
    ///     Read a JSON file and return a list of JSON objects.
    ///     Example of JSON file: [{"key": "value"}, {"key": "value"}]
    /// </summary>
    /// <param name="path">Path of the JSON file.</param>
    /// <returns>A list of <see cref="Dictionary{TKey,TValue}"/> objects.</returns>
    internal static List<Dictionary<string, object>>? ReadJsonFileJson(string path)
    {
        try
        {
            var filePath = GetFilePathFromResources(path);
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    /// <summary>
    ///     Read a JSON file and return a list of objects.
    ///     Example of JSON file: ["value", "value2"]
    /// </summary>
    /// <param name="path">Path of the JSON file.</param>
    /// <returns>A list of objects.</returns>
    internal static List<object>? ReadJsonFileArray(string path)
    {
        try
        {
            var filePath = GetFilePathFromResources(path);
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<object>>(json);
        }
        catch (Exception e)
        {
            return null;
        }
    }
}
