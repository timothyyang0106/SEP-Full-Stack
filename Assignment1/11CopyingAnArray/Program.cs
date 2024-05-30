/* C# Assignment 01
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 28th, 2024
*/

/* 
02 Arrays and Strings
Test your Knowledge
1. When to use String vs. StringBuilder in C# ?
Use String for immutable text. Use StringBuilder for efficient, mutable string manipulations.

2. What is the base class for all arrays in C#?
System.Array

3. How do you sort an array in C#?
Use Array.Sort(array)

4. What property of an array object can be used to get the total number of elements in
an array?
The Length property.

5. Can you store multiple data types in System.Array?
No, System.Array can only store elements of the same type.

6. What’s the difference between the System.Array.CopyTo() and System.Array.Clone()?
CopyTo() copies elements to an existing array. Clone() creates a shallow copy of the array.
*/


/*
Copying an Array
Write code to create a copy of an array. First, start by creating an initial array. (You can use
whatever type of data you want.) Let’s start with 10 items. Declare an array variable and
assign it a new array with 10 items in it. Use the things we’ve discussed to put some values
in the array.
Now create a second array variable. Give it a new array with the same length as the first.
Instead of using a number for this length, use the Lengthproperty to get the size of the
original array.
Use a loop to read values from the original array and place them in the new array. Also
print out the contents of both arrays, to be sure everything copied correctly.
*/

using System;

namespace ArrayCopyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create and initialize the original array with 10 items
            int[] originalArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Create the second array with the same length as the original array
            int[] copiedArray = new int[originalArray.Length];

            // Copy values from the original array to the new array using a loop
            for (int i = 0; i < originalArray.Length; i++)
            {
                copiedArray[i] = originalArray[i];
            }

            // Print the contents of the original array
            Console.WriteLine("Original Array:");
            foreach (int item in originalArray)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine(); // New line for better readability

            // Print the contents of the copied array
            Console.WriteLine("Copied Array:");
            foreach (int item in copiedArray)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine(); // New line for better readability
        }
    }
}
