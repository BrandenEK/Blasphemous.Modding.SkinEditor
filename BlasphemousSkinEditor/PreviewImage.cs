using System.Drawing;

namespace BlasphemousSkinEditor
{
    public class PreviewImage
    {
        private readonly Bitmap _basePreview;
        private readonly Bitmap _realPreview;
        private readonly int _scaleFactor;

        public PreviewImage(Bitmap preview, int scaleFactor)
        {
            _basePreview = preview;
            _realPreview = new Bitmap(preview);
            _scaleFactor = scaleFactor;
        }

        // Get a scaled up version of the real texture
        public Bitmap ScaledPreview
        {
            get
            {
                Bitmap scaledPreview = new Bitmap(_realPreview.Width * _scaleFactor, _realPreview.Height * _scaleFactor);

                for (int x = 0; x < scaledPreview.Width; x++)
                {
                    for (int y = 0; y < scaledPreview.Height; y++)
                    {
                        scaledPreview.SetPixel(x, y, _realPreview.GetPixel(x / _scaleFactor, y / _scaleFactor));
                    }
                }

                return scaledPreview;
            }
        }

        // Update the real preview with every pixel in a new texture
        public void UpdatePreview(Bitmap texture)
        {
            for (int x = 0; x < _realPreview.Width; x++)
            {
                for (int y = 0; y < _realPreview.Height; y++)
                {
                    Color pixelColor = _basePreview.GetPixel(x, y);
                    if (pixelColor.A > 0)
                    {
                        _realPreview.SetPixel(x, y, texture.GetPixel(pixelColor.R, 0));
                    }
                }
            }
        }

        // Update the real preview with a single new pixel color
        public void UpdatePreview(int pixelIdx, Color newColor)
        {
            for (int x = 0; x < _realPreview.Width; x++)
            {
                for (int y = 0; y < _realPreview.Height; y++)
                {
                    Color pixelColor = _basePreview.GetPixel(x, y);
                    if (pixelColor.A > 0 && pixelColor.R == pixelIdx)
                    {
                        _realPreview.SetPixel(x, y, newColor);
                    }
                }
            }
        }

        // Performed at the start to convert the base preview to indexed grayscale
        public void IndexPreview(Bitmap texture)
        {
            for (int x = 0; x < _basePreview.Width; x++)
            {
                for (int y = 0; y < _basePreview.Height; y++)
                {
                    Color pixelColor = _basePreview.GetPixel(x, y);
                    if (pixelColor.A == 0) continue;

                    for (int i = 0; i < texture.Width; i++)
                    {
                        if (pixelColor == texture.GetPixel(i, 0))
                        {
                            _basePreview.SetPixel(x, y, Color.FromArgb(i, i, i));
                        }
                    }
                }
            }
        }
    }
}
