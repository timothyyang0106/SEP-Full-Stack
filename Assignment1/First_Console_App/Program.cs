/* C# Assignment 01
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 28th, 2024
*/

/*  Understanding Data Types
    Test your Knowledge

1. What type would you choose for the following “numbers”?
    A person’s telephone number: string
    A person’s height: float or double
    A person’s age: int
    A person’s gender (Male, Female, Prefer Not To Answer): enum
    A person’s salary: decimal
    A book’s ISBN: string
    A book’s price: decimal
    A book’s shipping weight: float or double
    A country’s population: long
    The number of stars in the universe: BigInteger
    The number of employees in each of the small or medium businesses in the United Kingdom (up to about 50,000 employees per business): int

2. What are the difference between value type and reference type variables? What is boxing and unboxing?
    Value types store data directly; reference types store references to the data. 
    Boxing is converting a value type to a reference type (object), and unboxing is converting a reference type back to a value type.

3. What is meant by the terms managed resource and unmanaged resource in .NET?
    Managed resources are managed by the .NET runtime (e.g., memory), while unmanaged resources are managed by the OS (e.g., file handles, database connections).

4. What's the purpose of Garbage Collector in .NET?
The Garbage Collector automatically frees up memory by destroying objects that are no longer in use, helping to manage memory efficiently.
*/

using System;
class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their favorite color
        Console.WriteLine("What is your favorite color?");
        string favoriteColor = Console.ReadLine();

        // Ask the user for their favorite animal
        Console.WriteLine("What is your favorite animal?");
        string favoriteAnimal = Console.ReadLine();

        // Ask the user for their street address number
        Console.WriteLine("What is your street address number?");
        string streetAddressNumber = Console.ReadLine();

        // Generate and display the custom output
        string hackerName = favoriteColor + favoriteAnimal + streetAddressNumber;
        Console.WriteLine("Your hacker name is " + hackerName);

        // Intentionally introduce some errors to see compiler messages

        // Error 1: Undeclared variable
        // Console.WriteLine("This is an undeclared variable test: " + undeclaredVariable);

        // Error 2: Syntax error
        // Console.WriteLine("This is a syntax error test: " + missingSemicolon

        // Error 3: Type mismatch
        // int number = "This is not a number";

        // Uncomment the above lines one by one to see the compiler errors and messages
    }
}

