using System;

namespace Zadanie03_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program sumuje liczby parzyste od 1 do 100");
            int suma = 0;
            for (int i = 0; i <= 100; i++)
            {
                if(i % 2 == 0)
                suma += i;
            }
            Console.WriteLine("Suma liczb parzystych od 1 do 100 wynosi: " + suma);
        }
    }
}
