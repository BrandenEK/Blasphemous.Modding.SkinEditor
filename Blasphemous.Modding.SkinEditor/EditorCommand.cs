using Basalt.BetterForms;
using Basalt.CommandParser;

namespace Blasphemous.Modding.SkinEditor;

public class EditorCommand : BasaltCommand
{
    [StringArgument('r', "resources")]
    public string ResourceFolder { get; set; } = string.Empty;
}
