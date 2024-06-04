using Basalt.Framework.Logging;
using Blasphemous.Modding.SkinEditor.Properties;

namespace Blasphemous.Modding.SkinEditor.Setting;

public class SettingManager : IManager
{
    public void LoadAllProperties(IEnumerable<ToolStripMenuItem> menus)
    {
        foreach (ToolStripMenuItem menu in menus)
        {
            string property = menu.Name[6..];
            bool status = (bool)Settings.Default[property];

            menu.Checked = status;

            Logger.Info($"Loading property {property} ({status})");
            OnSettingChanged?.Invoke(property, status, true);
        }
    }

    public void SetProperty(ToolStripMenuItem menu)
    {
        string property = menu.Name[6..];
        bool status = menu.Checked;

        Settings.Default[property] = status;
        Settings.Default.Save();

        Logger.Info($"Setting property {property} to {status}");
        OnSettingChanged?.Invoke(property, status, false);
    }

    // Event handling

    public void Initialize() { }

    public delegate void SettingChangeDelegate(string property, bool status, bool onLoad);
    public event SettingChangeDelegate? OnSettingChanged;
}
