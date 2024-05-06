
namespace Blasphemous.Modding.SkinEditor.Undo;

public class UndoManager
{
    private readonly List<IUndoCommand> undo = new();
    private readonly List<IUndoCommand> redo = new();

    public void Reset()
    {
        undo.Clear();
        redo.Clear();
    }

    public void Do(IUndoCommand command)
    {
        undo.Add(command);
        if (undo.Count > MAX_STACK_SIZE)
            undo.RemoveAt(0);
        redo.Clear();
    }

    public IUndoCommand Undo()
    {
        if (undo.Count == 0)
            return null;

        IUndoCommand command = undo[undo.Count - 1];
        undo.RemoveAt(undo.Count - 1);
        redo.Add(command);
        return command;
    }

    public IUndoCommand Redo()
    {
        if (redo.Count == 0)
            return null;

        IUndoCommand command = redo[redo.Count - 1];
        redo.RemoveAt(redo.Count - 1);
        undo.Add(command);
        return command;
    }

    private const int MAX_STACK_SIZE = 20;
}
