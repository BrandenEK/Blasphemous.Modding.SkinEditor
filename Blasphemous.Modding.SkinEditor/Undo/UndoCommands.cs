
using Blasphemous.Modding.SkinEditor.Models;

namespace Blasphemous.Modding.SkinEditor.Undo;

public abstract record BaseUndoCommand
{
    public DateTime TimeStamp { get; } = DateTime.Now;
}

public record PixelColorUndoCommand(byte Pixel, Color OldColor, Color NewColor) : BaseUndoCommand;

public record ModifySkinUndoCommand(SkinInfo OldInfo, SkinInfo NewInfo) : BaseUndoCommand;
