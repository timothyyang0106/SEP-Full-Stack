/* C# Assignment 01
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 28th, 2024
*/

/*
Write a program that extracts from a given text all palindromes, e.g. “ABBA”, “lamal”, “exe”
and prints them on the console on a single line, separated by comma and space.Print all
unique palindromes (no duplicates), sorted
Hi,exe? ABBA! Hog fully a string: ExE. Bob
a, ABBA, exe, ExE
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PalindromeExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the input text
            Console.WriteLine("Enter the text:");
            string input = Console.ReadLine();

            // Extract words from the text
            string[] words = ExtractWords(input);

            // Find unique palindromes
            HashSet<string> palindromes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (string word in words)
            {
                if (IsPalindrome(word))
                {
                    palindromes.Add(word);
                }
            }

            // Sort the palindromes
            List<string> sortedPalindromes = palindromes.OrderBy(p => p, StringComparer.OrdinalIgnoreCase).ToList();

            // Print the sorted palindromes
            Console.WriteLine(string.Join(", ", sortedPalindromes));
        }

        static string[] ExtractWords(string input)
        {
            return Regex.Split(input, @"\W+").Where(word => !string.IsNullOrEmpty(word)).ToArray();
        }

        static bool IsPalindrome(string word)
        {
            int length = word.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (char.ToLower(word[i]) != char.ToLower(word[length - i - 1]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
