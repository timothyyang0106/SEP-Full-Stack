/* C# Assignment 01
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 28th, 2024
*/

using System;

namespace CenturyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of centuries: ");
            int centuries = int.Parse(Console.ReadLine());

            int years = centuries * 100;
            long days = (long)(years * 365.2425); // average number of days in a year accounting for leap years
            long hours = days * 24;
            long minutes = hours * 60;
            long seconds = minutes * 60;
            long milliseconds = seconds * 1000;
            long microseconds = milliseconds * 1000;
            decimal nanoseconds = (decimal)microseconds * 1000;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
        }
    }
}

/*
Controlling Flow and Converting Types

1. What happens when you divide an int variable by 0?
    An exception is thrown (System.DivideByZeroException).
2. What happens when you divide a double variable by 0?
    The result is Infinity or -Infinity, or NaN if the numerator is 0.
3. What happens when you overflow an int variable, that is, set it to a value beyond its range?
    The value wraps around to the minimum value (unchecked context).
4. What is the difference between x = y++; and x = ++y
    x = y++; assigns y to x, then increments y. x = ++y; increments y, then assigns y to x.
5. What is the difference between break, continue, and return when used inside a loop statement?
    break: Exits the loop. continue: Skips to the next iteration. return: Exits the method.
6. What are the three parts of a for statement and which of them are required?
    Initialization, condition, iterator. None are required.
7. What is the difference between the = and == operators?
    = assigns a value, == compares values.
8. Does the following statement compile? for ( ; true; ) ;
    Yes, it creates an infinite loop.
9. What does the underscore _ represent in a switch expression?
    It acts as a default case, matching any value not matched by other cases.
10. What interface must an object implement to be enumerated over by using the foreach statement?
    IEnumerable.
*/
