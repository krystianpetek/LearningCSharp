using System;

namespace Zadanie03_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program sumuje liczby parzyste od 1 do 100");
            int suma = 0;
            int i = 0;
            while (i <= 100)
            {
                if (i % 2 == 0)
                    suma += i;
                i++;
            };
            Console.WriteLine("Suma liczb parzystych od 1 do 100 wynosi: " + suma);
        }
    }
}
