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

            // ROZWIAZANIE 2

            int c = int.Parse(Console.ReadLine());
            for (int a = 0; a < c; a++)
            {
                int b = int.Parse(Console.ReadLine());

                bool check = false;
                int dzielnik = 2;
                while (dzielnik != b)
                {
                    if (b == 1)
                    {
                        check = true;
                        break;
                    }
                    if (b % dzielnik == 0)
                    {
                        check = true;
                        break;
                    }
                    dzielnik++;
                }
                if (check == false)
                    Console.WriteLine("TAK");
                else
                    Console.WriteLine("NIE");
            }
        }
    }
}
