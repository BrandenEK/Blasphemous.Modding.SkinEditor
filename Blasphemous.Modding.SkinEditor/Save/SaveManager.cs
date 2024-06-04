using Basalt.Framework.Logging;
using Blasphemous.Modding.SkinEditor.Models;
using Blasphemous.Modding.SkinEditor.Prompts;
using Blasphemous.Modding.SkinEditor.Undo;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Blasphemous.Modding.SkinEditor.Save;

public class SaveManager : IManager
{
    private readonly Label _idLabel;
    private readonly ToolStripItem _modifyMenu;

    private SkinInfo? _currentSkin;

    private bool _hasUnsavedChanges = false;

    private bool IsSaved => !_hasUnsavedChanges && _currentSkin != null;

    public SaveManager(Label idLabel, ToolStripItem modifyMenu)
    {
        _idLabel = idLabel;
        _modifyMenu = modifyMenu;
    }

    private void UpdateIdLabel()
    {
        string text = (_currentSkin?.Id ?? "Unsaved skin") + (IsSaved ? string.Empty : " *");
        Font font = new(_idLabel.Font, IsSaved ? FontStyle.Regular : FontStyle.Italic);

        _idLabel.Font = font;
        _idLabel.Text = text;
        _idLabel.Width = _idLabel.PreferredWidth;
        _modifyMenu.Enabled = _currentSkin != null;
    }

    private void SetSaveStatus(bool saved)
    {
        _hasUnsavedChanges = !saved;
        UpdateIdLabel();

        Logger.Info($"Has unsaved changes: {_hasUnsavedChanges}");
    }

    public bool CheckForUnsavedProgress()
    {
        if (!_hasUnsavedChanges)
            return true;

        return MessageBox.Show("You will lose unsaved progress, are you sure you want to continue?",
            "Unsaved changes",
            MessageBoxButtons.YesNo) == DialogResult.Yes;
    }

    public void New()
    {
        if (!CheckForUnsavedProgress())
            return;

        Logger.Warn("Creating new skin");

        _currentSkin = null;
        SetSaveStatus(true);

        OnNewSkin?.Invoke();
    }

    public void Open()
    {
        if (!CheckForUnsavedProgress())
            return;

        using FilePrompt prompt = new();
        if (prompt.ShowDialog() != DialogResult.OK)
            return;

        string path = Path.Combine(Core.SkinsFolder, prompt.SelectedFile);
        Logger.Warn($"Opening existing skin from {path}");
        SkinInfo? info = LoadSkinInfo(path);

        if (info == null)
        {
            Logger.Error($"Failed to open skin at {path}");
            return;
        }

        _currentSkin = info;
        SetSaveStatus(true);

        OnOpenSkin?.Invoke(path);
    }

    public void Modify()
    {
        if (_currentSkin is null)
            return;

        using InfoPrompt prompt = new(_currentSkin, true);
        if (prompt.ShowDialog() != DialogResult.OK)
            return;

        SkinInfo info = prompt.SelectedInfo;
        Logger.Warn("Modifying current skin");

        OnModifySkin?.Invoke(_currentSkin, info);

        _currentSkin = info;
        SetSaveStatus(false);
    }

    public void Save()
    {
        if (IsSaved)
            return;

        if (_currentSkin is null)
        {
            SaveAs();
            return;
        }

        Logger.Warn("Saving current skin");
        SaveSkinInfo(_currentSkin);

        SetSaveStatus(true);
    }

    public void SaveAs()
    {
        using InfoPrompt prompt = new(_currentSkin, false);
        if (prompt.ShowDialog() != DialogResult.OK)
            return;

        SkinInfo info = prompt.SelectedInfo;
        Logger.Warn($"Saving skin as {info.Id}");
        SaveSkinInfo(info);

        _currentSkin = info;
        SetSaveStatus(true);
    }

    private void SaveSkinInfo(SkinInfo info)
    {
        // Get and create skin directory
        string path = Path.Combine(Core.SkinsFolder, info.Id);
        Directory.CreateDirectory(path);

        // Save info file
        File.WriteAllText(Path.Combine(path, "info.txt"), JsonConvert.SerializeObject(info, new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented
        }));

        // Save everything else
        OnSaveSkin?.Invoke(path);
    }

    private SkinInfo? LoadSkinInfo(string path)
    {
        string json = File.ReadAllText(Path.Combine(path, "info.txt"));
        return JsonConvert.DeserializeObject<SkinInfo>(json);
    }

    // Event handling

    public void Initialize()
    {
        Core.RecolorManager.OnPixelChanged += OnPixelChanged;
        Core.UndoManager.OnUndo += OnUndo;
        Core.UndoManager.OnRedo += OnRedo;
    }

    private void OnPixelChanged(byte pixel, Color oldColor, Color newColor)
    {
        SetSaveStatus(false);
    }

    private void OnUndo(BaseUndoCommand command)
    {
        if (command is ModifySkinUndoCommand ms)
        {
            _currentSkin = ms.OldInfo;
        }

        SetSaveStatus(false);
    }

    private void OnRedo(BaseUndoCommand command)
    {
        if (command is ModifySkinUndoCommand ms)
        {
            _currentSkin = ms.NewInfo;
        }

        SetSaveStatus(false);
    }

    public delegate void NewSkinDelegate();
    public event NewSkinDelegate? OnNewSkin;
    public delegate void OpenSkinDelegate(string path);
    public event OpenSkinDelegate? OnOpenSkin;
    public delegate void ModifySkinDelegate(SkinInfo oldInfo, SkinInfo newInfo);
    public event ModifySkinDelegate? OnModifySkin;
    public delegate void SaveSkinDelegate(string path);
    public event SaveSkinDelegate? OnSaveSkin;
}
