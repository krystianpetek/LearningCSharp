using System;

namespace Zadanie05_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix program = new Matrix();
            program.czytajDane();
            program.przetworzDane();
            program.wyswietlDane();
        }
    }
    class Matrix
    {
        int[,] macierz = new int[10, 10];
        Random losowanie = new Random();
        public void czytajDane()
        {
            for (int i = 0; i < macierz.GetLength(0); i++)
            {
                for (int j = 0; j < macierz.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        macierz[i, j] = losowanie.Next(0, 10);
                        Console.ResetColor();
                    }

                    if (i + j == 9)
                    {

                        macierz[i, j] = losowanie.Next(0, 10);
                        Console.ResetColor();
                    }
                }
            }

        }
        public void przetworzDane()
        {
            int suma = 0;
            foreach (var X in macierz)
                suma += X;
            Console.WriteLine("Suma elementów na przekątnych wynosi: " + suma);
        }
        public void wyswietlDane()
        {
            for (int i = 0; i < macierz.GetLength(0); i++)
            {
                for (int j = 0; j < macierz.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(macierz[i, j]);
                        Console.ResetColor();
                    }
                    else if (i + j == 9)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(macierz[i, j]);
                        Console.ResetColor();
                    }
                    else
                        Console.Write(macierz[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
