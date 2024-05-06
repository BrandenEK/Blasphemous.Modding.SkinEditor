using Blasphemous.Modding.SkinEditor.Previewing;
using Blasphemous.Modding.SkinEditor.Recoloring;
using Blasphemous.Modding.SkinEditor.Settings;

namespace Blasphemous.Modding.SkinEditor;

public partial class MainForm : Form
{
    private readonly RecolorHandler _recolorHandler;
    private readonly ISettingsHandler _settingsHandler;
    private readonly SpritePreviewer _spritePreviewer;
    private readonly TextureHandler _textureHandler;

    public MainForm()
    {
        InitializeComponent();

        _textureHandler = new TextureHandler();
        _spritePreviewer = new SpritePreviewer(_textureHandler, _preview_image);
        _recolorHandler = new RecolorHandler(_textureHandler, _spritePreviewer, _buttons, _menu_view_all);
        _settingsHandler = new SettingsHandler();

        _textureHandler.Initialize();
        _spritePreviewer.Initialize();
        _recolorHandler.Initialize();
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

        // Testing stuff
        LoadAllAnimations();
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

        _spritePreviewer.ChangePreview(new Bitmap(file));
        _recolorHandler.RefreshButtonsVisibility();
    }

    private void OnClickMenu_Edit_Undo(object _, EventArgs __) => Core.UndoManager.Undo();
    private void OnClickMenu_Edit_Redo(object _, EventArgs __) => Core.UndoManager.Redo();

    private void OnClickMenu_View_Buttons(object _, EventArgs __)
    {
        Logger.Info("Toggling visibility of all buttons");
        _recolorHandler.ToggleShowingAll();
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
