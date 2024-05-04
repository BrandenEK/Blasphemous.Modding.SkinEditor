using Blasphemous.Modding.SkinEditor.Settings;

namespace Blasphemous.Modding.SkinEditor;

public partial class MainForm : Form
{
    private readonly ISettingsHandler _settingsHandler;

    public MainForm()
    {
        _settingsHandler = new SettingsHandler();

        InitializeComponent();
    }

    private void OnFormOpen(object sender, EventArgs e)
    {
        Logger.Info($"Opening editor v{Core.CurrentVersion.ToString(3)}");

        // Load editor settings
        _settingsHandler.Load();
        WindowState = _settingsHandler.Current.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
        Location = _settingsHandler.Current.Location;
        Size = _settingsHandler.Current.Size;

        // Initialize form ui
        Text = "Blasphemous Skin Editor v" + Core.CurrentVersion.ToString(3);
        OnFormResized(this, new EventArgs());
    }

    private void OnFormClose(object sender, FormClosingEventArgs e)
    {
        Logger.Info("Closing editor");

        // Save editor settings
        _settingsHandler.Current.Location = WindowState == FormWindowState.Normal ? Location : RestoreBounds.Location;
        _settingsHandler.Current.Size = WindowState == FormWindowState.Normal ? Size : RestoreBounds.Size;
        _settingsHandler.Current.Maximized = WindowState == FormWindowState.Maximized;
        _settingsHandler.Save();
    }

    private void OnFormResized(object sender, EventArgs e)
    {
        // Resize main ui holder
        UI.Location = ClientRectangle.Location;
        UI.Size = ClientRectangle.Size;
    }
}
