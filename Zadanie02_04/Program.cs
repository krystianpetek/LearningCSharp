using System;

namespace Zadanie02_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program oblicza wartość z równiania ax+b = c");
            double a, b, c;
            Console.Write("Podaj A: ");
            a = double.Parse(Console.ReadLine());
            if (a == 0)
            {
                Console.WriteLine("Niedozwolona wartość współczynnika A");
                return;
            }
            Console.Write("Podaj B: ");
            b = double.Parse(Console.ReadLine());
            Console.Write("Podaj C: ");
            c = double.Parse(Console.ReadLine());

            double wynik = (-b + c) / a;
            Console.WriteLine($"Wartość równania to: x = {wynik}");
        }
    }
}
