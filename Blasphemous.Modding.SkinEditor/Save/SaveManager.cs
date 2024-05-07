using Blasphemous.Modding.SkinEditor.Models;

namespace Blasphemous.Modding.SkinEditor.Save;

public class SaveManager : IManager
{
    private readonly Label _idLabel;

    private SkinInfo? _currentSkin;
    private bool _isSaved;

    public SaveManager(Label idLabel)
    {
        _idLabel = idLabel;
    }

    private void UpdateIdLabel()
    {
        string text = (_currentSkin?.Id ?? "Unsaved skin") + (_isSaved ? string.Empty : " *");
        Font font = new(_idLabel.Font, _isSaved ? FontStyle.Regular : FontStyle.Italic);

        _idLabel.Font = font;
        _idLabel.Text = text;
    }

    public void New()
    {
        Logger.Warn("Creating new skin");

        _isSaved = false;
        UpdateIdLabel();
        
        OnNewSkin?.Invoke();
    }

    public void Open()
    {
        Logger.Warn("Opening existing skin");

        // Prompt for file path
        string path = Path.Combine(Environment.CurrentDirectory, "data", "test.png");
        _currentSkin = new SkinInfo("PENITENT_BACKER", "Backer skin", "TGK", "1.0.0");

        _isSaved = true;
        UpdateIdLabel();
        
        OnOpenSkin?.Invoke(path);
    }

    public void Save()
    {
        if (_currentSkin is null)
        {
            SaveAs();
            return;
        }

        Logger.Warn("Saving current skin");

        _isSaved = true;
        UpdateIdLabel();
    }

    public void SaveAs()
    {
        Logger.Warn("Saving new skin");

        _isSaved = true;
        UpdateIdLabel();
    }

    // Event handling

    public void Initialize()
    {
        
    }

    public delegate void NewSkinDelegate();
    public event NewSkinDelegate? OnNewSkin;
    public delegate void OpenSkinDelegate(string path);
    public event OpenSkinDelegate? OnOpenSkin;
}
