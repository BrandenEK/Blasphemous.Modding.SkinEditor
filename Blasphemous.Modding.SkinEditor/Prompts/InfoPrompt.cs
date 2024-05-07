using Blasphemous.Modding.SkinEditor.Models;

namespace Blasphemous.Modding.SkinEditor.Prompts;

public partial class InfoPrompt : Form
{
    public SkinInfo? SelectedInfo { get; set; } //not nullable by end

    public InfoPrompt(SkinInfo? initial, bool lockId)
    {
        InitializeComponent();
        _id_text.Enabled = !lockId;

        Logger.Info($"Opening info prompt with {initial}");
        SelectedInfo = initial;

        // Update all info
    }
}
