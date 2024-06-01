/* C# Assignment 02
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 29th, 2024
*/

using System;

namespace WorkingWithMethods
{
    public static class ArrayUtilities
    {
        public static int[] GenerateNumbers(int length)
        {
            int[] numbers = new int[length];
            for (int i = 0; i < length; i++)
            {
                numbers[i] = i + 1;
            }
            return numbers;
        }

        public static void Reverse(int[] array)
        {
            int length = array.Length;
            for (int i = 0; i < length / 2; i++)
            {
                int temp = array[i];
                array[i] = array[length - i - 1];
                array[length - i - 1] = temp;
            }
        }

        public static void PrintNumbers(int[] array)
        {
            foreach (int number in array)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}

