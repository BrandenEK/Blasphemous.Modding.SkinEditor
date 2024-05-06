
namespace Blasphemous.Modding.SkinEditor.Prompts;

public partial class ColorPrompt : Form
{
    public Color SelectedColor { get; private set; }

    public ColorPrompt(Color initial)
    {
        InitializeComponent();
        SelectedColor = initial;

        UpdatePreviewColor();
    }

    private void UpdatePreviewColor()
    {
        _preview_color.BackColor = SelectedColor;
    }
}
