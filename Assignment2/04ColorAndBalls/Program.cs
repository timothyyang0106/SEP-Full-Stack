/* C# Assignment 02
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 29th, 2024
*/

/*
Try creating the two classes below, and make a simple program to work with them, as
described below
Create a Color class:
On a computer, colors are typically represented with a red, green, blue, and alpha
(transparency) value, usually in the range of 0 to 255. Add these as instance variables.
A constructor that takes a red, green, blue, and alpha value.
A constructor that takes just red, green, and blue, while alpha defaults to 255
(opaque).
Methods to get and set the red, green, blue, and alpha values from a Colorinstance.
A method to get the grayscale value for the color, which is the average of the red,
green and blue values.
Create a Ball class:
The Ball class should have instance variables for size and color (the Color class you just
created). Let’s also add an instance variable that keeps track of the number of times it
has been thrown.
Create any constructors you feel would be useful.
Create a Pop method, which changes the ball’s size to 0.
Create a Throw method that adds 1 to the throw count, but only if the ball hasn’t been
popped (has a size of 0).
A method that returns the number of times the ball has been thrown.
Write some code in your Main method to create a few balls, throw them around a few
times, pop a few, and try to throw them again, and print out the number of times that the
balls have been thrown. (Popped balls shouldn’t have changed.)
*/

using System;

namespace BallGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few colors
            Color red = new Color(255, 0, 0);
            Color green = new Color(0, 255, 0);
            Color blue = new Color(0, 0, 255, 128); // semi-transparent blue

            // Create a few balls
            Ball ball1 = new Ball(10, red);
            Ball ball2 = new Ball(15, green);
            Ball ball3 = new Ball(20, blue);

            // Throw the balls
            ball1.Throw();
            ball1.Throw();
            ball2.Throw();
            ball3.Throw();
            ball3.Throw();
            ball3.Throw();

            // Pop a ball
            ball2.Pop();

            // Try throwing the popped ball
            ball2.Throw();

            // Print the number of times each ball has been thrown
            Console.WriteLine($"Ball 1 has been thrown {ball1.GetThrowCount()} times.");
            Console.WriteLine($"Ball 2 has been thrown {ball2.GetThrowCount()} times.");
            Console.WriteLine($"Ball 3 has been thrown {ball3.GetThrowCount()} times.");
        }
    }
}
