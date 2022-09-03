using System;

namespace Zadanie03_17
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            Random losowanie = new Random();
            int suma = 0, min = 0, max = 0;
            int i = 0;
            do
            {
                int wylosowana = losowanie.Next(0, 100);
                suma += wylosowana;
                if (i == 0)
                    min = wylosowana;
                if (min > wylosowana)
                    min = wylosowana;
                if (max < wylosowana)
                    max = wylosowana;

                i++;
            } while (i < n);
            Console.WriteLine($"Średnia = {suma / n}");
            Console.WriteLine($"Minimum = {min}");
            Console.WriteLine($"Maksimum = {max}");
        }
    }
}
