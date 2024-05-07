
namespace Blasphemous.Modding.SkinEditor.Undo;

public class UndoManager : IManager
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

    public void Undo()
    {
        if (undo.Count == 0)
            return;

        IUndoCommand command = undo[undo.Count - 1];
        undo.RemoveAt(undo.Count - 1);
        redo.Add(command);

        Logger.Info($"Undoing command: {command}");
        OnUndo?.Invoke(command);
    }

    public void Redo()
    {
        if (redo.Count == 0)
            return;

        IUndoCommand command = redo[redo.Count - 1];
        redo.RemoveAt(redo.Count - 1);
        undo.Add(command);

        Logger.Info($"Redoing command: {command}");
        OnRedo?.Invoke(command);
    }

    // Event handling

    public void Initialize()
    {
        Core.RecolorManager.OnPixelChanged += OnPixelChanged;
        Core.SaveManager.OnNewSkin += OnNewSkin;
        Core.SaveManager.OnOpenSkin += OnOpenSkin;
    }

    private void OnNewSkin()
    {
        Reset();
    }

    private void OnOpenSkin(string path)
    {
        Reset();
    }

    private void OnPixelChanged(byte pixel, Color oldColor, Color newColor)
    {
        Do(new PixelColorUndoCommand(pixel, oldColor, newColor));
    }

    public delegate void UndoRedoDelegate(IUndoCommand command);
    public event UndoRedoDelegate? OnUndo;
    public event UndoRedoDelegate? OnRedo;

    private const int MAX_STACK_SIZE = 20;
}
