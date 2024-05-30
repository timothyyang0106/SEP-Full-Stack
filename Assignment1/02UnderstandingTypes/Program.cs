/* C# Assignment 01
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 28th, 2024
*/

using System;

namespace UnderstandingTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type\t\tBytes\t\tMin Value\t\t\tMax Value");

            // sbyte
            Console.WriteLine($"sbyte\t\t{sizeof(sbyte)}\t\t{sbyte.MinValue}\t\t\t\t{sbyte.MaxValue}");

            // byte
            Console.WriteLine($"byte\t\t{sizeof(byte)}\t\t{byte.MinValue}\t\t\t\t{byte.MaxValue}");

            // short
            Console.WriteLine($"short\t\t{sizeof(short)}\t\t{short.MinValue}\t\t\t\t{short.MaxValue}");

            // ushort
            Console.WriteLine($"ushort\t\t{sizeof(ushort)}\t\t{ushort.MinValue}\t\t\t\t{ushort.MaxValue}");

            // int
            Console.WriteLine($"int\t\t{sizeof(int)}\t\t{int.MinValue}\t\t\t{int.MaxValue}");

            // uint
            Console.WriteLine($"uint\t\t{sizeof(uint)}\t\t{uint.MinValue}\t\t\t\t{uint.MaxValue}");

            // long
            Console.WriteLine($"long\t\t{sizeof(long)}\t\t{long.MinValue}\t{long.MaxValue}");

            // ulong
            Console.WriteLine($"ulong\t\t{sizeof(ulong)}\t\t{ulong.MinValue}\t\t\t\t{ulong.MaxValue}");

            // float
            Console.WriteLine($"float\t\t{sizeof(float)}\t\t{float.MinValue}\t\t\t{float.MaxValue}");

            // double
            Console.WriteLine($"double\t\t{sizeof(double)}\t\t{double.MinValue}\t{double.MaxValue}");

            // decimal
            Console.WriteLine($"decimal\t\t{sizeof(decimal)}\t\t{decimal.MinValue}\t{decimal.MaxValue}");
        }
    }
}