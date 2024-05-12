
namespace Blasphemous.Modding.SkinEditor.Loading;

public interface IResourceLoader
{
    T LoadJson<T>(string file);

    Bitmap LoadImage(string file);

    IEnumerable<string> GetResources(string folder);
}
