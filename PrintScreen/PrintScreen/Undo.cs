using System.Collections.Generic;
using System.Drawing;

namespace FlexScreen
{
    public class Undo
    {
        List<DrawingTool> UndoStack = new List<DrawingTool>(64);
        int index = 0;

        public bool CanUndo { get { return index > 0; } }

        public void Push(DrawingTool undoItem)
        {
            if (index >= UndoStack.Count)
            {
                UndoStack.Add(undoItem);
            }
            else
            {
                UndoStack[index] = undoItem;
            }
            index++;
        }

        public DrawingTool Pop()
        {
            if (index > 0)
            {
                return UndoStack[--index];
            }
            return null;
        }

        public DrawingTool Remove()
        {
            if (index > 0)
            {
                --index;
                DrawingTool result = UndoStack[index];
                UndoStack.RemoveAt(index);
                return result;
            }
            return null;
        }

        public DrawingTool Next()
        {
            if (index < UndoStack.Count)
            {
                return UndoStack[index++];
            }
            return null;
        }
    }

}
