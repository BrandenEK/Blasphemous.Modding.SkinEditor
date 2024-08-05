using Basalt.BetterForms;
using Basalt.Framework.Logging;
using Blasphemous.Modding.SkinEditor.Properties;
using System.Diagnostics;

namespace Blasphemous.Modding.SkinEditor;

public partial class MainForm : BasaltForm
{
    protected override void OnFormOpenPre()
    {
        WindowState = Settings.Default.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
        Location = Settings.Default.Location;
        Size = Settings.Default.Size;

#if !DEBUG
        _preview_debug.Visible = false;
#endif
    }

    protected override void OnFormOpenPost()
    {
        // Handle loading settings
        Core.SettingManager.OnSettingChanged += OnSettingChanged;
        Core.SettingManager.LoadAllProperties(new ToolStripMenuItem[]
        {
            _menu_view_all, _menu_view_background, _menu_view_side, _menu_view_mirror
        });

        // Start process
        Core.SaveManager.New();
    }

    protected override void OnFormClose(FormClosingEventArgs e)
    {
        if (!Core.SaveManager.CheckForUnsavedProgress())
        {
            e.Cancel = true;
            return;
        }

        // Save window settings
        Settings.Default.Location = WindowState == FormWindowState.Normal ? Location : RestoreBounds.Location;
        Settings.Default.Size = WindowState == FormWindowState.Normal ? Size : RestoreBounds.Size;
        Settings.Default.Maximized = WindowState == FormWindowState.Maximized;
        Settings.Default.Save();
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

    private void OnSettingChanged(string property, bool status, bool onLoad)
    {
        if (property != "view_side")
            return;

        _buttons.Dock = status ? DockStyle.Right : DockStyle.Left;
    }

    private void OpenProcess(string process, string verb = "")
    {
        try
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = process,
                UseShellExecute = true,
                Verb = verb
            });
        }
        catch
        {
            MessageBox.Show($"Failed to start: {process}", "Invalid process");
        }
    }

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
    private void OnClickMenu_View_Mirror(object sender, EventArgs __) => Core.SettingManager.SetProperty((ToolStripMenuItem)sender);

    private void OnClickMenu_Help_Readme(object _, EventArgs __) => OpenProcess(README_LINK);
    private void OnClickMenu_Help_Repo(object _, EventArgs __) => OpenProcess(REPO_LINK);
    private void OnClickMenu_Help_Folder(object _, EventArgs __) => OpenProcess(Core.SkinsFolder, "open");

    private void OnClickDebug(object sender, EventArgs e)
    {
        Logger.Warn("Clicking debug button");
    }

    private const string README_LINK = "https://github.com/BrandenEK/Blasphemous.Modding.SkinEditor/blob/main/README.md";
    private const string REPO_LINK = "https://github.com/BrandenEK/Blasphemous-Custom-Skins";
}
