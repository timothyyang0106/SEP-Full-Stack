/* C# Assignment 01
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 28th, 2024
*/

/*
Write a simple program that lets the user manage a list of elements. It can be a grocery list,
"to do" list, etc. Refer to Looping Based on a Logical Expression if necessary to see how to
implement an infinite loop. Each time through the loop, ask the user to perform an
operation, and then show the current contents of their list. The operations available should
be Add, Remove, and Clear. The syntax should be as follows:
+ some item
- some item
--
Your program should read in the user's input and determine if it begins with a “+” or “-“ or
if it is simply “—“ . In the first two cases, your program should add or remove the string
given ("some item" in the example). If the user enters just “—“ then the program should
clear the current list. Your program can start each iteration through its loop with the
following instruction:
Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
*/

using System;
using System.Collections.Generic;

namespace ListManager
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> itemList = new List<string>();

            while (true)
            {
                Console.WriteLine("Enter command (+ item, - item, or -- to clear):");
                string input = Console.ReadLine().Trim();

                if (input == "--")
                {
                    itemList.Clear();
                    Console.WriteLine("List cleared.");
                }
                else if (input.StartsWith("+"))
                {
                    string itemToAdd = input.Substring(1).Trim();
                    itemList.Add(itemToAdd);
                    Console.WriteLine($"Added: {itemToAdd}");
                }
                else if (input.StartsWith("-"))
                {
                    string itemToRemove = input.Substring(1).Trim();
                    if (itemList.Remove(itemToRemove))
                    {
                        Console.WriteLine($"Removed: {itemToRemove}");
                    }
                    else
                    {
                        Console.WriteLine($"Item not found: {itemToRemove}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }

                // Show current contents of the list
                Console.WriteLine("Current list:");
                foreach (string item in itemList)
                {
                    Console.WriteLine($"- {item}");
                }
                Console.WriteLine(); // Add a blank line for readability
            }
        }
    }
}
