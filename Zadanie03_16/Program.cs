using System;

namespace Zadanie03_16
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            Random losowanie = new Random();
            int suma = 0, min = 0, max = 0;
            for (int i = 0; i < n; i++)
            {
                int wylosowana = losowanie.Next(0, 100);
                suma += wylosowana;
                if(i==0)
                    min = wylosowana;
                if (min > wylosowana)
                    min = wylosowana;
                if (max < wylosowana)
                    max = wylosowana;
            }
            Console.WriteLine($"Średnia = {suma/n}");
            Console.WriteLine($"Minimum = {min}");
            Console.WriteLine($"Maksimum = {max}");
        }
    }
}
