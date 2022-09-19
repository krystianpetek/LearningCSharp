using System;
namespace Sumator4Bitowy
{
    class Program
    {
        static int X = 0;
        static int Y = 0;
        static int XY = 0;
        static void Main(string[] args)
        {
            X = 0;
            while (X != 16)
            {
                Y = 0;
                while (Y != 16)
                {
                    XY = X + Y;
                    Console.WriteLine($"{XnaString} + {YnaString} = {sumaXY}");
                    Y++;
                }
                X++;
            }
        }
        static string XnaString => Convert.ToString(X, toBase: 2).PadLeft(4, '0');
        static string YnaString => Convert.ToString(Y, toBase: 2).PadLeft(4, '0');
        static string sumaXY => Convert.ToString(XY, toBase: 2).PadLeft(5, '0');
    }
}