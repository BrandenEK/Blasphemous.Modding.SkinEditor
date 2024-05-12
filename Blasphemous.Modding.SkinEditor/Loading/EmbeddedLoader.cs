using Newtonsoft.Json;
using System.Reflection;

namespace Blasphemous.Modding.SkinEditor.Loading;

public class EmbeddedLoader : IResourceLoader
{
    public IEnumerable<string> GetResources(string folder)
    {
        return GetFilesInFolder(folder);
    }

    public Bitmap LoadImage(string file)
    {
        string path = Path.Combine(BASE_PATH, file).Replace('\\', '.');
        using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path)!;

        return new Bitmap(stream);
    }

    public T LoadJson<T>(string file)
    {
        string path = Path.Combine(BASE_PATH, file).Replace('\\', '.');
        using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path)!;
        using StreamReader reader = new(stream);

        string json = reader.ReadToEnd();
        return JsonConvert.DeserializeObject<T>(json)!;
    }

    private IEnumerable<string> GetEverythingInBaseFolder()
    {
        return Assembly.GetExecutingAssembly().GetManifestResourceNames()
            .Select(ReplaceWithSlashes)
            .Where(x => x.StartsWith(BASE_PATH))
            .Select(x => x[(BASE_PATH.Length + 1)..]);
    }

    private IEnumerable<string> GetEverythingInFolder(string folder)
    {
        if (string.IsNullOrEmpty(folder))
            return GetEverythingInBaseFolder();

        return GetEverythingInBaseFolder()
            .Where(x => x.StartsWith($"{folder}\\"))
            .Select(x => x[(folder.Length + 1)..]);
    }

    private IEnumerable<string> GetFilesInFolder(string folder)
    {
        return GetEverythingInFolder(folder)
            .Where(x => !x.Contains('\\'));
    }

    private string ReplaceWithSlashes(string path)
    {
        int lastPeriod = path.LastIndexOf('.');
        return path[..lastPeriod].Replace('.', '\\') + path[lastPeriod..];
    }

    private const string BASE_PATH = "Blasphemous\\Modding\\SkinEditor\\Resources";
}
