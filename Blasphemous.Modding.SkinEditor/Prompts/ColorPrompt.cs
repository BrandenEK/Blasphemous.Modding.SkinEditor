
namespace Blasphemous.Modding.SkinEditor.Prompts;

public partial class ColorPrompt : Form
{
    public Color SelectedColor { get; private set; }

    private bool _preventEvents = false;

    public ColorPrompt(Color initial)
    {
        InitializeComponent();

        Logger.Info($"Opening color prompt with {initial}");
        SelectedColor = initial;

        UpdatePreviewColor();
        UpdatePreviewText();
        UpdateRgbTexts();
        UpdateRgbSliders();
    }

    private void UpdatePreviewColor()
    {
        _preview_color.BackColor = SelectedColor;
    }

    private void UpdatePreviewText()
    {
        _preventEvents = true;
        _preview_text.Text = Hex(SelectedColor);
        _preventEvents = false;
    }

    private void UpdateRgbTexts()
    {
        _preventEvents = true;
        _r_text.Text = Hex(SelectedColor.R);
        _g_text.Text = Hex(SelectedColor.G);
        _b_text.Text = Hex(SelectedColor.B);
        _preventEvents = false;
    }

    private void UpdateRgbSliders()
    {
        _preventEvents = true;
        _r_slider.Value = SelectedColor.R;
        _g_slider.Value = SelectedColor.G;
        _b_slider.Value = SelectedColor.B;
        _preventEvents = false;
    }

    private void OnPreviewTextChanged(object sender, EventArgs __)
    {
        if (_preventEvents)
            return;

        ValidateHexCharacters((TextBox)sender);

        string rgb = _preview_text.Text.PadRight(6, '0');
        SelectedColor = ColorTranslator.FromHtml($"#{rgb}");

        UpdatePreviewColor();
        UpdateRgbTexts();
        UpdateRgbSliders();
    }

    private void OnRgbTextChanged(object sender, EventArgs __)
    {
        if (_preventEvents)
            return;

        ValidateHexCharacters((TextBox)sender);

        string r = _r_text.Text.PadRight(2, '0');
        string g = _g_text.Text.PadRight(2, '0');
        string b = _b_text.Text.PadRight(2, '0');
        SelectedColor = ColorTranslator.FromHtml($"#{r}{g}{b}");

        UpdatePreviewColor();
        UpdatePreviewText();
        UpdateRgbSliders();
    }

    private void OnRgbSliderChanged(object _, EventArgs __)
    {
        if (_preventEvents)
            return;

        int r = _r_slider.Value;
        int g = _g_slider.Value;
        int b = _b_slider.Value;
        SelectedColor = Color.FromArgb(r, g, b);

        UpdatePreviewColor();
        UpdatePreviewText();
        UpdateRgbTexts();
    }

    private void ValidateHexCharacters(TextBox textbox)
    {
        string text = textbox.Text;
        int selection = textbox.SelectionStart;

        int idx = 0;
        while (idx < text.Length)
        {
            if (!HEX_CHARACTERS.Contains(text[idx]))
            {
                text = text[..idx] + text[(idx + 1)..];
                continue;
            }
            idx++;
        }

        _preventEvents = true;
        textbox.Text = text;
        textbox.SelectionStart = selection;
        _preventEvents = false;
    }

    private const string HEX_CHARACTERS = "0123456789ABCDEF";

    private static string Hex(byte b)
    {
        return b.ToString("X2");
    }

    private static string Hex(Color color)
    {
        return $"{Hex(color.R)}{Hex(color.G)}{Hex(color.B)}";
    }
}
