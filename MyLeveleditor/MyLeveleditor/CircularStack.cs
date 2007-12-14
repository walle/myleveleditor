using System;
using System.Collections.Generic;
using System.Text;

namespace MyLeveleditor
{
    public class CircularStack<T>
    {
        /// <summary>
        /// Default capacity = 10
        /// </summary>
        int capacity;
        List<T> items;

        public CircularStack()
        {
            this.capacity = 10;
            items = new List<T>(capacity);
        }

        public CircularStack(int capacity)
        {
            if (capacity > 0)
            {
                this.capacity = capacity;
            }
            else
            {
                this.capacity = 10;
                throw new ArgumentOutOfRangeException("Capacity must be more then 0.");
            }

            items = new List<T>(capacity);
        }

        /// <summary>
        /// Push the item onto the stack, remove the bottom one if we are up in capacity
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Push(T item)
        {
            if (capacity == items.Count)
            {
                items.RemoveAt(0);
                items.Add(item);
            }
            else
            {
                items.Add(item);
            }
        }

        /// <summary>
        /// Take of the top of the stack
        /// </summary>
        /// <returns>Top item in stack</returns>
        public T Pop()
        {
            if (items.Count >= 1)
            {
                int index = (items.Count - 1);
                T top = items[index];
                items.RemoveAt(index);

                return top;
            }
            else
            {
                throw new InvalidOperationException("Stack is empty.");
            }
        }

        /// <summary>
        /// Look at the top of the stack without removing it
        /// </summary>
        /// <returns>Top item in stack</returns>
        public T Peek()
        {
            int index = (items.Count - 1);

            return items[index];
        }

        /// <summary>
        /// Clear the stack
        /// </summary>
        public void Clear()
        {
            items.Clear();
        }

        /// <summary>
        /// Gets or sets the capacity for the circular stack
        /// </summary>
        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                if (value > 0)
                {
                    this.capacity = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Capacity must be more then 0.");
                }
            }
        }

        /// <summary>
        /// Enabeled random acess even though this is a "stack"
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }

    }
}
