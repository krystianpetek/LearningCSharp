using System;

namespace Zadanie03_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program sumuje liczby od 1 do 100");
            int suma = 0;
            for(int i = 0;i<=100;i++)
            {
                suma += i;
            }
            Console.WriteLine("Suma liczb od 1 do 100 wynosi: "+suma);
        }
    }
}
