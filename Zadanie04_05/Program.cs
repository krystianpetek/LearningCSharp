using System;

namespace Zadanie04_05
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] macierz = new int[10, 10];
            int licznik = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    if (i + j == macierz.GetLength(1) - 1)
                    {
                        macierz[i, j] = 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($" {macierz[i, j]} ");
                        Console.ResetColor();

                    }
                    else
                    {
                        macierz[i, j] = 0;
                        Console.Write($" {macierz[i, j]} ");
                    }

                    licznik += macierz[i, j];
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nSuma wyróżnionych elementów w tablicy wynosi: " + licznik);
        }
    }
}
