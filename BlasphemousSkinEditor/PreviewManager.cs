using BlasphemousSkinEditor.Properties;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BlasphemousSkinEditor
{
    public class PreviewManager
    {
        private readonly Dictionary<string, PreviewImage> allPreviews;

        private readonly PictureBox _leftPreviewBox;
        private readonly PictureBox _rightPreviewBox;

        private PreviewImage _leftImage;
        private PreviewImage _rightImage;
        private bool _darkMode;

        public PreviewImage IdlePreview => allPreviews["idle"];
        public PreviewImage ChargedPreview => allPreviews["charged"];

        public PreviewManager(PictureBox left, PictureBox right, Bitmap baseTexture)
        {
            _leftPreviewBox = left;
            _rightPreviewBox = right;

            // Create mapping for all possible preview images
            allPreviews = new Dictionary<string, PreviewImage>()
            {
                { "idle", new PreviewImage(Properties.Resources.idle, 5) },
                { "kneel", new PreviewImage(Properties.Resources.kneel, 4) },
                { "charged", new PreviewImage(Properties.Resources.charged, 3) },
                { "parry", new PreviewImage(Properties.Resources.parry, 3) },
                { "bleed", new PreviewImage(Properties.Resources.cut, 4) },
            };

            // Convert the base previews to grayscale
            foreach (PreviewImage preview in allPreviews.Values)
                preview.IndexPreview(baseTexture);

            // Set background color
            SetBackgroundColor(true);
        }

        public void SetLeftPreviewType(string type)
        {
            _leftImage = allPreviews[type.ToLower()];
            UpdateLeftImageBox();
        }

        public void SetRightPreviewType(string type)
        {
            _rightImage = allPreviews[type.ToLower()];
            UpdateRightImageBox();
        }

        // Updates all images with a new texture than updates the preview boxes
        public void UpdatePreviewImages(Bitmap texture)
        {
            foreach (PreviewImage preview in allPreviews.Values)
                preview.UpdatePreview(texture);

            UpdateLeftImageBox();
            UpdateRightImageBox();
        }

        // Updates all images with a new single color than updates the preview boxes
        public void UpdatePreviewImages(int pixelIdx, Color color)
        {
            foreach (PreviewImage preview in allPreviews.Values)
                preview.UpdatePreview(pixelIdx, color);

            UpdateLeftImageBox();
            UpdateRightImageBox();
        }

        // Updates the preview boxes to use the left & right images
        private void UpdateLeftImageBox()
        {
            if (_leftPreviewBox.Image != null)
                _leftPreviewBox.Image.Dispose();
            _leftPreviewBox.Image = _leftImage.ScaledPreview;
        }
        private void UpdateRightImageBox()
        {
            if (_rightPreviewBox.Image != null)
                _rightPreviewBox.Image.Dispose();
            _rightPreviewBox.Image = _rightImage.ScaledPreview;
        }

        public void ToggleBackgroundColor()
        {
            SetBackgroundColor(!_darkMode);
        }

        private void SetBackgroundColor(bool dark)
        {
            _darkMode = dark;
            Color color = ColorTranslator.FromHtml(dark ? "#110803" : "#202020");
            _leftPreviewBox.BackColor = color;
            _rightPreviewBox.BackColor = color;
        }

        public Bitmap CreateExportPreview(Bitmap texture)
        {
            Bitmap export = new Bitmap(Resources.preview);

            for (int i = 0; i < export.Width; i++)
            {
                for (int j = 0; j < export.Height; j++)
                {
                    Color pixel = export.GetPixel(i, j);
                    if (pixel.R != pixel.G || pixel.R != pixel.B)
                        continue;

                    export.SetPixel(i, j, texture.GetPixel(pixel.R, 0));
                }
            }
            
            return export;
        }
    }
}
