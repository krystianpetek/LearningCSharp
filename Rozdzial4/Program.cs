using System;

namespace Rozdzial4
{
    class Program
    {
        static void Main(string[] args)
        {
            // OPERATORY

            int difference = 4 - 2;
            decimal debt = -26457079712930.80M;
            int licznik, mianownik, iloraz, reszta;
            Console.WriteLine("Wprowadź licznik: ");
            licznik = int.Parse(Console.ReadLine());
            Console.WriteLine("Wprowadź mianownik: ");
            mianownik = int.Parse(Console.ReadLine());
            iloraz = licznik / mianownik;
            reszta = licznik % mianownik;
            Console.WriteLine($"{licznik} / {mianownik} = {iloraz}, reszta {reszta}");

            short predkoscWiatru = 42;
            Console.WriteLine($"Pierwszy most Tacoma w Waszyngtonie został\nzniszczony przez wiatr wiejący z prędkością {predkoscWiatru} mil na godzinę");
        
            
        }
    }
}
