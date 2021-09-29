using System;

namespace Zadanie03_06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program wyświetla liczby całkowite od 1 do 20");
            int i = 0;
            while (i <= 20)
            {
                if (i == 20)
                {
                    Console.Write($"{i}.");
                }
                else
                {
                    Console.Write($"{i}, ");
                }
                i++;
            }
        }
    }
}
