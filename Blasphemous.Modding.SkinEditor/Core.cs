using Basalt.BetterForms;
using Basalt.Framework.Logging;
using Blasphemous.Modding.SkinEditor.Loading;
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
        BasaltApplication.Run<MainForm, EditorCommand>(InitializeManagers, "Blasphemous Skin Editor", new string[]
        {
            EditorFolder, SkinsFolder
        });
    }

    static void InitializeManagers(MainForm form, EditorCommand cmd)
    {
        IResourceLoader resourceLoader = string.IsNullOrEmpty(cmd.ResourceFolder)
                ? new EmbeddedLoader()
                : new FileLoader(cmd.ResourceFolder);
        Logger.Debug($"Using {resourceLoader.GetType().Name} as the resource loader");

        PreviewManager = new PreviewManager(resourceLoader, form.FindUI<PictureBox>("_preview_image"), form.FindUI<ComboBox>("_info_selector"));
        RecolorManager = new RecolorManager(resourceLoader, form.FindUI<Panel>("_buttons"));
        SaveManager = new SaveManager(form.FindUI<Label>("_info_header"), form.FindMenu("_menu_file_modify"));
        SettingManager = new SettingManager();
        TextureManager = new TextureManager(resourceLoader);
        UndoManager = new UndoManager();

        // Initialize them in a certain order
        SaveManager.Initialize();
        SettingManager.Initialize();
        TextureManager.Initialize();
        PreviewManager.Initialize();
        RecolorManager.Initialize();
        UndoManager.Initialize();
    }

#pragma warning disable CS8618
    public static PreviewManager PreviewManager { get; private set; }
    public static RecolorManager RecolorManager { get; private set; }
    public static SaveManager SaveManager { get; private set; }
    public static SettingManager SettingManager { get; private set; }
    public static TextureManager TextureManager { get; private set; }
    public static UndoManager UndoManager { get; private set; }
#pragma warning restore CS8618

    public static string EditorFolder { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BlasSkinEditor");
    public static string SkinsFolder { get; } = Path.Combine(EditorFolder, "skins");
}