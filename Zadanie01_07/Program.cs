using System;

namespace Zadanie01_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Wprowadź liczbę X: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Wprowadź liczbę Y: ");
            double y = double.Parse(Console.ReadLine());
            Console.WriteLine($"Dla x = {x} i y = {y}");
            Console.WriteLine("Suma: ".PadRight(10)+$"{Math.Round(x+y,2):F2}");
            Console.WriteLine("Różnica: ".PadRight(10)+$"{Math.Round(x -y,2):F2}");
            Console.WriteLine("Iloczyn: ".PadRight(10)+$"{Math.Round(x *y,2):F2}");
            Console.WriteLine("Iloraz: ".PadRight(10)+$"{Math.Round(x /y,2):F2}");
        }
    }
}
