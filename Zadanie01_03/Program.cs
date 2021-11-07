using System;

namespace Zadanie01_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Program wyświetla pierwiastek kwadratowy z PI z dokładnością do 2 miejsc po przecinku " +
                $"{Math.Round(Math.Sqrt(Math.PI), 2)}");
        }
    }
}
