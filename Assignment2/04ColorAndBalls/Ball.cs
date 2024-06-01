/*
Create a Ball class:
The Ball class should have instance variables for size and color (the Color class you just
created). Let’s also add an instance variable that keeps track of the number of times it
has been thrown.
Create any constructors you feel would be useful.
Create a Pop method, which changes the ball’s size to 0.
Create a Throw method that adds 1 to the throw count, but only if the ball hasn’t been
popped (has a size of 0).
A method that returns the number of times the ball has been thrown.
*/

using System;

namespace BallGame
{
    public class Ball
    {
        private int size;
        private Color color;
        private int throwCount;

        // Constructor with size and color
        public Ball(int size, Color color)
        {
            this.size = size;
            this.color = color;
            this.throwCount = 0;
        }

        // Method to pop the ball
        public void Pop()
        {
            size = 0;
        }

        // Method to throw the ball
        public void Throw()
        {
            if (size > 0)
            {
                throwCount++;
            }
        }

        // Method to get the throw count
        public int GetThrowCount()
        {
            return throwCount;
        }

        // Getters and setters
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
    }
}
