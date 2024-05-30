/* C# Assignment 01
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 28th, 2024
*/

/*
Write a simple program that defines a variable representing a birth date and calculates
how many days old the person with that birth date is currently.
For extra credit, output the date of their next 10,000 day (about 27 years) anniversary.
Note: once you figure out their age in days, you can calculate the days until the next
anniversary using int daysToNextAnniversary = 10000 - (days % 10000); .
*/

using System;

namespace BirthDateCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the birth date
            Console.WriteLine("Enter your birth date (yyyy-mm-dd): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            // Calculate the number of days old
            DateTime currentDate = DateTime.Now;
            TimeSpan ageSpan = currentDate - birthDate;
            int daysOld = ageSpan.Days;

            // Calculate days until the next 10,000-day anniversary
            int daysToNextAnniversary = 10000 - (daysOld % 10000);
            DateTime nextAnniversary = currentDate.AddDays(daysToNextAnniversary);

            // Output the results
            Console.WriteLine($"You are {daysOld} days old.");
            Console.WriteLine($"Your next 10,000-day anniversary is on {nextAnniversary.ToShortDateString()}.");
        }
    }
}
