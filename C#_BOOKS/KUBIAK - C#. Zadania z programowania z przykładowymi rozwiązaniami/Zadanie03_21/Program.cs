using System;

namespace Zadanie03_21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program wyświetla tabliczkę mnożenia dla liczb od 1 do 100 (kwadrat 10x10) || WHILE");
            Console.WriteLine();
            int liczba = 0;
            int n = 10;
            int i = 0;
            while (i < n)
            {
                int j = 0;
                while (j < n)
                {
                    liczba++;
                    Console.Write($"{liczba.ToString().PadLeft(4)}");
                    j++;
                };
                Console.WriteLine();
                Console.WriteLine();
                i++;
            };
        }
    }
}
