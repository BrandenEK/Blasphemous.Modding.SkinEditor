using System;
using System.Collections.Generic;
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
        byte[] scaleFactors;

        URSystem urSystem;
        Button[] buttons;

        bool darkBackground;
        Color currentColor;
        int preview1 = 0, preview2 = 2;

        public SkinForm()
        {
            InitializeComponent();
        }

        // Load base images, create default texture & previews, set form size, and create color buttons
        private void SkinForm_Load(object sender, EventArgs e)
        {
            // Create bitmaps to store indexed base colors
            baseTexture = Properties.Resources._base;
            basePreviews = new Bitmap[5];
            basePreviews[0] = Properties.Resources.idle;
            basePreviews[1] = Properties.Resources.kneel;
            basePreviews[2] = Properties.Resources.charged;
            basePreviews[3] = Properties.Resources.parry;
            basePreviews[4] = Properties.Resources.cut;

            // Create bitmaps to store the current previews
            realTexture = new Bitmap(baseTexture);
            realPreviews = new Bitmap[5];
            realPreviews[0] = new Bitmap(basePreviews[0]);
            realPreviews[1] = new Bitmap(basePreviews[1]);
            realPreviews[2] = new Bitmap(basePreviews[2]);
            realPreviews[3] = new Bitmap(basePreviews[3]);
            realPreviews[4] = new Bitmap(basePreviews[4]);

            // Set scale factors for each type of preview
            scaleFactors = new byte[] { 5, 4, 3, 3, 4 };

            // Convert the base previews to grayscale
            foreach (Bitmap preview in basePreviews)
                indexPreview(baseTexture, preview);

            // Create color buttons
            createColorButtons();
            colorPanel.SendToBack();
            setCurrentColor(Color.Black);

            // Set initial previews
            previewType1.SelectedIndex = preview1;
            setPreviewType(1, preview1);
            previewType2.SelectedIndex = preview2;
            setPreviewType(2, preview2);
            setPreviewBackgrounds(true);

            // Set form properties
            this.Size = new Size(1305, 800);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Icon = Properties.Resources.icon;
            urSystem = new URSystem();
        }

        #region Color Buttons

        // Create and register all 91 color buttons
        private void createColorButtons()
        {
            Point start = new Point(10, 30);
            int btnSize = 30, currBtn = 0;

            buttons = new Button[91];
            for (int group = 0; group < pixelGroups.Length; group++)
            {
                PixelGroup pixelGroup = pixelGroups[group];
                // Create group label
                Label newLabel = new Label();
                newLabel.Name = pixelGroup.name;
                newLabel.Text = pixelGroup.name;
                newLabel.Size = new Size(pixelGroup.boxSize.Width * (btnSize + 5) + 15, 18);
                newLabel.TextAlign = ContentAlignment.TopCenter;
                newLabel.Location = new Point(start.X - 10, start.Y - 20);
                newLabel.BackColor = SystemColors.ControlDarkDark;
                Controls.Add(newLabel);

                // Create group buttons
                int currPixel = 0;
                for (int row = 0; row < pixelGroup.boxSize.Height && currPixel < pixelGroup.pixels.Length; row++)
                {
                    for (int col = 0; col < pixelGroup.boxSize.Width && currPixel < pixelGroup.pixels.Length; col++)
                    {
                        Button button = new Button();
                        int pixelIdx = pixelGroup.pixels[currPixel];

                        button.Name = pixelIdx.ToString();
                        button.Location = new Point(start.X + (btnSize + 5) * col, start.Y + (btnSize + 5) * row);
                        button.Size = new Size(btnSize, btnSize);
                        button.BackColor = realTexture.GetPixel(pixelIdx, 0);
                        button.MouseDown += new MouseEventHandler(colorButtonClicked);

                        buttons[currBtn] = button;
                        Controls.Add(button);
                        currPixel++;
                        currBtn++;
                    }
                }
                start = new Point(start.X + 20 + (btnSize + 5) * pixelGroup.boxSize.Width, start.Y);
            }
        }

        // When updating a specific color button, set the pixel in the texture
        private void colorButtonClicked(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            if (e.Button == MouseButtons.Middle)
            {
                setCurrentColor(btn.BackColor);
                return;
            }

            if (e.Button == MouseButtons.Left)
                TextureColor.Color = btn.BackColor;
            else if (e.Button == MouseButtons.Right)
                TextureColor.Color = currentColor;

            if (TextureColor.ShowDialog() == DialogResult.OK)
            {
                byte pixelIdx = byte.Parse(btn.Name);
                setTexturePixel(pixelIdx, TextureColor.Color);

                Color oldColor = btn.BackColor;
                btn.BackColor = TextureColor.Color;
                urSystem.Do(new Command(pixelIdx, TextureColor.Color, oldColor));
                // temp
                //MessageBox.Show("Pixel selected: " + int.Parse(btn.Name));
            }
        }

        // Sets the specific pixel in the texture and updates previews
        private void setTexturePixel(byte pixelIdx, Color newColor)
        {
            realTexture.SetPixel(pixelIdx, 0, newColor);
            for (int i = 0; i < realPreviews.Length; i++)
                updatePreview(i, pixelIdx, newColor);

            setPreviewImage(previewImage1, preview1);
            setPreviewImage(previewImage2, preview2);
        }

        #endregion Color Buttons

        #region Import Texture

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
            using (Bitmap fileTexture = new Bitmap(path))
            {
                if (fileTexture.Width != 256 || fileTexture.Height != 1)
                {
                    MessageBox.Show("Error: The texture must be 256x1 pixels!", "Import Texture");
                    return;
                }

                realTexture = new Bitmap(fileTexture);
            }

            for (int i = 0; i < realPreviews.Length; i++)
                updatePreview(i, realTexture);

            foreach (Button btn in buttons)
            {
                int pixelIdx = int.Parse(btn.Name);
                btn.BackColor = realTexture.GetPixel(pixelIdx, 0);
            }

            setPreviewImage(previewImage1, preview1);
            setPreviewImage(previewImage2, preview2);
        }

        #endregion Import Texture

        #region Export Texture

        // Exports the current texture to the output folder
        private void exportBtn_Click(object sender, EventArgs e)
        {
            // Temp
            //foreach (Button btn in buttons)
            //{
            //    int pixelIdx = int.Parse(btn.Name);
            //    if (foundPixels.Contains(pixelIdx))
            //        btn.BackColor = Color.Magenta;
            //}

            int knownPixels = 0;
            //knownPixels = foundPixels.Count;
            foreach (PixelGroup group in pixelGroups)
                if (group.name != "Unknown")
                    knownPixels += group.pixels.Length;

            //MessageBox.Show(knownPixels + "/91 pixels found", "Pixel finder");
            //foreach (PixelGroup group in pixelGroups)
            //{
            //    if (group.name != "Unknown")
            //    {
            //        foreach (byte pixel in group.pixels)
            //            setTexturePixel(pixel, Color.Black);
            //    }
            //    else
            //    {
            //        foreach (byte pixel in group.pixels)
            //            setTexturePixel(pixel, Color.Magenta);
            //    }
            //}
            //return;

            string skinName = nameText.Text;
            if (skinName == null || skinName == "")
            {
                MessageBox.Show("No skin name has been selected!", "Export Texture");
                return;
            }

            string path = Environment.CurrentDirectory + "\\output\\" + skinName + "\\";
            Directory.CreateDirectory(path);
            exportTexture(path);
        }

        // For the texture and each preview, saves them to a filestream in the output folder
        private void exportTexture(string path)
        {
            realTexture.Save(path + "texture.png", System.Drawing.Imaging.ImageFormat.Png);
            Bitmap scaledIdle = scalePreview(realPreviews[0], scaleFactors[0]);
            scaledIdle.Save(path + "idlePreview.png", System.Drawing.Imaging.ImageFormat.Png);
            Bitmap scaledCharged = scalePreview(realPreviews[2], scaleFactors[2]);
            scaledCharged.Save(path + "chargedPreview.png", System.Drawing.Imaging.ImageFormat.Png);
            MessageBox.Show("Texture successfully saved!", "Export Texture");
        }

        #endregion Export Texture

        #region Update Previews

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
        }

        // Takes in the preview image and scales it up before setting the preview image
        private void setPreviewImage(PictureBox box, int previewIdx)
        {
            Bitmap scaledPreview = scalePreview(realPreviews[previewIdx], scaleFactors[previewIdx]);
            box.Image = scaledPreview;
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
                            foundPixel(i);
                        }
                    }
                }
            }
        }

        #endregion Update Previews

        #region Selected Previews

        private void previewType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setPreviewType(1, previewType1.SelectedIndex);
        }

        private void previewType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            setPreviewType(2, previewType2.SelectedIndex);
        }

        // When selecting new option from dropdown changes preview image
        private void setPreviewType(int boxIdx, int previewIdx)
        {
            if (boxIdx == 1)
            {
                preview1 = previewIdx;
                setPreviewImage(previewImage1, previewIdx);
            }
            else
            {
                preview2 = previewIdx;
                setPreviewImage(previewImage2, previewIdx);
            }
        }

        #endregion Selected Previews

        #region Current Color

        private void currentText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Up || e.KeyCode == Keys.Home)
                e.Handled = true;
        }

        private void currentText_MouseDown(object sender, MouseEventArgs e)
        {
            currentText.SelectionStart = currentText.Text.Length;
            currentText.SelectionLength = 0;
        }

        private void currentText_TextChanged(object sender, EventArgs e)
        {
            string text = currentText.Text.ToUpper();
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (!((c >= '0' && c <= '9') || (c >= 'A' && c <= 'F')))
                {
                    text = text.Substring(0, i) + text.Substring(i + 1);
                    i--;
                }
            }

            text = "#" + text;
            currentText.SelectionStart = currentText.Text.Length;
            currentText.SelectionLength = 0;

            if (text.Length == 7)
            {
                setCurrentColor(ColorTranslator.FromHtml(text));
            }
            else
            {
                setCurrentColor(Color.Black, false);
                currentText.Text = text;
            }
        }

        // Updates the current color
        private void setCurrentColor(Color color, bool changeText = true)
        {
            currentColor = color;
            currentBtn.BackColor = color;
            if (changeText)
                currentText.Text = ColorTranslator.ToHtml(Color.FromArgb(color.ToArgb()));
        }

        #endregion Current Color

        #region Undo Redo

        private void undoBtn_Click(object sender, EventArgs e)
        {
            Command command = urSystem.Undo();
            if (command == null) return;

            setTexturePixel(command.pixelIdx, command.oldColor);
            foreach (Button btn in buttons)
            {
                if (btn.Name == command.pixelIdx.ToString())
                {
                    btn.BackColor = command.oldColor;
                    return;
                }
            }
        }

        private void redoBtn_Click(object sender, EventArgs e)
        {
            Command command = urSystem.Redo();
            if (command == null) return;

            setTexturePixel(command.pixelIdx, command.newColor);
            foreach (Button btn in buttons)
            {
                if (btn.Name == command.pixelIdx.ToString())
                {
                    btn.BackColor = command.newColor;
                    return;
                }
            }
        }

        #endregion Undo Redo

        #region Preview Backgrounds

        private void backgroundBtn_Click(object sender, EventArgs e)
        {
            setPreviewBackgrounds(!darkBackground);
        }

        private void setPreviewBackgrounds(bool darkMode)
        {
            darkBackground = darkMode;
            Color color = ColorTranslator.FromHtml(darkMode ? "#110803" : "#202020");
            previewImage1.BackColor = color;
            previewImage2.BackColor = color;
        }

        #endregion Preview Backgrounds

        private List<int> foundPixels = new List<int>();
        private void foundPixel(int pixel)
        {
            if (!foundPixels.Contains(pixel))
                foundPixels.Add(pixel);
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

        PixelGroup[] pixelGroups = new PixelGroup[]
        {
            new PixelGroup("Chest", new Size(2, 3), new byte[] { 28, 54, 90, 134, 186 }),
            new PixelGroup("Helmet", new Size(1, 4), new byte[] { 48, 78, 118, 163 }),
            new PixelGroup("Misc. Armor", new Size(2, 3), new byte[] { 23, 40, 76, 86, 217 }),
            new PixelGroup("Leather", new Size(2, 4), new byte[] { 16, 34, 43, 44, 62, 63, 83, 87, }),
            new PixelGroup("Cloth", new Size(2, 3), new byte[] { 46, 11, 60, 139, 188 }),
            new PixelGroup("Sword", new Size(1, 4), new byte[] { 141, 140, 175, 189 }),
            new PixelGroup("Blood", new Size(2, 3), new byte[] { 41, 26, 53, 49, 25, 24 }),
            new PixelGroup("Rocks", new Size(2, 3), new byte[] { 32, 51, 80, 94, 97 }),
            new PixelGroup("Effects", new Size(3, 3), new byte[] { 39, 1, 2, 142, 145, 179, 255, 71, 99 }),
            new PixelGroup("Abilities", new Size(3, 4), new byte[] { 89, 138, 160, 183, 208, 187, 230, 234, 238 }),
            //new PixelGroup("Parry", new Size(1, 2), new byte[] {  }),
            new PixelGroup("Healing", new Size(1, 4), new byte[] { 64, 98, 133, 233 }),
            new PixelGroup("White", new Size(1, 1), new byte[] { 251 }),

            new PixelGroup("Unknown", new Size(7, 4), new byte[]
            {
                0, 21, 22, 29, 31, 33, 35,
                42, 45, 47, 50, 52, 55,
                56, 57, 58, 59, 61, 65, 75,
                88, 127, 132, 151, 171, 199
            })
        };
    }

    class PixelGroup
    {
        public string name;
        public Size boxSize;
        public byte[] pixels;

        public PixelGroup(string name, Size boxSize, byte[] pixels)
        {
            this.name = name;
            this.boxSize = boxSize;
            this.pixels = pixels;
        }
    }
}
