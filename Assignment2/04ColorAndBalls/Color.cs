/*
Create a Color class:
On a computer, colors are typically represented with a red, green, blue, and alpha
(transparency) value, usually in the range of 0 to 255. Add these as instance variables.
A constructor that takes a red, green, blue, and alpha value.
A constructor that takes just red, green, and blue, while alpha defaults to 255
(opaque).
Methods to get and set the red, green, blue, and alpha values from a Colorinstance.
A method to get the grayscale value for the color, which is the average of the red,
green and blue values
*/

using System;

namespace BallGame
{
    public class Color
    {
        private int red;
        private int green;
        private int blue;
        private int alpha;

        // Constructor with red, green, blue, and alpha values
        public Color(int red, int green, int blue, int alpha)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = alpha;
        }

        // Constructor with red, green, and blue values, alpha defaults to 255
        public Color(int red, int green, int blue)
            : this(red, green, blue, 255)
        {
        }

        // Getters and setters
        public int Red
        {
            get { return red; }
            set { red = value; }
        }

        public int Green
        {
            get { return green; }
            set { green = value; }
        }

        public int Blue
        {
            get { return blue; }
            set { blue = value; }
        }

        public int Alpha
        {
            get { return alpha; }
            set { alpha = value; }
        }

        // Method to get the grayscale value
        public int GetGrayscale()
        {
            return (red + green + blue) / 3;
        }
    }
}
