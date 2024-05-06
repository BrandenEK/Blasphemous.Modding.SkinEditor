using Blasphemous.Modding.SkinEditor.Texture;
using Blasphemous.Modding.SkinEditor.Undo;

namespace Blasphemous.Modding.SkinEditor;

internal static class Core
{
    [STAThread]
    static void Main()
    {
        Logger.Show();

        TextureManager.Initialize();
        UndoManager.Initialize();

        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }

    public static TextureManager TextureManager { get; private set; } = new();
    public static UndoManager UndoManager { get; private set; } = new();

    public static Version CurrentVersion =>
        System.Reflection.Assembly.GetExecutingAssembly().GetName().Version ?? new(0, 1, 0);
}