using System;

namespace MARBLES___Marbles
{
    internal class Program
    {
        public static void Main()
        {
            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                Console.WriteLine(Funkcja());
            }
        }
        public static ulong Funkcja()
        {
            ulong wynik = 1;
            var linia = Console.ReadLine().Split(" ");
            ulong n = ulong.Parse(linia[0]);
            ulong k = ulong.Parse(linia[1]);

            if (n - k < (k - 1))
            {
                k = n - k + 1;
            }

            if (k == 1)
                return 1;

            else
            {
                for (ulong x = 1; x <= k - 1; x++)
                {
                    wynik = wynik * (n - x) / x;
                }
            }
            return wynik;
        }
    }
}
