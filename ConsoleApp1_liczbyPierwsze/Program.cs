using System;

namespace ConsoleApp1_liczbyPierwsze
{
    class Program
    {
        static void Main(string[] args)
        {
            // LICZBY PIERWSZE

            /* DANE WEJSCIOWE:
             * 3
             * 11
             * 1
             * 4
             */

            int iloscLiczb = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < iloscLiczb; i++)
            {
                int liczba = Convert.ToInt32(Console.ReadLine());
                if (liczba == 1)
                {
                    Console.WriteLine("NIE");
                    continue;
                }
                if (liczba < 1) return;
                if (liczba > 10000) return;

                int wystapienie = 0;
                for (int j = 1; j < liczba; j++)
                {
                    if (liczba % j == 0)
                    {
                        wystapienie += 1;
                    }
                }
                if (wystapienie > 1)
                {
                    Console.WriteLine("NIE");
                }
                else
                {
                    Console.WriteLine("TAK");
                }
            }
        }
    }
}
