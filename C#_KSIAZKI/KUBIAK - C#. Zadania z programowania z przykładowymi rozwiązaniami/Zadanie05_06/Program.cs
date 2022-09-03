using System;

namespace Zadanie05_06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj n: ");
            int.TryParse(Console.ReadLine(), out int n);
            LiczbaTrojkatna liczbaT = new LiczbaTrojkatna();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"#{i} = {liczbaT.LiczbaT(i)} ");

            }

            Console.WriteLine("\nLUB\n");

            for (int i = 1; i <= n; i++)
            {
                Console.Write($"#{i} = ");
                for (int j = 1; j <= i; j++)
                {
                    if (j == i)
                        Console.Write($"{j}");
                    else
                        Console.Write($"{j} + ");

                }
                Console.Write($" = {liczbaT.LiczbaT(i)} ");

                Console.WriteLine();
            }

        }
    }
    class LiczbaTrojkatna
    {
        public int LiczbaT(int n)
        {

            if (n > 1)
                return n + LiczbaT(n - 1);
            return 1;
        }
    }
}
