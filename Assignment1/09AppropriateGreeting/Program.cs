/* C# Assignment 01
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 28th, 2024
*/

/*
Write a program that greets the user using the appropriate greeting for the time of day.
Use only if , not else or switch , statements to do so. Be sure to include the following
greetings:
"Good Morning"
"Good Afternoon"
"Good Evening"
"Good Night"
It's up to you which times should serve as the starting and ending ranges for each of the
greetings. If you need a refresher on how to get the current time, see DateTime
Formatting. When testing your program, you'll probably want to use a DateTime variable
you define, rather than the current time. Once you're confident the program works
correctly, you can substitute DateTime.Now for your variable (or keep your variable and just
assign DateTime.Now as its value, which is often a better approach).
*/

using System;

namespace GreetingBasedOnTime
{
    class Program
    {
        static void Main(string[] args)
        {
            // For testing purposes, you can set a specific time here
            // DateTime currentTime = new DateTime(2024, 5, 28, 14, 30, 0); // Example: 2:30 PM
            DateTime currentTime = DateTime.Now; // Use current time in production

            int hour = currentTime.Hour;

            if (hour >= 5 && hour < 12)
            {
                Console.WriteLine("Good Morning");
            }
            
            if (hour >= 12 && hour < 17)
            {
                Console.WriteLine("Good Afternoon");
            }
            
            if (hour >= 17 && hour < 21)
            {
                Console.WriteLine("Good Evening");
            }
            
            if (hour >= 21 || hour < 5)
            {
                Console.WriteLine("Good Night");
            }
        }
    }
}
