/* C# Assignment 03
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 29th, 2024
*/

/*
Create a Generic List data structure MyList<T> that can store any data type.
Implement the following methods.
1. void Add (T element)
2. T Remove (int index)
3. bool Contains (T element)
4. void Clear ()
5. void InsertAt (T element, int index)
6. void DeleteAt (int index)
7. T Find (int index)
*/

using System;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of integers
            MyList<int> intList = new MyList<int>();
            intList.Add(1);
            intList.Add(2);
            intList.Add(3);

            Console.WriteLine("List contains 2: " + intList.Contains(2)); // Output: True

            intList.InsertAt(4, 1);
            Console.WriteLine("Element at index 1: " + intList.Find(1));  // Output: 4

            intList.DeleteAt(2);
            Console.WriteLine("Element at index 2 after deletion: " + intList.Find(2)); // Output: 3

            int removedElement = intList.Remove(1);
            Console.WriteLine("Removed element: " + removedElement);    // Output: 4

            intList.Clear();
            Console.WriteLine("List contains 1 after clearing: " + intList.Contains(1)); // Output: False

            // Create a list of strings
            MyList<string> stringList = new MyList<string>();
            stringList.Add("Hello");
            stringList.Add("World");

            Console.WriteLine("List contains 'World': " + stringList.Contains("World")); // Output: True

            stringList.InsertAt("C#", 1);
            Console.WriteLine("Element at index 1: " + stringList.Find(1));  // Output: C#

            stringList.DeleteAt(2);
            Console.WriteLine("Element at index 1 after deletion: " + stringList.Find(1)); // Output: C#

            string removedString = stringList.Remove(0);
            Console.WriteLine("Removed element: " + removedString);    // Output: Hello

            stringList.Clear();
            Console.WriteLine("List contains 'Hello' after clearing: " + stringList.Contains("Hello")); // Output: False
        }
    }
}
