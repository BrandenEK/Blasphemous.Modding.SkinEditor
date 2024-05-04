namespace Blasphemous.Modding.SkinEditor;

internal static class Core
{
    [STAThread]
    static void Main()
    {
        Logger.Show();

        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }

    public static Version CurrentVersion =>
        System.Reflection.Assembly.GetExecutingAssembly().GetName().Version ?? new(0, 1, 0);
}