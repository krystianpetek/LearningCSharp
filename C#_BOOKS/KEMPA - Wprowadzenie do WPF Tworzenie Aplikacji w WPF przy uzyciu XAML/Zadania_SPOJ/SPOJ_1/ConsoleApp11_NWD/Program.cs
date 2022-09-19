using System;

namespace ConsoleApp11_NWD
{
    class Program
    {
        // NWD

        /* 5
         * 1 4
         * 4 1
         * 12 48
         * 48 100
         * 123456 653421
         */

        static int nwd(int a, int b)
        {
            while (true)
            {
                if (a == b)
                {
                    Console.WriteLine(a);
                    return a;
                }
                if (a > b)
                    a = a - b;
                else
                    b = b - a;
            }
        }

        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for (int x = 0; x < t; x++)
            {

                string linia = Console.ReadLine();
                string[] tablica = linia.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int a = int.Parse(tablica[0]);
                int b = int.Parse(tablica[1]);
                if (a < 0 || b < 0)
                    return;
                if (a > 1000000 || b > 1000000)
                    return;
                nwd(a, b);

            }
        }
    }
}
