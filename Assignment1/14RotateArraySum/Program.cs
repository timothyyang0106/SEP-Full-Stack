/* C# Assignment 01
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 28th, 2024
*/

/*
Write a program to read an array of n integers (space separated on a single line) and an
integer k, rotate the array right k times and sum the obtained arrays after each rotation as
shown below.
After r rotations the element at position I goes to position (I + r) % n.
The sum[] array can be calculated by two nested loops: for r = 1 ... k; for I = 0 ... n-1.
Input Output Comments
3 2 4 -1 3 2 5 6 rotated1[] = -1 3 2 4
2 rotated2[] = 4 -1 3 2
sum[] = 3 2 5 6
1 2 3 4 5 12 10 8 6 9 rotated1[] = 5 1 2 3 4
3 rotated2[] = 4 5 1 2 3
rotated3[] = 3 4 5 1 2
sum[] = 12 10 8 6 9
*/

using System;
using System.Linq;

namespace ArrayRotationAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the array of integers
            Console.WriteLine("Enter the array of integers (space separated):");
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // Read the number of rotations
            Console.WriteLine("Enter the number of rotations:");
            int k = int.Parse(Console.ReadLine());

            int n = array.Length;
            int[] sumArray = new int[n];

            // Perform k rotations
            for (int r = 1; r <= k; r++)
            {
                int[] rotatedArray = new int[n];

                // Rotate array by r positions to the right
                for (int i = 0; i < n; i++)
                {
                    rotatedArray[(i + r) % n] = array[i];
                }

                // Add the rotated array to the sum array
                for (int i = 0; i < n; i++)
                {
                    sumArray[i] += rotatedArray[i];
                }

                // Print the rotated array for debugging
                Console.WriteLine($"Rotated array after {r} rotation(s): {string.Join(" ", rotatedArray)}");
            }

            // Print the sum array
            Console.WriteLine($"Sum array: {string.Join(" ", sumArray)}");
        }
    }
}
