using System;

namespace Zadanie01_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pole prostokąta
            Console.Write("Wprowadź długość boku A: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Wprowadź długość boku B: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write($"Pole prostokąta wynosi: {a * b}");

        }
    }
}
