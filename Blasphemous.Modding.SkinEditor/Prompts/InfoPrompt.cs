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

        UpdateAllText();
    }

    private void UpdateAllText()
    {
        _id_text.Text = SelectedInfo?.Id ?? string.Empty;
        _name_text.Text = SelectedInfo?.Name ?? string.Empty;
        _author_text.Text = SelectedInfo?.Author ?? string.Empty;
        _version_text.Text = SelectedInfo?.Version ?? string.Empty;

        ValidateInfo();
    }

    private void ValidateInfo()
    {
        bool isValid = true;

        if (string.IsNullOrEmpty(_id_text.Text) || !_id_text.Text.StartsWith("PENITENT_"))
            isValid = false;

        if (string.IsNullOrEmpty(_name_text.Text))
            isValid = false;

        if (string.IsNullOrEmpty(_author_text.Text))
            isValid = false;

        if (string.IsNullOrEmpty(_version_text.Text) || !Version.TryParse(_version_text.Text, out _))
            isValid = false;

        _buttons_confirm.Enabled = isValid;
    }

    private void OnInfoTextChanged(object _, EventArgs __)
    {
        ValidateInfo();
    }
}
