using System.Reflection;
using Newtonsoft.Json;

namespace EasyPost.Extensions.Internal;

internal abstract class JsonReader
{
    private static string GetFilePathFromResources(string filename)
    {
        return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"{filename}");
    }

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
