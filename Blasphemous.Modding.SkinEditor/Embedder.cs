using Newtonsoft.Json;
using System.Reflection;

namespace Blasphemous.Modding.SkinEditor;

public static class Embedder
{
    public static string[] GetAllResources()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        return assembly.GetManifestResourceNames();
    }

    public static T LoadResourceJson<T>(string fileName)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        using Stream stream = assembly.GetManifestResourceStream($"Blasphemous.Modding.SkinEditor.Resources.{fileName}")!;
        using StreamReader reader = new(stream);

        string json = reader.ReadToEnd();
        return JsonConvert.DeserializeObject<T>(json)!;
    }

    public static Bitmap LoadResourceImage(string fileName)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        using Stream stream = assembly.GetManifestResourceStream($"Blasphemous.Modding.SkinEditor.Resources.{fileName}")!;

        return new Bitmap(stream);
    }
}
