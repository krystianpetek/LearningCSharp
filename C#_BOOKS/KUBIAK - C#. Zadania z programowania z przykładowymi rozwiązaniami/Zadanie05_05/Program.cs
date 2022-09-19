using System;

namespace Zadanie05_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj n: ");
            int n = int.Parse(Console.ReadLine());
            Silnia silnia = new Silnia();

            for (int i = 1; i <= n; i++)
                Console.WriteLine($"!{i} - { silnia.Oblicz(i)}");
        }
    }
    class Silnia
    {
        public long Oblicz(int n)
        {
            if (n > 0)
            {
                return n * Oblicz(n - 1);
            }
            return 1;
        }
    }
}
