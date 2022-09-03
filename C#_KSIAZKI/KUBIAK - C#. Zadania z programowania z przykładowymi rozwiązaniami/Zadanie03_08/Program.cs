using System;

namespace Zadanie03_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program sumuje liczby od 1 do 100");
            int suma = 0;
            int i = 0;
            do
            {
                suma += i;
                i++;
            } while (i <= 100);
            Console.WriteLine("Suma liczb od 1 do 100 wynosi: " + suma);
        }
    }
}
