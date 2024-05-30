/* C# Assignment 01
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 28th, 2024
*/

/* What will happen if this code executes?
    Create a console application and enter the preceding code. Run the console application
and view the output. What happens?

When the code executes, a byte variable, which can only hold values from 0 to 255, 
is used in a loop that goes up to 499. Once i exceeds 255, it wraps around to 0 
due to overflow, and the loop continues indefinitely or until we stop it manually.
*/

/*
using System;

namespace AnalyzeByteOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 500;
            for (byte i = 0; i < max; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
*/

/*    What code could you add (don’t change any of the preceding code) to warn us about the
problem? 

By using the checked keyword with the try-catch block, we can effectively catch and 
handle overflow exceptions, ensuring that our program can respond appropriately to overflow conditions.
*/

using System;

namespace AnalyzeByteOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 500;
            try
            {
                for (byte i = 0; i < max; i = checked((byte)(i + 1)))
                {
                    Console.WriteLine(i);
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("OverflowException caught: " + ex.Message);
            }
        }
    }
}