
namespace Blasphemous.Modding.SkinEditor.Save;

public class SaveManager : IManager
{
    public void New()
    {
        Logger.Warn("Creating new skin");
    }

    public void Open()
    {
        Logger.Warn("Opening existing skin");
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
}
