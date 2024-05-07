using Blasphemous.Modding.SkinEditor.Extensions;
using Blasphemous.Modding.SkinEditor.Models;

namespace Blasphemous.Modding.SkinEditor.Prompts;

public partial class InfoPrompt : Form
{
    public SkinInfo SelectedInfo => new(_id_text.Text, _name_text.Text, _author_text.Text, _version_text.Text);

    public InfoPrompt(SkinInfo? initial, bool lockId)
    {
        InitializeComponent();
        _id_text.Enabled = !lockId;

        Logger.Info($"Opening info prompt with {initial?.Id ?? "empty"}");
        UpdateAllText(initial);
    }

    private void UpdateAllText(SkinInfo? info)
    {
        _id_text.Text = info?.Id ?? string.Empty;
        _name_text.Text = info?.Name ?? string.Empty;
        _author_text.Text = info?.Author ?? string.Empty;
        _version_text.Text = info?.Version ?? string.Empty;

        ValidateInfo();
    }

    private void OnInfoTextChanged(object _, EventArgs __)
    {
        ValidateInfo();
    }

    private void ValidateInfo()
    {
        bool idValid = !string.IsNullOrEmpty(_id_text.Text) && !_id_text.Text.HasInvalidCharacter() && _id_text.Text.StartsWith("PENITENT_");
        bool nameValid = !string.IsNullOrEmpty(_name_text.Text);
        bool authorValid = !string.IsNullOrEmpty(_author_text.Text);
        bool versionValid = !string.IsNullOrEmpty(_version_text.Text) && Version.TryParse(_version_text.Text, out _);

        _id_text.BackColor = idValid ? SystemColors.Window : SystemColors.Info;
        _name_text.BackColor = nameValid ? SystemColors.Window : SystemColors.Info;
        _author_text.BackColor = authorValid ? SystemColors.Window : SystemColors.Info;
        _version_text.BackColor = versionValid ? SystemColors.Window : SystemColors.Info;

        _buttons_confirm.Enabled = (idValid || !_id_text.Enabled) && nameValid && authorValid && versionValid;
    }
}
