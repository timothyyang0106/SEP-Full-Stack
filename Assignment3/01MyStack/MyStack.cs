

using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class MyStack<T>
    {
        private List<T> elements;

        public MyStack()
        {
            elements = new List<T>();
        }

        // Method to return the number of elements in the stack
        public int Count()
        {
            return elements.Count;
        }

        // Method to pop an element from the stack
        public T Pop()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            T item = elements[^1];  // using ^1 to get the last element
            elements.RemoveAt(elements.Count - 1);
            return item;
        }

        // Method to push an element onto the stack
        public void Push(T item)
        {
            elements.Add(item);
        }
    }
}
