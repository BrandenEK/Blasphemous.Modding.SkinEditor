
namespace Blasphemous.Modding.SkinEditor.Undo;

public interface IUndoCommand { }

public record PixelColorUndoCommand(byte Pixel, Color OldColor, Color NewColor) : IUndoCommand;
