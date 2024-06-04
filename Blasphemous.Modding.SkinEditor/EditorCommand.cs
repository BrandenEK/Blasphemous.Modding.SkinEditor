using Basalt.CommandParser;

namespace Blasphemous.Modding.SkinEditor;

public class EditorCommand : CommandData
{
    [BooleanArgument('d', "debug")]
    public bool DebugMode { get; set; } = false;

    [StringArgument('r', "resources")]
    public string ResourceFolder { get; set; } = string.Empty;
}
