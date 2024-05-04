
namespace Blasphemous.Modding.SkinEditor;

public class TextureHandler
{
    private Bitmap _texture;

    public TextureHandler()
    {
        string path = Path.Combine(Environment.CurrentDirectory, "data", "default.png");
        _texture = new Bitmap(path);
    }

    public void SetPixel(byte pixel, Color color)
    {
        _texture.SetPixel(pixel, 0, color);
    }

    public Color GetPixel(byte pixel)
    {
        return _texture.GetPixel(pixel, 0);
    }
}
