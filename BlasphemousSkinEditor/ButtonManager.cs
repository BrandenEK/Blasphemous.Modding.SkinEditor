using System.Drawing;
using System.Windows.Forms;

namespace BlasphemousSkinEditor
{
    public class ButtonManager
    {
        private const int BUTTON_SIZE = 30;
        private const int BUTTON_SPACING = 35;

        private readonly Button[] buttons;
        private readonly Button _colorButton;
        private readonly TextBox _colorText;

        private Color _currentColor;

        public ButtonManager(Button currentColorButton, TextBox currentColorText, Panel colorPanel, Bitmap texture)
        {
            _colorButton = currentColorButton;
            _colorText = currentColorText;

            Point start = new Point(10, 30);
            int currBtn = 0;

            buttons = new Button[91];
            foreach (PixelGroup group in pixelGroups)
            {
                // Create header for group
                Label groupHeader = new Label
                {
                    Name = group.name,
                    Parent = colorPanel,
                    Location = new Point(start.X - 10, start.Y - 20),
                    Size = new Size(group.boxSize.Width * BUTTON_SPACING + 15, 18),
                    BackColor = SystemColors.ControlDarkDark,
                    TextAlign = ContentAlignment.TopCenter,
                    Text = group.name,
                };

                // Create buttons for group
                int currPixel = 0;
                for (int row = 0; row < group.boxSize.Height && currPixel < group.pixels.Length; row++)
                {
                    for (int col = 0; col < group.boxSize.Width && currPixel < group.pixels.Length; col++)
                    {
                        int pixelIdx = group.pixels[currPixel];
                        Button button = new Button
                        {
                            Name = pixelIdx.ToString(),
                            Parent = colorPanel,
                            Location = new Point(start.X + BUTTON_SPACING * col, start.Y + BUTTON_SPACING * row),
                            Size = new Size(BUTTON_SIZE, BUTTON_SIZE),
                            BackColor = texture.GetPixel(pixelIdx, 0),
                        };
                        button.MouseDown += new MouseEventHandler(ClickedColorButton);

                        buttons[currBtn] = button;
                        currPixel++;
                        currBtn++;
                    }
                }

                start = new Point(start.X + 20 + BUTTON_SPACING * group.boxSize.Width, start.Y);
            }
        }

        public void UpdateAllButtons(Bitmap texture)
        {
            foreach (Button btn in buttons)
            {
                int pixelIdx = int.Parse(btn.Name);
                btn.BackColor = texture.GetPixel(pixelIdx, 0);
            }
        }

        public void UpdateButton(string pixelIdx, Color color)
        {
            foreach (Button btn in buttons)
            {
                if (btn.Name == pixelIdx)
                {
                    btn.BackColor = color;
                    return;
                }
            }
        }

        private void ClickedColorButton(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            if (e.Button == MouseButtons.Middle)
            {
                SetCurrentColor(btn.BackColor);
                return;
            }

            using (ColorDialog colorPicker = new ColorDialog())
            {
                // Set initial color based on mouse click
                colorPicker.AnyColor = true;
                colorPicker.SolidColorOnly = true;
                colorPicker.FullOpen = true;

                if (e.Button == MouseButtons.Left)
                    colorPicker.Color = btn.BackColor;
                else if (e.Button == MouseButtons.Right)
                    colorPicker.Color = _currentColor;

                // Set texture pixel and update button
                if (colorPicker.ShowDialog() == DialogResult.OK)
                {
                    byte pixelIdx = byte.Parse(btn.Name);
                    SkinForm.Instance.SetTexturePixel(pixelIdx, colorPicker.Color);

                    Color oldColor = btn.BackColor;
                    btn.BackColor = colorPicker.Color;
                    SkinForm.UndoManager.Do(new Command(pixelIdx, colorPicker.Color, oldColor));
                    
                    //MessageBox.Show("Pixel selected: " + int.Parse(btn.Name));
                }
            }
        }

        public void SetCurrentColor(Color color, bool changeText = true)
        {
            _currentColor = color;
            _colorButton.BackColor = color;
            if (changeText)
                _colorText.Text = ColorTranslator.ToHtml(Color.FromArgb(color.ToArgb()));
        }

        private readonly PixelGroup[] pixelGroups = new PixelGroup[]
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
    }
}
