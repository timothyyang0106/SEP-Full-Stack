/* C# Assignment 01
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 28th, 2024
*/

/*
Write a program that reads a string from the console, reverses its letters and prints the
result back at the console.
Write in two ways
Convert the string to char array, reverse it, then convert it to string again
Print the letters of the string in back direction (from the last to the first) in a for-loop
Input Output
sample elpmas
24tvcoi92 29iocvt42
*/

/*
// Method 1: Convert the string to char array, reverse it, 
// then convert it to string again

using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the string from the console
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            // Convert the string to a char array
            char[] charArray = input.ToCharArray();

            // Reverse the char array
            Array.Reverse(charArray);

            // Convert the char array back to a string
            string reversedString = new string(charArray);

            // Print the reversed string
            Console.WriteLine("Reversed string (method 1):");
            Console.WriteLine(reversedString);
        }
    }
}
*/

// Print the letters of the string in back direction 
// (from the last to the first) in a for-loop

using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the string from the console
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            // Print the string in reverse order using a for-loop
            Console.WriteLine("Reversed string (method 2):");
            for (int i = input.Length - 1; i >= 0; i--)
            {
                Console.Write(input[i]);
            }
            Console.WriteLine();
        }
    }
}
