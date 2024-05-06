
using Blasphemous.Modding.SkinEditor.Properties;

namespace Blasphemous.Modding.SkinEditor.Setting;

public class SettingManager : IManager
{
    public void SetProperty(ToolStripMenuItem menu)
    {
        string property = menu.Name[6..];
        bool status = menu.Checked;

        Settings.Default[property] = status;
        Settings.Default.Save();

        Logger.Info($"Setting property {property} to {status}");
        OnSettingChanged?.Invoke(property, status);
    }

    // Event handling

    public void Initialize() { }

    public delegate void SettingChangeDelegate(string property, bool status);
    public event SettingChangeDelegate? OnSettingChanged;
}
