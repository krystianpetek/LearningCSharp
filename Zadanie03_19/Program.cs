using System;

namespace Zadanie03_19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program wyświetla tabliczkę mnożenia dla liczb od 1 do 100 (kwadrat 10x10) || FOR ");
            Console.WriteLine();
            int liczba = 0;
            int n = 10;
            for (int i = 0; i < n; i++)
            {
                for(int j = 0;j<n;j++)
                {
                liczba++;
                    Console.Write($"{liczba.ToString().PadLeft(4)}");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
