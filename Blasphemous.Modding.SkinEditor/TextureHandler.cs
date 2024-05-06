
using Blasphemous.Modding.SkinEditor.Undo;

namespace Blasphemous.Modding.SkinEditor;

public class TextureHandler
{
    private Bitmap _texture;

    public TextureHandler()
    {
        string path = Path.Combine(Environment.CurrentDirectory, "data", "default.png");
        _texture = new Bitmap(path);
    }

    public void Initialize()
    {
        Core.UndoManager.OnUndo += OnUndo;
        Core.UndoManager.OnRedo += OnRedo;
    }

    public void SetPixel(byte pixel, Color color)
    {
        _texture.SetPixel(pixel, 0, color);
    }

    public Color GetPixel(byte pixel)
    {
        return _texture.GetPixel(pixel, 0);
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
