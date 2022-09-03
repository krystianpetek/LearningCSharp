using System;

namespace AE00___Rectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            int linia = int.Parse(Console.ReadLine());
            
            var wynik = Sprawdz(linia);
            Console.WriteLine(wynik);
            
        }
        static int Sprawdz(int n)
        {
            int count = 0;

            for (int x = 1; x <= n; x++)
            {
                for (int y = x; y <= n; y++)
                    if (x * y <= n)
                        count++;
            }
            return count;
        }
    }
}
