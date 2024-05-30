/* C# Assignment 01
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 28th, 2024
*/

/*
Write a method that calculates all prime numbers in given range and returns them as array
of integers
static int[] FindPrimesInRange(startNum, endNum)
{
}
*/

using System;
using System.Collections.Generic;

namespace PrimeNumbersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNum = GetValidNumber("Enter the start number (greater than or equal to 2): ", 2, int.MaxValue);
            int endNum = GetValidNumber("Enter the end number (greater than or equal to the start number): ", startNum, int.MaxValue);

            int[] primes = FindPrimesInRange(startNum, endNum);

            Console.WriteLine($"Prime numbers in the range {startNum} to {endNum}:");
            foreach (int prime in primes)
            {
                Console.Write(prime + " ");
            }
        }

        static int GetValidNumber(string prompt, int min, int max)
        {
            int number;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out number) && number >= min && number <= max)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Please enter a valid integer between {min} and {max}.");
                }
            }
            return number;
        }

        static int[] FindPrimesInRange(int startNum, int endNum)
        {
            List<int> primes = new List<int>();

            for (int num = startNum; num <= endNum; num++)
            {
                if (IsPrime(num))
                {
                    primes.Add(num);
                }
            }

            return primes.ToArray();
        }

        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}

