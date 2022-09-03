using System;

namespace Zadanie04_15
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            int[,] macierzA = new int[n, n];
            for (int i = 0; i < macierzA.GetLength(0); i++)
            {
                for (int j = 0; j < macierzA.GetLength(1); j++)
                {
                    macierzA[i, j] = 1;
                }
            }

            int[,] macierzB = new int[n, n];
            for (int i = 0; i < macierzB.GetLength(0); i++)
            {
                for (int j = 0; j < macierzB.GetLength(1); j++)
                {
                    macierzB[i, j] = 2;
                }
            }

            int[,] macierzC = new int[n, n];
            for (int i = 0; i < macierzC.GetLength(0); i++)
            {
                for (int j = 0; j < macierzC.GetLength(1); j++)
                {
                    for (int k = 0; k < macierzC.GetLength(0); k++)
                    {
                        macierzC[i, j] += macierzA[i, k] * macierzB[j, k];
                    }
                    Console.Write($" {macierzC[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
