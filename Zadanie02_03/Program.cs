using System;

namespace Zadanie02_03
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

            switch (pitagoras)
            {
                case > 0:
                    Console.WriteLine($"x1 = {Math.Round(((-b) - Math.Sqrt(pitagoras)) / (2.0 * a), 2)}");
                    Console.WriteLine($"x2 = {Math.Round(((-b) + Math.Sqrt(pitagoras)) / (2.0 * a), 2)}");
                    break;
                case 0:
                    Console.WriteLine($"x0 = {Math.Round((-b) / 2d * a, 2)}");
                    break;
                default:
                    Console.WriteLine("BRAK");
                    break;
            }
        }
    }
}
