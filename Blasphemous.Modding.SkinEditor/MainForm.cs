using Blasphemous.Modding.SkinEditor.Properties;
using System.Diagnostics;

namespace Blasphemous.Modding.SkinEditor;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

#if !DEBUG
        _preview_debug.Visible = false;
#endif
    }

    public T FindUI<T>(string name) where T : Control
    {
        return (T)Controls.Find(name, true)[0];
    }

    public ToolStripItem FindMenu(string name)
    {
        foreach (ToolStripMenuItem item in _menu.Items)
        {
            foreach (ToolStripItem menu in item.DropDownItems)
            {
                if (menu.Name == name)
                    return menu;
            }
        }

        throw new Exception($"Menu item {name} does not exist");
    }

    private void OnFormOpen(object sender, EventArgs e)
    {
        Logger.Info($"Opening editor v{Core.CurrentVersion.ToString(3)}");

        // Load window settings
        WindowState = Settings.Default.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
        Location = Settings.Default.Location;
        Size = Settings.Default.Size;

        // Register events
        Core.SettingManager.OnSettingChanged += OnSettingChanged;

        // Initialize form ui
        Text = "Blasphemous Skin Editor v" + Core.CurrentVersion.ToString(3);
        Core.SettingManager.LoadAllProperties(new ToolStripMenuItem[]
        {
            _menu_view_all, _menu_view_background, _menu_view_side
        });

        // Start process
        Core.SaveManager.New();
    }

    private void OnFormClose(object sender, FormClosingEventArgs e)
    {
        if (!Core.SaveManager.CheckForUnsavedProgress())
        {
            e.Cancel = true;
            return;
        }

        Logger.Info("Closing editor");

        // Save window settings
        Settings.Default.Location = WindowState == FormWindowState.Normal ? Location : RestoreBounds.Location;
        Settings.Default.Size = WindowState == FormWindowState.Normal ? Size : RestoreBounds.Size;
        Settings.Default.Maximized = WindowState == FormWindowState.Maximized;
        Settings.Default.Save();
    }

    private void OnSettingChanged(string property, bool status, bool onLoad)
    {
        if (property != "view_side")
            return;

        _buttons.Dock = status ? DockStyle.Right : DockStyle.Left;
    }

    private void OpenLink(string link)
    {
        try
        {
            Process.Start(new ProcessStartInfo(link!)
            {
                UseShellExecute = true
            });
        }
        catch
        {
            MessageBox.Show("Link does not exist!", "Invalid Link");
        }
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

    private void OnClickMenu_File_New(object _, EventArgs __) => Core.SaveManager.New();
    private void OnClickMenu_File_Open(object _, EventArgs __) => Core.SaveManager.Open();
    private void OnClickMenu_File_Modify(object _, EventArgs __) => Core.SaveManager.Modify();
    private void OnClickMenu_File_Save(object _, EventArgs __) => Core.SaveManager.Save();
    private void OnClickMenu_File_SaveAs(object _, EventArgs __) => Core.SaveManager.SaveAs();

    private void OnClickMenu_Edit_Undo(object _, EventArgs __) => Core.UndoManager.Undo();
    private void OnClickMenu_Edit_Redo(object _, EventArgs __) => Core.UndoManager.Redo();

    private void OnClickMenu_View_All(object sender, EventArgs __) => Core.SettingManager.SetProperty((ToolStripMenuItem)sender);
    private void OnClickMenu_View_Background(object sender, EventArgs __) => Core.SettingManager.SetProperty((ToolStripMenuItem)sender);
    private void OnClickMenu_View_Side(object sender, EventArgs __) => Core.SettingManager.SetProperty((ToolStripMenuItem)sender);

    private void OnClickMenu_Help_Readme(object _, EventArgs __) => OpenLink(README_LINK);
    private void OnClickMenu_Help_Repo(object _, EventArgs __) => OpenLink(REPO_LINK);

    private void OnClickDebug(object sender, EventArgs e)
    {
        Logger.Warn("Clicking debug button");
    }

    private const string README_LINK = "https://github.com/BrandenEK/Blasphemous.Modding.SkinEditor/blob/main/README.md";
    private const string REPO_LINK = "https://github.com/BrandenEK/Blasphemous-Custom-Skins";
}
