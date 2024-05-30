/* C# Assignment 01
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 28th, 2024
*/

/*
Write a program that reverses the words in a given sentence without changing the
punctuation and spaces
Use the following separators between the words: . , : ; = ( ) & [ ] " ' \ / ! ? (space).
All other characters are considered part of words, e.g. C++, a+b, and a77 are
considered valid words.
The sentences always start by word and end by separator.
C# is not C++, and PHP is not Delphi!
Delphi not is PHP, and C++ not is C#!
The quick brown fox jumps over the lazy dog /Yes! Really!!!/.
Really Yes dog lazy the over jumps fox brown /quick! The!!!/.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseWordsInSentence
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the sentence from the console
            Console.WriteLine("Enter a sentence:");
            string input = Console.ReadLine();

            // Define the separators
            string separators = @".,:;=()&[\]""'!/? ";

            // Reverse the words in the sentence
            string result = ReverseWords(input, separators);

            // Print the result
            Console.WriteLine("Reversed sentence:");
            Console.WriteLine(result);
        }

        static string ReverseWords(string sentence, string separators)
        {
            // Split the sentence into words and separators
            List<string> words = new List<string>();
            List<string> parts = new List<string>();

            StringBuilder currentPart = new StringBuilder();
            bool isSeparator = separators.Contains(sentence[0]);

            foreach (char c in sentence)
            {
                if (separators.Contains(c))
                {
                    if (!isSeparator)
                    {
                        words.Add(currentPart.ToString());
                        currentPart.Clear();
                    }
                    isSeparator = true;
                    currentPart.Append(c);
                }
                else
                {
                    if (isSeparator)
                    {
                        parts.Add(currentPart.ToString());
                        currentPart.Clear();
                    }
                    isSeparator = false;
                    currentPart.Append(c);
                }
            }

            if (currentPart.Length > 0)
            {
                if (isSeparator)
                {
                    parts.Add(currentPart.ToString());
                }
                else
                {
                    words.Add(currentPart.ToString());
                }
            }

            // Reverse the words list
            words.Reverse();

            // Reconstruct the sentence
            StringBuilder result = new StringBuilder();
            int wordIndex = 0, partIndex = 0;
            bool lastWasSeparator = separators.Contains(sentence[0]);

            for (int i = 0; i < sentence.Length; i++)
            {
                if (lastWasSeparator)
                {
                    if (partIndex < parts.Count)
                    {
                        result.Append(parts[partIndex++]);
                        lastWasSeparator = false;
                    }
                }
                else
                {
                    if (wordIndex < words.Count)
                    {
                        result.Append(words[wordIndex++]);
                        lastWasSeparator = true;
                    }
                }
            }

            // Handle any remaining words or parts
            while (wordIndex < words.Count)
            {
                result.Append(words[wordIndex++]);
            }

            while (partIndex < parts.Count)
            {
                result.Append(parts[partIndex++]);
            }

            return result.ToString();
        }
    }
}
