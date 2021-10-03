using System;

namespace Zadanie04_07
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] macierz = new int[10, 10];

            for (int i = 0; i < 10; i++) 
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j == 0)
                    {
                        macierz[i, j] = i;
                        Console.Write($" {macierz[i, j]} ");
                    }
                    else if (j == 1)
                    {
                        macierz[i, j] = i * i;
                        Console.Write($" {macierz[i, j]} ");
                    }
                    else if(i < 4 && j == 2) // DODATKOWE dla wygladu
                    {
                        macierz[i, j] = 0;
                        Console.Write($"  {macierz[i,j]} ");
                    }
                    else
                    {
                        macierz[i, j] = 0;
                        Console.Write($" {macierz[i,j]} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
