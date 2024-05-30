/* C# Assignment 01
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 28th, 2024
*/

/*
Write a program that finds the most frequent number in a given sequence of numbers. In
case of multiple numbers with the same maximal frequency, print the leftmost of them
Input Output
4 1 1 4 2 3 4 4 1 2 4 9 3 The number 4 is the most frequent (occurs 5 times)
7 7 7 0 2 2 2 0 10 10 10 The numbers 2, 7 and 10 have the same maximal
frequence (each occurs 3 times). The leftmost of them is 7.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the sequence of numbers
            Console.WriteLine("Enter the sequence of numbers (space separated):");
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // Dictionary to store the frequency of each number
            Dictionary<int, int> frequencyDict = new Dictionary<int, int>();

            // Track the most frequent number and its frequency
            int mostFrequentNumber = array[0];
            int maxFrequency = 1;

            foreach (int number in array)
            {
                if (frequencyDict.ContainsKey(number))
                {
                    frequencyDict[number]++;
                }
                else
                {
                    frequencyDict[number] = 1;
                }

                // Check if this number has a higher frequency or is the leftmost in case of tie
                if (frequencyDict[number] > maxFrequency || 
                    (frequencyDict[number] == maxFrequency && Array.IndexOf(array, number) < Array.IndexOf(array, mostFrequentNumber)))
                {
                    mostFrequentNumber = number;
                    maxFrequency = frequencyDict[number];
                }
            }

            // Print the most frequent number and its frequency
            Console.WriteLine($"The number {mostFrequentNumber} is the most frequent (occurs {maxFrequency} times).");
        }
    }
}
