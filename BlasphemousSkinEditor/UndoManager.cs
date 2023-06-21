using System.Collections.Generic;
using System.Drawing;

namespace BlasphemousSkinEditor
{
    public class UndoManager
    {
        private const int MAX_STACK_SIZE = 20;

        private readonly List<Command> undo = new List<Command>();
        private readonly List<Command> redo = new List<Command>();

        public UndoManager()
        {
            Reset();
        }

        public void Reset()
        {
            undo.Clear();
            redo.Clear();
        }

        public void Do(Command command)
        {
            undo.Add(command);
            if (undo.Count > MAX_STACK_SIZE)
                undo.RemoveAt(0);
            redo.Clear();
        }

        public Command Undo()
        {
            if (undo.Count == 0) return null;

            Command command = undo[undo.Count - 1];
            undo.RemoveAt(undo.Count - 1);
            redo.Add(command);
            return command;
        }

        public Command Redo()
        {
            if (redo.Count == 0) return null;

            Command command = redo[redo.Count - 1];
            redo.RemoveAt(redo.Count - 1);
            undo.Add(command);
            return command;
        }
    }

    public class Command
    {
        public byte pixelIdx;
        public Color newColor;
        public Color oldColor;

        public Command(byte pixelIdx, Color newColor, Color oldColor)
        {
            this.pixelIdx = pixelIdx;
            this.newColor = newColor;
            this.oldColor = oldColor;
        }
    }
}
