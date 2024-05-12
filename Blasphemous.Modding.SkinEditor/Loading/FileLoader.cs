using Newtonsoft.Json;

namespace Blasphemous.Modding.SkinEditor.Loading;

public class FileLoader : IResourceLoader
{
    private readonly string _dataFolder;

    public FileLoader(string dataFolder)
    {
        if (!Directory.Exists(dataFolder))
            throw new ArgumentException("Data folder does not exist", nameof(dataFolder));

        _dataFolder = dataFolder;
    }

    public IEnumerable<string> GetResources(string folder)
    {
        string path = string.IsNullOrEmpty(folder)
            ? _dataFolder
            : Path.Combine(_dataFolder, folder);

        return Directory.GetFiles(path).Select(x => x[(x.LastIndexOf('\\') + 1)..]);
    }

    public Bitmap LoadImage(string file)
    {
        string path = Path.Combine(_dataFolder, file);

        return new Bitmap(path);
    }

    public T LoadJson<T>(string file)
    {
        string path = Path.Combine(_dataFolder, file);

        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<T>(json)!;
    }
}
