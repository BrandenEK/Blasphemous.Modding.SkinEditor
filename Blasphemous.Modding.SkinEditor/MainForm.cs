namespace Blasphemous.Modding.SkinEditor;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void OnFormOpen(object sender, EventArgs e)
    {
        Logger.Info($"Opening editor v{Core.CurrentVersion.ToString(3)}");

        Text = "Blasphemous Skin Editor v" + Core.CurrentVersion.ToString(3);
    }

    private void OnFormClose(object sender, FormClosingEventArgs e)
    {
        Logger.Info("Closing editor");
    }
}
