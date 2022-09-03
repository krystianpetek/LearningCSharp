using System;

namespace Zadanie05_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Osoba osoba = new Osoba();
            osoba.wczytaj();
            osoba.wyswietl();
        }
    }
    class Osoba
    {
        string nazwisko, imie, ulica, kod, miasto;
        public void wczytaj()
        {
            Console.WriteLine("Podaj nazwisko: ");
            nazwisko = Console.ReadLine();
            Console.WriteLine("Podaj imie: ");
            imie = Console.ReadLine();
            Console.WriteLine("Podaj ulicę: ");
            ulica = Console.ReadLine();
            Console.WriteLine("Podaj kod pocztowy: ");
            kod = Console.ReadLine();
            Console.WriteLine("Podaj miasto: ");
            miasto = Console.ReadLine();
            Console.WriteLine();
        }
        public void wyswietl()
        {
            Console.WriteLine("Wyświetlanie danych");
            Console.WriteLine("===================");
            Console.WriteLine($"Nazwisko: {nazwisko}");
            Console.WriteLine($"Imię: {imie}");
            Console.WriteLine($"Ulica: {ulica}");
            Console.WriteLine($"Kod: {kod}");
            Console.WriteLine($"Miasto: {miasto}");
        }
    }
}
