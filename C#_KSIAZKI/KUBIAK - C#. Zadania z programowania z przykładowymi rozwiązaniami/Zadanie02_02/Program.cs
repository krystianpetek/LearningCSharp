using System;

namespace Zadanie02_02
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;
            Console.Write("Podaj liczbę A: ");
            a = double.Parse(Console.ReadLine());
            if (a == 0)
            {
                Console.WriteLine("Niedozwolona wartość współczynnika A");
                return;
            }
            Console.Write("Podaj liczbę B: ");
            b = double.Parse(Console.ReadLine());
            Console.Write("Podaj liczbę C: ");
            c = double.Parse(Console.ReadLine());

            double pitagoras = (b * 1d * b) - (4 * a * c);
            if (pitagoras > 0)
            {
                Console.WriteLine($"x1 = {((-b) - Math.Sqrt(pitagoras)) / (2.0 * a)}");
                Console.WriteLine($"x2 = {((-b) + Math.Sqrt(pitagoras)) / (2.0 * a)}");
            }
            else if (pitagoras == 0)
            {
                Console.WriteLine($"x0 = {(-b) / 2d * a}");
            }
            else
            {
                Console.WriteLine("BRAK");
            }
        }
    }
}
