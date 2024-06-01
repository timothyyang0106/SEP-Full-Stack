using System;

namespace FibonacciSequence
{
    public static class FibonacciUtilities
    {
        public static int Fibonacci(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("The input must be a positive integer.");
            }
            if (n == 1 || n == 2)
            {
                return 1;
            }
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public static void FibonacciLength(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.Write(FibonacciUtilities.Fibonacci(i) + " ");
            }
            Console.WriteLine();
        }
    }
}