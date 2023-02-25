using System.Collections.Generic;
using System.Drawing;

namespace BlasphemousSkinEditor
{
    public class URSystem
    {
        private Stack<Command> undo;
        private Stack<Command> redo;

        public URSystem()
        {
            Reset();
        }

        private void Reset()
        {
            undo = new Stack<Command>();
            redo = new Stack<Command>();
        }

        public void Do(Command command)
        {
            undo.Push(command);
            redo.Clear();
        }

        public Command Undo()
        {
            if (undo.Count == 0) return null;

            Command command = undo.Pop();
            redo.Push(command);
            return command;
        }

        public Command Redo()
        {
            if (redo.Count == 0) return null;

            Command command = redo.Pop();
            undo.Push(command);
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
