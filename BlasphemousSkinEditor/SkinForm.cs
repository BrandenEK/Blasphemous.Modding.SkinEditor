using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace BlasphemousSkinEditor
{
    public partial class SkinForm : Form
    {
        Bitmap baseTexture;
        Bitmap[] basePreviews;

        Bitmap realTexture;
        Bitmap[] realPreviews;

        Button[] buttons;
        PictureBox[] previewImages;
        byte[] scaleFactors = new byte[] { 4, 2 };

        public SkinForm()
        {
            InitializeComponent();
        }

        // Load base images, create default texture & previews, set form size, and create color buttons
        private void SkinForm_Load(object sender, EventArgs e)
        {
            basePreviews = new Bitmap[2];
            baseTexture = Properties.Resources._base;
            basePreviews[0] = Properties.Resources.idle;
            basePreviews[1] = Properties.Resources.charged;

            realTexture = new Bitmap(baseTexture);
            realPreviews = new Bitmap[2];
            realPreviews[0] = new Bitmap(basePreviews[0]);
            realPreviews[1] = new Bitmap(basePreviews[1]);

            foreach (Bitmap preview in basePreviews)
                indexPreview(baseTexture, preview);

            previewImages = new PictureBox[] { idlePrev, chargePrev };
            for (int i = 0; i < previewImages.Length; i++)
                setPreviewImage(i, realPreviews[i]);
            createColorButtons();
            colorPanel.SendToBack();

            this.Size = new Size(1305, 800);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            importBtn.Location = new Point(1090, 90);
            importBtn.Size = new Size(90, 30);
            exportBtn.Location = new Point(1190, 90);
            exportBtn.Size = new Size(90, 30);

        }

        // Create and register all 91 color buttons
        private void createColorButtons()
        {
            Point start = new Point(10, 10);
            int buttonsPerRow = 32, currIdx = 0;

            buttons = new Button[validPixels.Length];
            while (currIdx < validPixels.Length)
            {
                for (int i = 0; i < buttonsPerRow && currIdx < validPixels.Length; i++)
                {
                    Button button = new Button();
                    button.Name = validPixels[currIdx].ToString();
                    button.Location = new Point(start.X + (40 * i), start.Y + (40 * (currIdx / buttonsPerRow)));
                    button.Size = new Size(30, 30);
                    button.BackColor = realTexture.GetPixel(validPixels[currIdx], 0);
                    button.Click += new EventHandler(colorButtonClicked);

                    buttons[currIdx] = button;
                    Controls.Add(button);
                    currIdx++;
                }
            }
        }

        // When updating a specific color button, set the pixel in the texture
        private void colorButtonClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TextureColor.Color = btn.BackColor;
            if (TextureColor.ShowDialog() == DialogResult.OK)
            {
                setTexturePixel(int.Parse(btn.Name), TextureColor.Color);
                btn.BackColor = TextureColor.Color;
            }
        }

        // Sets the specific pixel in the texture and updates previews
        private void setTexturePixel(int pixelIdx, Color newColor)
        {
            realTexture.SetPixel(pixelIdx, 0, newColor);
            for (int i = 0; i < previewImages.Length; i++)
                updatePreview(i, pixelIdx, newColor);
        }

        // Asks where to import the texture from
        private void importBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Import existing texture";
                dialog.Filter = "PNG files (*.png)|*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    importTexture(dialog.FileName);
                }
            }
        }

        // Imports a texture and updates the previews & color buttons entirely
        private void importTexture(string path)
        {
            Bitmap newTexture = new Bitmap(path);
            if (newTexture.Width != 256 || newTexture.Height != 1)
            {
                MessageBox.Show("Error: The texture must be 256x1 pixels!", "Import Texture");
                return;
            }

            realTexture = newTexture;
            for (int i = 0; i < previewImages.Length; i++)
                updatePreview(i, newTexture);
            foreach (Button btn in buttons)
            {
                int pixelIdx = int.Parse(btn.Name);
                btn.BackColor = newTexture.GetPixel(pixelIdx, 0);
            }
        }

        // Exports the current texture to the output folder
        private void exportBtn_Click(object sender, EventArgs e)
        {
            string path = Environment.CurrentDirectory + "\\output\\";
            Directory.CreateDirectory(path);
            exportTexture(path);
        }

        // For the texture and each preview, saves them to a filestream in the output folder
        private void exportTexture(string path)
        {
            realTexture.Save(path + "texture.png", System.Drawing.Imaging.ImageFormat.Png);
            Bitmap scaledIdle = scalePreview(realPreviews[0], scaleFactors[0]);
            scaledIdle.Save(path + "idlePreview.png", System.Drawing.Imaging.ImageFormat.Png);
            Bitmap scaledCharged = scalePreview(realPreviews[1], scaleFactors[1]);
            scaledCharged.Save(path + "chargedPreview.png", System.Drawing.Imaging.ImageFormat.Png);
            MessageBox.Show("Texture successfully saved!", "Export Texture");
        }

        // Updates the preview with a single new pixel color
        private void updatePreview(int previewIdx, int pixelIdx, Color newColor)
        {
            Bitmap preview = realPreviews[previewIdx];
            Bitmap basePreview = basePreviews[previewIdx];

            for (int x = 0; x < preview.Width; x++)
            {
                for (int y = 0; y < preview.Height; y++)
                {
                    Color pixelColor = basePreview.GetPixel(x, y);
                    if (pixelColor.A > 0 && pixelColor.R == pixelIdx)
                    {
                        preview.SetPixel(x, y, newColor);
                    }
                }
            }
            setPreviewImage(previewIdx, preview);
        }

        // Updates the preview with every pixel in the texture
        private void updatePreview(int previewIdx, Bitmap texture)
        {
            Bitmap preview = realPreviews[previewIdx];
            Bitmap basePreview = basePreviews[previewIdx];

            for (int x = 0; x < preview.Width; x++)
            {
                for (int y = 0; y < preview.Height; y++)
                {
                    Color pixelColor = basePreview.GetPixel(x, y);
                    if (pixelColor.A > 0)
                    {
                        preview.SetPixel(x, y, texture.GetPixel(pixelColor.R, 0));
                    }
                }
            }
            setPreviewImage(previewIdx, preview);
        }

        // Takes in the preview image and scales it up before setting the preview image
        private void setPreviewImage(int previewIdx, Bitmap preview)
        {
            PictureBox previewImage = previewImages[previewIdx];
            Bitmap scaledPreview = scalePreview(preview, scaleFactors[previewIdx]);
            previewImage.Size = new Size(scaledPreview.Width, scaledPreview.Height);
            previewImage.Image = scaledPreview;
        }

        private Bitmap scalePreview(Bitmap preview, int scaleFactor)
        {
            Bitmap scaledPreview = new Bitmap(preview.Width * scaleFactor, preview.Height * scaleFactor);

            for (int x = 0; x < scaledPreview.Width; x++)
            {
                for (int y = 0; y < scaledPreview.Height; y++)
                {
                    scaledPreview.SetPixel(x, y, preview.GetPixel(x / scaleFactor, y / scaleFactor));
                }
            }

            return scaledPreview;
        }

        // Performed at the start to convert the base preview to indexed grayscale
        private void indexPreview(Bitmap texture, Bitmap preview)
        {
            for (int x = 0; x < preview.Width; x++)
            {
                for (int y = 0; y < preview.Height; y++)
                {
                    Color pixelColor = preview.GetPixel(x, y);
                    if (pixelColor.A == 0) continue;

                    for (int i = 0; i < texture.Width; i++)
                    {
                        if (pixelColor == texture.GetPixel(i, 0))
                        {
                            preview.SetPixel(x, y, Color.FromArgb(i, i, i));
                        }
                    }
                }
            }
        }

        byte[] validPixels = new byte[]
        {
            0, 1, 2, 11, 16, 21, 22, 23, 24, 25, 26, 28, 29, 31, 32, 33, 34, 35,
            39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55,
            56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 71, 75, 76, 78, 80, 83, 86,
            87, 88, 89, 90, 94, 97, 98, 99, 118, 127, 132, 133, 134, 138, 139,
            140, 141, 142, 145, 151, 160, 163, 171, 175, 179, 183, 186, 187,
            188, 189, 199, 208, 217, 230, 233, 234, 238, 251, 255
        };
    }
}
