using Basalt.Framework.Logging;
using Blasphemous.Modding.SkinEditor.Loading;
using Blasphemous.Modding.SkinEditor.Undo;
using System.Drawing.Imaging;

namespace Blasphemous.Modding.SkinEditor.Texture;

public class TextureManager : IManager
{
    private readonly IResourceLoader _resourceLoader;

    private Bitmap? _texture;

    public TextureManager(IResourceLoader resourceLoader)
    {
        _resourceLoader = resourceLoader;
    }

    public void SaveTexture(string path)
    {
        if (_texture is null)
            throw new Exception("No texture has been loaded yet");

        Logger.Info($"Saving current texture to {path}");
        _texture.Save(path, ImageFormat.Png);
    }

    public void LoadTexture(string path)
    {
        using Bitmap texture = new(path);

        _texture?.Dispose();
        _texture = new(texture);

        Logger.Info($"Loading texture from {path}");
        OnTextureChanged?.Invoke(_texture);
    }

    public void LoadDefaultTexture()
    {
        using Bitmap texture = _resourceLoader.LoadImage("texture.png");

        _texture?.Dispose();
        _texture = new(texture);

        Logger.Info($"Loading default texture");
        OnTextureChanged?.Invoke(_texture);
    }

    public void SetPixel(byte pixel, Color color)
    {
        if (_texture is null)
            throw new Exception("No texture has been loaded yet");

        _texture.SetPixel(pixel, 0, color);
    }

    public Color GetPixel(byte pixel)
    {
        if (_texture is null)
            throw new Exception("No texture has been loaded yet");

        return _texture.GetPixel(pixel, 0);
    }

    // Event handling

    public void Initialize()
    {
        Core.RecolorManager.OnPixelChanged += OnPixelChanged;
        Core.SaveManager.OnNewSkin += OnNewSkin;
        Core.SaveManager.OnOpenSkin += OnOpenSkin;
        Core.SaveManager.OnSaveSkin += OnSaveSkin;
        Core.UndoManager.OnUndo += OnUndo;
        Core.UndoManager.OnRedo += OnRedo;
    }

    private void OnPixelChanged(byte pixel, Color oldColor, Color newColor)
    {
        SetPixel(pixel, newColor);
    }

    private void OnNewSkin()
    {
        LoadDefaultTexture();
    }

    private void OnOpenSkin(string path)
    {
        LoadTexture(Path.Combine(path, "texture.png"));
    }

    private void OnSaveSkin(string path)
    {
        SaveTexture(Path.Combine(path, "texture.png"));
    }

    private void OnUndo(BaseUndoCommand command)
    {
        if (command is not PixelColorUndoCommand pc)
            return;

        SetPixel(pc.Pixel, pc.OldColor);
    }

    private void OnRedo(BaseUndoCommand command)
    {
        if (command is not PixelColorUndoCommand pc)
            return;

        SetPixel(pc.Pixel, pc.NewColor);
    }

    public delegate void TextureChangeDelegate(Bitmap texture);
    public event TextureChangeDelegate? OnTextureChanged;
}
