using System;

namespace Zadanie04_09
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
            int suma = 0;
            foreach (int x in dane)
            {
                suma += x;
            }
            Console.WriteLine("Suma liczb od 1 do 100 wynosi: " + suma);
        }
    }
}
