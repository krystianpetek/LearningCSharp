using System;

namespace Zadanie03_20
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program wyświetla tabliczkę mnożenia dla liczb od 1 do 100 (kwadrat 10x10) || DO WHILE");
            Console.WriteLine();
            int liczba = 0;
            int n = 10;
            int i = 0;
            do
            {
                int j = 0;
                do
                {
                    liczba++;
                    Console.Write($"{liczba.ToString().PadLeft(4)}");
                    j++;
                } while (j < n);
                Console.WriteLine();
                Console.WriteLine();
                i++;
            } while (i < n);
        }
    }
}
