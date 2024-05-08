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
        InvalidInfoReason reason = InvalidInfoReason.None;

        if (string.IsNullOrEmpty(_id_text.Text)) reason |= InvalidInfoReason.IdEmpty;
        if (!_id_text.Text.StartsWith("PENITENT_")) reason |= InvalidInfoReason.IdPenitent;
        if (_id_text.Text.HasInvalidCharacter()) reason |= InvalidInfoReason.IdCharacters;
        if (Directory.Exists(Path.Combine(Core.SkinsFolder, _id_text.Text))) reason |= InvalidInfoReason.IdExisting;

        if (string.IsNullOrEmpty(_name_text.Text)) reason |= InvalidInfoReason.NameEmpty;

        if (string.IsNullOrEmpty(_author_text.Text)) reason |= InvalidInfoReason.AuthorEmpty;

        if (string.IsNullOrEmpty(_version_text.Text)) reason |= InvalidInfoReason.VersionEmpty;
        if (!Version.TryParse(_version_text.Text, out _)) reason |= InvalidInfoReason.VersionParse;

        if (!_id_text.Enabled)
            reason &= ~InvalidInfoReason.IdInvalid;

        _id_text.BackColor = (reason & InvalidInfoReason.IdInvalid) != 0 ? SystemColors.Info : SystemColors.Window;
        _name_text.BackColor = (reason & InvalidInfoReason.NameInvalid) != 0 ? SystemColors.Info : SystemColors.Window;
        _author_text.BackColor = (reason & InvalidInfoReason.AuthorInvalid) != 0 ? SystemColors.Info : SystemColors.Window;
        _version_text.BackColor = (reason & InvalidInfoReason.VersionInvalid) != 0 ? SystemColors.Info : SystemColors.Window;

        _buttons_confirm.Enabled = reason == InvalidInfoReason.None;
        SetToolTip(reason);
    }

    private void SetToolTip(InvalidInfoReason reason)
    {
        if (reason == InvalidInfoReason.None)
        {
            _tooltip.RemoveAll();
            return;
        }

        _tooltip.SetToolTip(_id_label, reason switch
        {
            var _ when reason.HasFlag(InvalidInfoReason.IdEmpty) => "Id must not be blank",
            var _ when reason.HasFlag(InvalidInfoReason.IdPenitent) => "Id must begin with 'PENITENT_'",
            var _ when reason.HasFlag(InvalidInfoReason.IdCharacters) => "Id must not contain invalid characters",
            var _ when reason.HasFlag(InvalidInfoReason.IdExisting) => "Id must not already exist",
            _ => string.Empty
        });

        _tooltip.SetToolTip(_name_label, reason switch
        {
            var _ when reason.HasFlag(InvalidInfoReason.NameEmpty) => "Name must not be blank",
            _ => string.Empty
        });

        _tooltip.SetToolTip(_author_label, reason switch
        {
            var _ when reason.HasFlag(InvalidInfoReason.AuthorEmpty) => "Author must not be blank",
            _ => string.Empty
        });

        _tooltip.SetToolTip(_version_label, reason switch
        {
            var _ when reason.HasFlag(InvalidInfoReason.VersionEmpty) => "Version must not be blank",
            var _ when reason.HasFlag(InvalidInfoReason.VersionParse) => "Version must be valid",
            _ => string.Empty
        });
    }

    [Flags]
    enum InvalidInfoReason
    {
        None = 0x00,
        IdEmpty = 0x01,
        IdPenitent = 0x02,
        IdCharacters = 0x04,
        NameEmpty = 0x08,
        AuthorEmpty = 0x10,
        VersionEmpty = 0x20,
        VersionParse = 0x40,
        IdExisting = 0x80,

        IdInvalid = IdEmpty | IdPenitent | IdCharacters | IdExisting,
        NameInvalid = NameEmpty,
        AuthorInvalid = AuthorEmpty,
        VersionInvalid = VersionEmpty | VersionParse,

        AnyInvalid = IdInvalid | NameInvalid | AuthorInvalid | VersionInvalid,
    }
}
