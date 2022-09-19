using System;

namespace Zadanie05_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Prostokat prosto = new Prostokat();
            prosto.czytaj_date();
            prosto.przetworz_dane();
            prosto.wyswietl_dane();
        }

    }
    class Prostokat
    {

        double a, b, oblicz_pole;

        public void czytaj_date()
        {
            Console.WriteLine("Program oblicza pole prostokąta");
            Console.Write("Podaj bok a: ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Podaj bok b: ");
            b = double.Parse(Console.ReadLine());
        }
        public void przetworz_dane()
        {
            oblicz_pole = a * b;

        }
        public void wyswietl_dane()
        {
            Console.WriteLine($"Pole prostokąta o boku a = {a} i boku b = {b}");
            Console.Write($"Wynik: {oblicz_pole}");

        }
    }
}
