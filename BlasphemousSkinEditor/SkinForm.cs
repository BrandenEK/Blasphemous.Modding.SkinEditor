﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace BlasphemousSkinEditor
{
    public partial class SkinForm : Form
    {
        Bitmap baseTexture;
        Bitmap realTexture;
        Dictionary<string, PreviewImage> allPreviews;

        public static SkinForm Instance { get; private set; }

        private readonly Skin _currentSkinSettings;

        public void UpdateSkinSettings(Skin settings)
        {
            _currentSkinSettings.id = settings.id;
            _currentSkinSettings.name = settings.name;
            _currentSkinSettings.author = settings.author;
            _currentSkinSettings.version = settings.version;
        }

        URSystem urSystem;
        Button[] buttons;

        bool darkBackground;
        Color currentColor;
        PreviewImage preview1, preview2;

        // New
        public Exporter Exporter { get; private set; }

        public SkinForm()
        {
            if (Instance == null) Instance = this;
            // New
            Exporter = new Exporter();

            _currentSkinSettings = new Skin(UNKNOWN_ID, UNKNOWN_NAME, UNKNOWN_AUTHOR, UNKNOWN_VERSION);

            InitializeComponent();
        }

        // Load base images, create default texture & previews, set form size, and create color buttons
        private void SkinForm_Load(object sender, EventArgs e)
        {
            // Create initial texture & previews
            allPreviews = new Dictionary<string, PreviewImage>()
            {
                { "idle", new PreviewImage(Properties.Resources.idle, 5) },
                { "kneel", new PreviewImage(Properties.Resources.kneel, 4) },
                { "charged", new PreviewImage(Properties.Resources.charged, 3) },
                { "parry", new PreviewImage(Properties.Resources.parry, 3) },
                { "bleed", new PreviewImage(Properties.Resources.cut, 4) },
            };
            baseTexture = Properties.Resources._base;
            realTexture = new Bitmap(baseTexture);

            // Convert the base previews to grayscale
            foreach (PreviewImage preview in allPreviews.Values)
                preview.IndexPreview(baseTexture);

            // Create color buttons
            createColorButtons();
            colorPanel.SendToBack();
            setCurrentColor(Color.Black);

            // Set initial previews
            previewType1.SelectedIndex = 0;
            previewType2.SelectedIndex = 2;
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
            foreach (PreviewImage preview in allPreviews.Values)
                preview.UpdatePreview(pixelIdx, newColor);

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

                realTexture.Dispose();
                realTexture = new Bitmap(fileTexture);
            }

            foreach (PreviewImage preview in allPreviews.Values)
                preview.UpdatePreview(realTexture);

            foreach (Button btn in buttons)
            {
                int pixelIdx = int.Parse(btn.Name);
                btn.BackColor = realTexture.GetPixel(pixelIdx, 0);
            }

            setPreviewImage(previewImage1, preview1);
            setPreviewImage(previewImage2, preview2);

            string infoPath = path.Substring(0, path.LastIndexOf("\\") + 1) + "info.txt";
            if (File.Exists(infoPath))
            {
                string jsonString = File.ReadAllText(infoPath);
                UpdateSkinSettings(JsonConvert.DeserializeObject<Skin>(jsonString));
            }
            else
            {
                UpdateSkinSettings(new Skin(UNKNOWN_ID, UNKNOWN_NAME, UNKNOWN_AUTHOR, UNKNOWN_VERSION));
            }

            urSystem.Reset();
        }

        #endregion Import Texture

        #region Selected Previews

        private void previewType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setPreviewType(1, previewType1.SelectedItem.ToString());
        }

        private void previewType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            setPreviewType(2, previewType2.SelectedItem.ToString());
        }

        // When selecting new option from dropdown changes preview image
        private void setPreviewType(int boxIdx, string previewName)
        {
            if (boxIdx == 1)
            {
                preview1 = allPreviews[previewName.ToLower()];
                setPreviewImage(previewImage1, allPreviews[previewName.ToLower()]);
            }
            else
            {
                preview2 = allPreviews[previewName.ToLower()];
                setPreviewImage(previewImage2, allPreviews[previewName.ToLower()]);
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



        // Takes in the preview image and scales it up before setting the preview image
        private void setPreviewImage(PictureBox box, PreviewImage previewImage)
        {
            if (box.Image != null)
                box.Image.Dispose();
            Bitmap scaledPreview = previewImage.ScaledPreview;
            box.Image = scaledPreview;
        }


        private void ClickedExport(object sender, EventArgs e)
        {
            Exporter.ExportTexture(_currentSkinSettings, realTexture, allPreviews["idle"], allPreviews["charged"]);
        }


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
            new PixelGroup("Healing", new Size(2, 3), new byte[] { 64, 98, 133, 233, 199 }),
            new PixelGroup("White", new Size(1, 1), new byte[] { 251 }),

            new PixelGroup("Unknown", new Size(7, 4), new byte[]
            {
                0, 21, 22, 29, 31, 33, 35,
                42, 45, 47, 50, 52, 55,
                56, 57, 58, 59, 61, 65, 75,
                88, 127, 132, 151, 171
            })
        };

        public const string UNKNOWN_ID = "PENITENT_XX_DEFAULT";
        public const string UNKNOWN_NAME = "Default Name";
        public const string UNKNOWN_AUTHOR = "Default Author";
        public const string UNKNOWN_VERSION = "1.0.0";
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
