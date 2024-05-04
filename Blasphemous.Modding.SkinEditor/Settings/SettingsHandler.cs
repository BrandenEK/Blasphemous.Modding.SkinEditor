
namespace Blasphemous.Modding.SkinEditor.Settings;

public class SettingsHandler : ISettingsHandler
{
    public EditorSettings Current { get; private set; } = new();

    public void Save()
    {
        Properties.Settings.Default.Location = Current.Location;
        Properties.Settings.Default.Size = Current.Size;
        Properties.Settings.Default.Maximized = Current.Maximized;

        Properties.Settings.Default.Save();
    }

    public void Load()
    {
        Current = new EditorSettings()
        {
            Location = Properties.Settings.Default.Location,
            Size = Properties.Settings.Default.Size,
            Maximized = Properties.Settings.Default.Maximized,
        };
    }
}
