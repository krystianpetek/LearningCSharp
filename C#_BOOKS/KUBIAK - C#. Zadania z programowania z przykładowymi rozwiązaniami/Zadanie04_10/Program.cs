using System;

namespace Zadanie04_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dane = new int[100];
            for (int i = 0; i < 100; i++)
            {
                dane[i] = i + 1;
            }
            int sumaParzyste = 0;
            int sumaNieparzyste = 0;
            foreach (int x in dane)
            {
                if (x % 2 == 0) // parzyste
                    sumaParzyste += x;
                else
                    sumaNieparzyste += x;
            }
            Console.WriteLine("Suma liczb parzystych od 1 do 100 wynosi: " + sumaParzyste);
            Console.WriteLine("Suma liczb nieparzystych od 1 do 100 wynosi: " + sumaNieparzyste);
        }
    }
}
