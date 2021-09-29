using System;

namespace Zadanie03_15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program sumuje liczby nieparzyste od 1 do 100");
            int suma = 0;
            int i = 0;
            while (i <= 100)
            {
                if (!(i % 2 == 0))
                    suma += i;
                i++;
            };
            Console.WriteLine("Suma liczb nieparzystych od 1 do 100 wynosi: " + suma);
        }
    }
}
