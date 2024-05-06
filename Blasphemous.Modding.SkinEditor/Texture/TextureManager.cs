using Blasphemous.Modding.SkinEditor.Undo;

namespace Blasphemous.Modding.SkinEditor.Texture;

public class TextureManager : IManager
{
    private Bitmap _texture;

    public TextureManager()
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
}
