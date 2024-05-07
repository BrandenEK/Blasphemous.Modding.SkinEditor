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

    private int _unsavedChanges = 0;
    private DateTime _lastSaveTime = DateTime.Now;

    private bool IsSaved => _unsavedChanges == 0 && _currentSkin != null;

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

    private void ChangeUnsavedAmount(int amount)
    {
        _unsavedChanges += amount;
        UpdateIdLabel();

        Logger.Info($"There are now {_unsavedChanges} unsaved changes");
    }

    private void ResetUnsavedAmount()
    {
        _unsavedChanges = 0;
        UpdateIdLabel();

        Logger.Info($"There are now 0 unsaved changes");
    }

    public bool CheckForUnsavedProgress()
    {
        if (_unsavedChanges == 0)
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
        ResetUnsavedAmount();

        OnNewSkin?.Invoke();
    }

    public void Open()
    {
        if (!CheckForUnsavedProgress())
            return;

        using FilePrompt prompt = new();
        if (prompt.ShowDialog() != DialogResult.OK)
            return;

        string path = Path.Combine(Environment.CurrentDirectory, "skins", prompt.SelectedFile);
        Logger.Warn($"Opening existing skin from {path}");
        SkinInfo? info = LoadSkinInfo(path);

        if (info == null)
        {
            Logger.Error($"Failed to open skin at {path}");
            return;
        }

        _currentSkin = info;
        ResetUnsavedAmount();

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
        ChangeUnsavedAmount(1);
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

        ResetUnsavedAmount();
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
        ResetUnsavedAmount();
    }

    private void SaveSkinInfo(SkinInfo info)
    {
        // Get and create skin directory
        string path = Path.Combine(Environment.CurrentDirectory, "skins", info.Id);
        Directory.CreateDirectory(path);

        // Save info file
        File.WriteAllText(Path.Combine(path, "info.txt"), JsonConvert.SerializeObject(info, new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented
        }));

        // Save everything else
        OnSaveSkin?.Invoke(path);
        _lastSaveTime = DateTime.Now;
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
        ChangeUnsavedAmount(1);
    }

    private void OnUndo(BaseUndoCommand command)
    {
        if (command is ModifySkinUndoCommand ms)
        {
            _currentSkin = ms.OldInfo;
        }

        ChangeUnsavedAmount(command.TimeStamp > _lastSaveTime ? -1 : 1);
    }

    private void OnRedo(BaseUndoCommand command)
    {
        if (command is ModifySkinUndoCommand ms)
        {
            _currentSkin = ms.NewInfo;
        }

        ChangeUnsavedAmount(command.TimeStamp > _lastSaveTime ? 1 : -1);
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
