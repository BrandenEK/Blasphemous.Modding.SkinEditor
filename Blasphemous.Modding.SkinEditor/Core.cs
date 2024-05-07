using Blasphemous.Modding.SkinEditor.Preview;
using Blasphemous.Modding.SkinEditor.Recolor;
using Blasphemous.Modding.SkinEditor.Save;
using Blasphemous.Modding.SkinEditor.Setting;
using Blasphemous.Modding.SkinEditor.Texture;
using Blasphemous.Modding.SkinEditor.Undo;

namespace Blasphemous.Modding.SkinEditor;

internal static class Core
{
    [STAThread]
    static void Main()
    {
        Logger.Show();
        ApplicationConfiguration.Initialize();
        var form = new MainForm();

        PreviewManager = new PreviewManager(form.FindUI<PictureBox>("_preview_image"));
        RecolorManager = new RecolorManager(form.FindUI<Panel>("_buttons"));
        SaveManager = new SaveManager();
        SettingManager = new SettingManager();
        TextureManager = new TextureManager();
        UndoManager = new UndoManager();

        PreviewManager.Initialize();
        RecolorManager.Initialize();
        SaveManager.Initialize();
        SettingManager.Initialize();
        TextureManager.Initialize();
        UndoManager.Initialize();

        Application.Run(form);
    }

#pragma warning disable CS8618
    public static PreviewManager PreviewManager { get; private set; }
    public static RecolorManager RecolorManager { get; private set; }
    public static SaveManager SaveManager { get; private set; }
    public static SettingManager SettingManager { get; private set; }
    public static TextureManager TextureManager { get; private set; }
    public static UndoManager UndoManager { get; private set; }
#pragma warning restore CS8618

    public static Version CurrentVersion =>
        System.Reflection.Assembly.GetExecutingAssembly().GetName().Version ?? new(0, 1, 0);
}