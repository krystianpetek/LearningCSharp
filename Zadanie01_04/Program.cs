using System;

namespace Zadanie01_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Wprowadź promień kuli (r): ");
            double r = double.Parse(Console.ReadLine());
            double objetosc = (r * r * r)* Math.PI * 4d/3;
            Console.Write($"Objętość kuli wynosi: {Math.Round(objetosc,2)}");
        }
    }
}
