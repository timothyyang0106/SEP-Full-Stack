/* C# Assignment 01
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 28th, 2024
*/

/*
Write a program that finds the longest sequence of equal elements in an array of integers.
If several longest sequences exist, print the leftmost one.
Input Output
2 1 1 2 3 3 2 2 2 1 2 2 2
1 1 1 2 3 1 3 3 1 1 1
4 4 4 4 4 4 4 4
0 1 1 5 2 2 6 3 3 1 1
*/

using System;
using System.Linq;

namespace LongestEqualSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the array of integers
            Console.WriteLine("Enter the array of integers (space separated):");
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int maxLength = 0;
            int currentLength = 1;
            int longestSequenceElement = array[0];
            int currentElement = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == currentElement)
                {
                    currentLength++;
                }
                else
                {
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        longestSequenceElement = currentElement;
                    }
                    currentElement = array[i];
                    currentLength = 1;
                }
            }

            // Final check for the last sequence in the array
            if (currentLength > maxLength)
            {
                maxLength = currentLength;
                longestSequenceElement = currentElement;
            }

            // Print the longest sequence
            for (int i = 0; i < maxLength; i++)
            {
                Console.Write(longestSequenceElement + " ");
            }
            Console.WriteLine();
        }
    }
}
