using System;

namespace Zadanie03_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program sumuje liczby parzyste od 1 do 100");
            int suma = 0;
            int i = 0;
            do
            {
                if (i % 2 == 0)
                    suma += i;
                i++;
            } while (i <= 100);
            Console.WriteLine("Suma liczb parzystych od 1 do 100 wynosi: " + suma);
        }
    }
}
