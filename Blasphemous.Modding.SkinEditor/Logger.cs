﻿using System.Runtime.InteropServices;

namespace Blasphemous.Modding.SkinEditor;

public static class Logger
{
    public static void Initialize()
    {
        AttachConsole(-1);
        Info(string.Empty);
    }

    public static void Info(object message) => Log(message, ConsoleColor.White);

    public static void Warn(object message) => Log(message, ConsoleColor.Yellow);

    public static void Error(object message) => Log(message, ConsoleColor.Red);

    private static void Log(object message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
    }

    [DllImport("kernel32", SetLastError = true)]
    static extern bool AttachConsole(int dwProcessId);
}
