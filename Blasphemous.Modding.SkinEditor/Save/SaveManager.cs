using Blasphemous.Modding.SkinEditor.Models;
using Blasphemous.Modding.SkinEditor.Prompts;
using Blasphemous.Modding.SkinEditor.Undo;

namespace Blasphemous.Modding.SkinEditor.Save;

public class SaveManager : IManager
{
    private readonly Label _idLabel;

    private SkinInfo? _currentSkin;
    private int _unsavedChanges;

    private bool IsSaved => _unsavedChanges == 0 && _currentSkin != null;

    public SaveManager(Label idLabel)
    {
        _idLabel = idLabel;
    }

    private void UpdateIdLabel()
    {
        string text = (_currentSkin?.Id ?? "Unsaved skin") + (IsSaved ? string.Empty : " *");
        Font font = new(_idLabel.Font, IsSaved ? FontStyle.Regular : FontStyle.Italic);

        _idLabel.Font = font;
        _idLabel.Text = text;
    }

    private void ChangeUnsavedAmount(int amount)
    {
        _unsavedChanges = Math.Max(_unsavedChanges + amount, 0);
        UpdateIdLabel();
    }

    private void ResetUnsavedAmount()
    {
        _unsavedChanges = 0;
        UpdateIdLabel();
    }

    public void New()
    {
        // Check for unsaved progress

        Logger.Warn("Creating new skin");

        _currentSkin = null;
        ResetUnsavedAmount();
        
        OnNewSkin?.Invoke();
    }

    public void Open()
    {
        // Check for unsaved progress

        Logger.Warn("Opening existing skin");

        // Prompt for file path
        string path = Path.Combine(Environment.CurrentDirectory, "data", "test.png");

        _currentSkin = new SkinInfo("PENITENT_BACKER", "Backer skin", "TGK", "1.0.0");
        ResetUnsavedAmount();

        UpdateIdLabel();
        
        OnOpenSkin?.Invoke(path);
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
        // Save to file

        ResetUnsavedAmount();

        UpdateIdLabel();
    }

    public void SaveAs()
    {
        using InfoPrompt prompt = new(_currentSkin, false);
        if (prompt.ShowDialog() != DialogResult.OK)
            return;

        SkinInfo info = prompt.SelectedInfo;
        Logger.Warn($"Saving skin as {info.Id}");
        // Save to file
        
        _currentSkin = info;
        ResetUnsavedAmount();

        UpdateIdLabel();
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
        if (oldColor != newColor)
            ChangeUnsavedAmount(1);
    }

    private void OnUndo(IUndoCommand command)
    {
        ChangeUnsavedAmount(-1);
    }

    private void OnRedo(IUndoCommand command)
    {
        ChangeUnsavedAmount(1);
    }

    public delegate void NewSkinDelegate();
    public event NewSkinDelegate? OnNewSkin;
    public delegate void OpenSkinDelegate(string path);
    public event OpenSkinDelegate? OnOpenSkin;
}
