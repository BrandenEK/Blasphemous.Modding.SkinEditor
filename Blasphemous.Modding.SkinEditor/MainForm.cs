using Blasphemous.Modding.SkinEditor.Previewing;
using Blasphemous.Modding.SkinEditor.Settings;

namespace Blasphemous.Modding.SkinEditor;

public partial class MainForm : Form
{
    private readonly ISettingsHandler _settingsHandler;
    private readonly ISpritePreviewer _spritePreviewer;

    public MainForm()
    {
        InitializeComponent();

        _settingsHandler = new SettingsHandler();
        _spritePreviewer = new SpritePreviewer(_right_image);
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
        Test();
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

    private void Test()
    {
        Bitmap parry = Preview("penitent_parry_failed.png", new Point(0, 185), new Size(68, 71));
        Bitmap lunge = Preview("penitent_dodge_attack_LVL2.png", new Point(580, 180), new Size(170, 70));

        _spritePreviewer.Update(lunge);

        Bitmap Preview(string anim, Point offset, Size size)
        {
            using Bitmap full = new(Path.Combine(Environment.CurrentDirectory, "anim", anim));
            Bitmap cropped = new(size.Width, size.Height);

            for (int x = 0; x < size.Width; x++)
            {
                for (int y = 0; y < size.Height; y++)
                {
                    cropped.SetPixel(x, y, full.GetPixel(offset.X + x, offset.Y + y));
                }
            }

            int xScale = _right_image.Size.Width / size.Width;
            int yScale = _right_image.Size.Height / size.Height;

            return cropped;// Scale(cropped, Math.Min(xScale, yScale));
        }
    }
}
