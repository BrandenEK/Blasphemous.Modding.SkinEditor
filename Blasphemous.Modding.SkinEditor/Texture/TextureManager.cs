using Blasphemous.Modding.SkinEditor.Undo;

namespace Blasphemous.Modding.SkinEditor.Texture;

public class TextureManager : IManager
{
    private Bitmap? _texture;

    public void LoadTexture(string path)
    {
        _texture?.Dispose();

        _texture = new Bitmap(path);
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
        Core.UndoManager.OnUndo += OnUndo;
        Core.UndoManager.OnRedo += OnRedo;
    }

    private void OnPixelChanged(byte pixel, Color oldColor, Color newColor)
    {
        SetPixel(pixel, newColor);
    }

    private void OnUndo(IUndoCommand command)
    {
        if (command is not PixelColorUndoCommand pc)
            return;

        SetPixel(pc.Pixel, pc.OldColor);
    }

    private void OnRedo(IUndoCommand command)
    {
        if (command is not PixelColorUndoCommand pc)
            return;

        SetPixel(pc.Pixel, pc.NewColor);
    }

    public delegate void TextureChangeDelegate(Bitmap texture);
    public event TextureChangeDelegate? OnTextureChanged;
}
