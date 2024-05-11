using Newtonsoft.Json;
using System.Reflection;

namespace Blasphemous.Modding.SkinEditor;

public static class Embedder
{
    public static IEnumerable<string> GetAllResources()
    {
        return Assembly.GetExecutingAssembly().GetManifestResourceNames()
            .Where(x => x.StartsWith(BASE_PATH))
            .Select(x => x[(BASE_PATH.Length + 1)..]);
    }

    public static IEnumerable<string> GetResourcesInFolder(string folderName)
    {
        return GetAllResources()
            .Where(x => x.StartsWith(folderName))
            .Select(x => x[(folderName.Length + 1)..]);
    }

    public static T LoadResourceJson<T>(string fileName)
    {
        using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{BASE_PATH}.{fileName}")!;
        using StreamReader reader = new(stream);

        string json = reader.ReadToEnd();
        return JsonConvert.DeserializeObject<T>(json)!;
    }

    public static Bitmap LoadResourceImage(string fileName)
    {
        using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{BASE_PATH}.{fileName}")!;

        return new Bitmap(stream);
    }

    private const string BASE_PATH = "Blasphemous.Modding.SkinEditor.Resources";
}
