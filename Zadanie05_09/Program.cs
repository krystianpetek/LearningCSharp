using System;

namespace Zadanie05_09
{
    class Program
    {
        static void Main(string[] args)
        {
            Kadra x = new Kadra();
            x.wczytaj1();
            x.wyswietl1();
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
    class Kadra : Osoba
    {
        string wyksztalcenie;
        string stanowisko;
        public void wczytaj1()
        {
            wczytaj();
            Console.WriteLine("Podaj wykształcenie");
            wyksztalcenie = Console.ReadLine();
            Console.WriteLine("Podaj stanowisko");
            stanowisko = Console.ReadLine();
        }
        public void wyswietl1()
        {
            wyswietl();
            Console.WriteLine("Wykształcenie: " + wyksztalcenie + ".");
            Console.WriteLine($"Stanowisko: {stanowisko}.");
            Console.WriteLine();
        }
    }
}
