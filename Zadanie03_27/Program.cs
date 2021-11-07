using System;

namespace Zadanie03_27
{
    class Program
    {
        static void Main(string[] args)
        {
            int liczba_punktow = 100000000, i;
            int licznik = 0;
            double x, y, pi;
            Console.WriteLine("Proszę czekać...");
            Random r = new Random();
            for (i = 1; i < liczba_punktow; i++)
            {
                x = Math.Round(100 * (r.NextDouble())) / 100.0;
                y = Math.Round(100 * (r.NextDouble())) / 100.0;

                if (x * x + y * y <= 1)
                {
                    licznik = licznik + 1;
                }
            }
            pi = 4.0 * licznik / liczba_punktow;
            Console.WriteLine("Wartość PI = " + Math.PI);
            Console.WriteLine("Obliczona wartość PI = " + pi);
        }
    }
}
