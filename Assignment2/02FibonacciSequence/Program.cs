﻿/* C# Assignment 02
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 29th, 2024
*/

/*
The Fibonacci sequence is a sequence of numbers where the first two numbers are 1 and 1,
and every other number in the sequence after it is the sum of the two numbers before it. So
the third number is 1 + 1, which is 2. The fourth number is the 2nd number plus the 3rd,
which is 1 + 2. So the fourth number is 3. The 5th number is the 3rd number plus the 4th
number: 2 + 3 = 5. This keeps going forever.
The first few numbers of the Fibonacci sequence are: 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, ...
Because one number is defined by the numbers before it, this sets up a perfect
opportunity for using recursion.
Your mission, should you choose to accept it, is to create a method called Fibonacci, which
takes in a number and returns that number of the Fibonacci sequence. So if someone calls
Fibonacci(3), it would return the 3rd number in the Fibonacci sequence, which is 2. If
someone calls Fibonacci(8), it would return 21.
In your Mainmethod, write code to loop through the first 10 numbers of the Fibonacci
sequence and print them out.
Hint #1:Start with your base case. We know that if it is the 1st or 2nd number, the value will
be 1.
Hint #2:For every other item, how is it defined in terms of the numbers before it? Can you
come up with an equation or formula that calls the Fibonaccimethod again?
*/

using System;

namespace FibonacciSequence
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The first 10 numbers of the Fibonacci sequence are:");
            FibonacciUtilities.FibonacciLength(10);

            // Ask the user for the desired length of the Fibonacci sequence
            Console.WriteLine("Enter the length of the Fibonacci sequence you want to generate:");
            if (int.TryParse(Console.ReadLine(), out int length) && length > 0)
            {
                Console.WriteLine($"The first {length} numbers of the Fibonacci sequence are:");
                FibonacciUtilities.FibonacciLength(length);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }
        }
    }
}
