using System;

namespace ConsoleApp12_tablice
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            if (t > 100)
                throw new ArgumentException("error");

            for (int x = 0; x < t; x++)
            {
                string wejscie = Console.ReadLine();
                string[] n = wejscie.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int nDlugosc = int.Parse(n[0]);
                Array.Reverse(n);
                for(int i = 0;i<nDlugosc;i++)
                    Console.Write($"{n[i]} ");

                Console.WriteLine();
            }
        }
    }
}
