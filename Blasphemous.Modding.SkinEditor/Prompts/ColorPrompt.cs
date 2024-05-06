
namespace Blasphemous.Modding.SkinEditor.Prompts;

public partial class ColorPrompt : Form
{
    public Color SelectedColor { get; private set; }

    public ColorPrompt(Color initial)
    {
        InitializeComponent();
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
        _preview_text.Text = Hex(SelectedColor);
    }

    private void UpdateRgbTexts()
    {
        _r_text.Text = Hex(SelectedColor.R);
        _g_text.Text = Hex(SelectedColor.G);
        _b_text.Text = Hex(SelectedColor.B);
    }

    private void UpdateRgbSliders()
    {
        _r_slider.Value = SelectedColor.R;
        _g_slider.Value = SelectedColor.G;
        _b_slider.Value = SelectedColor.B;
    }

    private void OnPreviewTextChanged(object _, EventArgs __)
    {
        string rgb = _preview_text.Text.PadLeft(6, '0');
        SelectedColor = ColorTranslator.FromHtml($"#{rgb}");

        UpdatePreviewColor();
        UpdateRgbTexts();
        UpdateRgbSliders();
    }

    private void OnRgbTextChanged(object _, EventArgs __)
    {
        string r = _r_text.Text.PadLeft(2, '0');
        string g = _g_text.Text.PadLeft(2, '0');
        string b = _b_text.Text.PadLeft(2, '0');
        SelectedColor = ColorTranslator.FromHtml($"#{r}{g}{b}");

        UpdatePreviewColor();
        UpdatePreviewText();
        UpdateRgbSliders();
    }

    private void OnRgbSliderChanged(object _, EventArgs __)
    {
        int r = _r_slider.Value;
        int g = _g_slider.Value;
        int b = _b_slider.Value;
        SelectedColor = Color.FromArgb(r, g, b);

        UpdatePreviewColor();
        UpdatePreviewText();
        UpdateRgbTexts();
    }

    private static string Hex(byte b)
    {
        return b.ToString("X2");
    }

    private static string Hex(Color color)
    {
        return $"{Hex(color.R)}{Hex(color.G)}{Hex(color.B)}";
    }
}
