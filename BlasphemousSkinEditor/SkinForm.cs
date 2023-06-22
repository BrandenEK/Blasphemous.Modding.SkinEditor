using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlasphemousSkinEditor
{
    public partial class SkinForm : Form
    {
        public static SkinForm Instance { get; private set; }

        private readonly Skin _currentSkinSettings;
        public void UpdateSkinSettings(Skin settings)
        {
            _currentSkinSettings.id = settings.id;
            _currentSkinSettings.name = settings.name;
            _currentSkinSettings.author = settings.author;
            _currentSkinSettings.version = settings.version;
        }

        private readonly Bitmap _baseTexture;

        private Bitmap _realTexture;
        public Bitmap RealTexture
        {
            set
            {
                if (_realTexture != null)
                    _realTexture.Dispose();

                _realTexture = new Bitmap(value);
            }
        }

        // New
        public static ButtonManager ButtonManager { get; private set; }
        public static PreviewManager PreviewManager { get; private set; }
        public static UndoManager UndoManager { get; private set; }
        public static Importer Importer { get; private set; }
        public static Exporter Exporter { get; private set; }

        public SkinForm()
        {
            InitializeComponent();
            if (Instance == null) Instance = this;

            _currentSkinSettings = new Skin(UNKNOWN_ID, UNKNOWN_NAME, UNKNOWN_AUTHOR, UNKNOWN_VERSION);

            _baseTexture = Properties.Resources._base;
            RealTexture = _baseTexture;

            ButtonManager = new ButtonManager(currentBtn, currentText, colorPanel, _realTexture);
            PreviewManager = new PreviewManager(previewImage1, previewImage2, _baseTexture);
            UndoManager = new UndoManager();
            Importer = new Importer();
            Exporter = new Exporter();
        }

        // Load base images, create default texture & previews, set form size (Less now)
        private void SkinForm_Load(object sender, EventArgs e)
        {
            // Set initial previews
            previewType1.SelectedIndex = 0;
            previewType2.SelectedIndex = 2;

            ButtonManager.SetCurrentColor(Color.Black);

            // Set form properties
            this.Size = new Size(1305, 800);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Icon = Properties.Resources.icon;
        }

        // Sets the specific pixel in the texture and updates previews
        public void SetTexturePixel(byte pixelIdx, Color newColor)
        {
            _realTexture.SetPixel(pixelIdx, 0, newColor);
            PreviewManager.UpdatePreviewImages(pixelIdx, newColor);
        }

        private void ClickedImport(object sender, EventArgs e)
        {
            Importer.ImportTexture();
        }

        private void ClickedExport(object sender, EventArgs e)
        {
            Exporter.ExportTexture(_currentSkinSettings, _realTexture);
        }

        private void ClickedPreviewBackgroundToggle(object sender, EventArgs e)
        {
            PreviewManager.ToggleBackgroundColor();
        }

        private void ChangedLeftPreviewSelection(object sender, EventArgs e)
        {
            PreviewManager.SetLeftPreviewType(previewType1.SelectedItem.ToString());
        }

        private void ChangedRightPreviewSelection(object sender, EventArgs e)
        {
            PreviewManager.SetRightPreviewType(previewType2.SelectedItem.ToString());
        }

        private void ClickedUndo(object sender, EventArgs e)
        {
            Command command = UndoManager.Undo();
            if (command == null) return;

            SetTexturePixel(command.pixelIdx, command.oldColor);
            ButtonManager.UpdateButton(command.pixelIdx.ToString(), command.oldColor);
        }

        private void ClickedRedo(object sender, EventArgs e)
        {
            Command command = UndoManager.Redo();
            if (command == null) return;

            SetTexturePixel(command.pixelIdx, command.newColor);
            ButtonManager.UpdateButton(command.pixelIdx.ToString(), command.newColor);
        }

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
                ButtonManager.SetCurrentColor(ColorTranslator.FromHtml(text));
            }
            else
            {
                ButtonManager.SetCurrentColor(Color.Black, false);
                currentText.Text = text;
            }
        }

        public const string UNKNOWN_ID = "PENITENT_XX_DEFAULT";
        public const string UNKNOWN_NAME = "Default Name";
        public const string UNKNOWN_AUTHOR = "Default Author";
        public const string UNKNOWN_VERSION = "1.0.0";
    }
}
