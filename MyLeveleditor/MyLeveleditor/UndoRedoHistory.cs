using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using MapAPI;

namespace MyLeveleditor
{
    class UndoRedoHistory
    {
        /// <summary>
        /// Default capacity for the undo redo stacks are 100
        /// </summary>
        int capacity = 100;
        CircularStack<Action> undoStack;
        CircularStack<Action> redoStack;

        // The target that is changed by the undo redo operations
        MapForm subject;

        public UndoRedoHistory(MapForm s)
        {
            this.capacity = 100;
            this.undoStack = new CircularStack<Action>(this.capacity);
            this.redoStack = new CircularStack<Action>(this.capacity);
            this.subject = s;
        }

        public UndoRedoHistory(int capacity, MapForm s)
        {
            this.capacity = capacity;
            this.undoStack = new CircularStack<Action>(this.capacity);
            this.redoStack = new CircularStack<Action>(this.capacity);
            this.subject = s;
        }

        public void Do(Action action)
        {
            redoStack.Clear();
            undoStack.Push(action);
        }

        public string Undo()
        {
            try
            {
                Action top = undoStack.Pop();
                redoStack.Push(top.Restore(subject));
                return top.ToString();
            }
            catch (Exception e)
            {
                throw new Exception("Undo stack is empty.\n"+e.Message);
            }
        }

        public string Redo()
        {
            try
            {
                Action top = redoStack.Pop();
                undoStack.Push(top.Restore(subject));
                return top.ToString();
            }
            catch (Exception e)
            {
                throw new Exception("Redo stack is empty.\n" + e.Message);
            }
        }
    }
}
