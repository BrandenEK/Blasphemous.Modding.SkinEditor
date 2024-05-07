using Blasphemous.Modding.SkinEditor.Models;

namespace Blasphemous.Modding.SkinEditor.Save;

public class SaveManager : IManager
{
    private SkinInfo? _currentSkin;

    public void New()
    {
        Logger.Warn("Creating new skin");

        OnNewSkin?.Invoke();
    }

    public void Open()
    {
        Logger.Warn("Opening existing skin");

        // Prompt for file path
        string path = Path.Combine(Environment.CurrentDirectory, "data", "test.png");

        OnOpenSkin?.Invoke(path);
    }

    public void Save()
    {
        Logger.Warn("Saving current skin");
    }

    public void SaveAs()
    {
        Logger.Warn("Saving to different skin");
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
