using System;
using static System.Console; // opcjonalny using

using CountDownTimer = System.Timers.Timer; // ALIAS

namespace Rozdzial5
{
    class Program
    {
        // METODY
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hej Ty!");
            string imie, nazwisko, fullName, inicjaly;
            imie = GetUserInput("Wprowadź imię: ");
            nazwisko = GetUserInput("Wprowadź nazwisko: ");
            fullName = GetFullName(imie, nazwisko);
            inicjaly = GetInitials(imie, nazwisko);
            Przywitanie(fullName,inicjaly);
            var NAME = GetName();
            Console.WriteLine(NAME);
            Console.WriteLine( GetFullName2("krystian", "petek") );

        }
        static string GetUserInput(string prompt)
        {   
            Console.Write(prompt);
            return Console.ReadLine().Split(" ")[0];
        }
        static string GetInitials(string imie, string nazwisko)
        {
            return $"{imie[0]}. {nazwisko[0]}.";
        } 
        static string GetFullName(string imie, string nazwisko)
        {
            return $"{imie} {nazwisko}";
        }
        static void Przywitanie(string fullName, string inicjaly)
        {
            Console.WriteLine($"Witaj {fullName}! Twoje inicjały to: {inicjaly}"); 
        }
        static (string name, string surname, int age) GetName() 
        {
            string firstNAME, lastNAME; int age;
            firstNAME = "Zastosowano";
            lastNAME = "KROTKI";
            age = 23; 
            return (firstNAME, lastNAME, age); // zwracanie wielu wartości za pomocą krotki
        }
        // REFAKTORYZACJA - służy do zmniejszania liczby powtórzeń w kodzie, bo metode można wywołać wiele razy

        // LAMBDA - metoda z ciałem w postaci wyrażenia
        static string GetFullName2 (string firstname, string lastname) => $"{firstname} {lastname}";
        
        // ALIAS USING System.Timers.Timer;
        CountDownTimer timer; // alias


    }
}
