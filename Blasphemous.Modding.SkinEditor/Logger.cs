using System.Runtime.InteropServices;

namespace Blasphemous.Modding.SkinEditor;

public static class Logger
{
    private static readonly string _logPath = Path.Combine(Core.DataFolder, "Latest.log");

    public static void Initialize()
    {
        InitConsole();
        InitFile();
    }

    public static void Info(object message)
    {
        LogToConsole(message, ConsoleColor.White);
        LogtoFile(message, "Info");
    }

    public static void Warn(object message)
    {
        LogToConsole(message, ConsoleColor.Yellow);
        LogtoFile(message, "Warning");
    }

    public static void Error(object message)
    {
        LogToConsole(message, ConsoleColor.Red);
        LogtoFile(message, "Error");
    }

    // Console

    private static void InitConsole()
    {
        AttachConsole(-1);
    }

    private static void LogToConsole(object message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
    }

    // File

    private static void InitFile()
    {
        if (File.Exists(_logPath))
            File.SetAttributes(_logPath, File.GetAttributes(_logPath) & ~FileAttributes.ReadOnly);

        File.WriteAllText(_logPath, string.Empty);
        File.SetAttributes(_logPath, FileAttributes.ReadOnly);
    }

    private static void LogtoFile(object message, string type)
    {
        string output = $"[{DateTime.Now:HH:mm:ss} {type}] {message}{Environment.NewLine}";

        if (File.Exists(_logPath))
            File.SetAttributes(_logPath, File.GetAttributes(_logPath) & ~FileAttributes.ReadOnly);

        File.AppendAllText(_logPath, output);
        File.SetAttributes(_logPath, FileAttributes.ReadOnly);
    }

    [DllImport("kernel32", SetLastError = true)]
    static extern bool AttachConsole(int dwProcessId);
}
