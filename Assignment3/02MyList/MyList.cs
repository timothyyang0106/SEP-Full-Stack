using System;
using System.Collections.Generic;

namespace CustomList
{
    public class MyList<T>
    {
        private List<T> elements;

        public MyList()
        {
            elements = new List<T>();
        }

        // Method to add an element to the list
        public void Add(T element)
        {
            elements.Add(element);
        }

        // Method to remove an element at a specific index
        public T Remove(int index)
        {
            if (index < 0 || index >= elements.Count)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }
            T item = elements[index];
            elements.RemoveAt(index);
            return item;
        }

        // Method to check if the list contains a specific element
        public bool Contains(T element)
        {
            return elements.Contains(element);
        }

        // Method to clear the list
        public void Clear()
        {
            elements.Clear();
        }

        // Method to insert an element at a specific index
        public void InsertAt(T element, int index)
        {
            if (index < 0 || index > elements.Count)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }
            elements.Insert(index, element);
        }

        // Method to delete an element at a specific index
        public void DeleteAt(int index)
        {
            if (index < 0 || index >= elements.Count)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }
            elements.RemoveAt(index);
        }

        // Method to find an element at a specific index
        public T Find(int index)
        {
            if (index < 0 || index >= elements.Count)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }
            return elements[index];
        }
    }
}
