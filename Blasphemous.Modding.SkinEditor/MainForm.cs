using Blasphemous.Modding.SkinEditor.Properties;

namespace Blasphemous.Modding.SkinEditor;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    public T FindUI<T>(string name) where T : Control
    {
        return (T)Controls.Find(name, true)[0];
    }

    private void OnFormOpen(object sender, EventArgs e)
    {
        Logger.Info($"Opening editor v{Core.CurrentVersion.ToString(3)}");

        // Load window settings
        WindowState = Settings.Default.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
        Location = Settings.Default.Location;
        Size = Settings.Default.Size;

        // Initialize form ui
        Text = "Blasphemous Skin Editor v" + Core.CurrentVersion.ToString(3);
        Core.TextureManager.LoadTexture(Path.Combine(Environment.CurrentDirectory, "data", "default.png"));

        // Testing stuff
        LoadAllAnimations();
    }

    private void OnFormClose(object sender, FormClosingEventArgs e)
    {
        Logger.Info("Closing editor");

        // Save window settings
        Settings.Default.Location = WindowState == FormWindowState.Normal ? Location : RestoreBounds.Location;
        Settings.Default.Size = WindowState == FormWindowState.Normal ? Size : RestoreBounds.Size;
        Settings.Default.Maximized = WindowState == FormWindowState.Maximized;
        Settings.Default.Save();
    }

    private void LoadAllAnimations()
    {
        foreach (string file in Directory.EnumerateFiles(Path.Combine(Environment.CurrentDirectory, "anim")))
        {
            Logger.Error($"Loaded anim: {file}");
            _preview_selector.Items.Add(file[(file.LastIndexOf('\\') + 1)..^4]);
        }

        _preview_selector.SelectedItem = "idle";
    }

    //private void Test()
    //{
    //    Bitmap parry = Preview("penitent_parry_failed.png", new Point(0, 185), new Size(68, 71));
    //    Bitmap lunge = Preview("penitent_dodge_attack_LVL2.png", new Point(580, 180), new Size(170, 70));

    //    _spritePreviewer.Update(lunge);

    //    Bitmap Preview(string anim, Point offset, Size size)
    //    {
    //        using Bitmap full = new(Path.Combine(Environment.CurrentDirectory, "anim", anim));
    //        Bitmap cropped = new(size.Width, size.Height);

    //        for (int x = 0; x < size.Width; x++)
    //        {
    //            for (int y = 0; y < size.Height; y++)
    //            {
    //                cropped.SetPixel(x, y, full.GetPixel(offset.X + x, offset.Y + y));
    //            }
    //        }

    //        int xScale = _right_image.Size.Width / size.Width;
    //        int yScale = _right_image.Size.Height / size.Height;

    //        return cropped;// Scale(cropped, Math.Min(xScale, yScale));
    //    }
    //}

    private void OnSelectAnim(object sender, EventArgs e)
    {
        string anim = _preview_selector.SelectedItem.ToString() ?? string.Empty;
        string file = Path.Combine(Environment.CurrentDirectory, "anim", $"{anim}.png");

        Core.PreviewManager.ChangePreview(new Bitmap(file));
        Core.RecolorManager.RefreshButtonsVisibility();
    }

    private void OnClickMenu_Edit_Undo(object _, EventArgs __) => Core.UndoManager.Undo();
    private void OnClickMenu_Edit_Redo(object _, EventArgs __) => Core.UndoManager.Redo();

    private void OnClickMenu_View_Buttons(object _, EventArgs __)
    {
        Logger.Info("Toggling visibility of all buttons");
        Core.RecolorManager.ToggleShowingAll();
    }

    private void OnClickMenu_View_Background(object _, EventArgs __)
    {
        Logger.Info("Toggling background style");
    }

    private void OnClickMenu_View_Side(object _, EventArgs __)
    {
        Logger.Info("Toggling preview side");
        DockStyle style = _buttons.Dock;
        _buttons.Dock = style == DockStyle.Left ? DockStyle.Right : DockStyle.Left;
    }
}
