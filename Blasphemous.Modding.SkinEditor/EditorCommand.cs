﻿using Basalt.CommandParser;

namespace Blasphemous.Modding.SkinEditor;

public class EditorCommand : CommandData
{
    [BooleanArgument('v', "verbose")]
    public bool VerboseLogging { get; set; } = false;

    [StringArgument('d', "datafolder")]
    public string DataFolder { get; set; } = string.Empty;
}
