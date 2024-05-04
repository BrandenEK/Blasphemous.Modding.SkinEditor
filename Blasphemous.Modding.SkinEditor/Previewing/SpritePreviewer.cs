
namespace Blasphemous.Modding.SkinEditor.Previewing;

public class SpritePreviewer : ISpritePreviewer
{
    private readonly PictureBox _pictureBox;

    private Bitmap? _preview;
    private int _lastScale = 1;

    public SpritePreviewer(PictureBox pictureBox)
    {
        _pictureBox = pictureBox;
        _pictureBox.SizeChanged += OnPictureResized;
    }

    private void OnPictureResized(object? sender, EventArgs e)
    {
        if (_preview == null || _pictureBox.Image == null || _lastScale == CurrentScale)
            return;

        Logger.Warn("Resizing preview image");
        DisplayScaledPreview();
    }

    private void DisplayScaledPreview()
    {
        int currentScale = CurrentScale;
        Bitmap? newPreview = _preview == null ? null : ScalePreview(_preview, currentScale);

        _pictureBox.Image?.Dispose();
        _pictureBox.Image = newPreview;
        _lastScale = currentScale;
    }

    private Bitmap ScalePreview(Bitmap preview, int factor)
    {
        Bitmap scaled = new(preview.Width * factor, preview.Height * factor);

        for (int x = 0; x < scaled.Width; x++)
        {
            for (int y = 0; y < scaled.Height; y++)
            {
                scaled.SetPixel(x, y, preview.GetPixel(x / factor, y / factor));
            }
        }

        return scaled;
    }

    public void Update(Bitmap preview)
    {
        _preview?.Dispose();
        _preview = preview;

        DisplayScaledPreview();
    }

    private int CurrentScale => _preview == null
        ? -1
        : Math.Min(_pictureBox.Size.Width / _preview!.Width, _pictureBox.Size.Height / _preview.Height);
}
