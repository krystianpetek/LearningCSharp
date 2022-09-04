using System;

using CountDownTimer = System.Timers.Timer; // ALIAS

namespace Rozdzial5
{
    internal class Program
    {
        // METODY

        private static void Main(string[] args)
        {
            Console.WriteLine("Hej Ty!");
            string imie, nazwisko, fullName, inicjaly;
            imie = GetUserInput("Wprowadź imię: ");
            nazwisko = GetUserInput("Wprowadź nazwisko: ");
            fullName = GetFullName(imie, nazwisko);
            inicjaly = GetInitials(imie, nazwisko);
            Przywitanie(fullName, inicjaly);
            var NAME = GetName();
            Console.WriteLine(NAME);
            Console.WriteLine(GetFullName2("krystian", "petek"));
        }

        private static string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine().Split(" ")[0];
        }

        private static string GetInitials(string imie, string nazwisko)
        {
            return $"{imie[0]}. {nazwisko[0]}.";
        }

        private static string GetFullName(string imie, string nazwisko)
        {
            return $"{imie} {nazwisko}";
        }

        private static void Przywitanie(string fullName, string inicjaly)
        {
            Console.WriteLine($"Witaj {fullName}! Twoje inicjały to: {inicjaly}");
        }

        private static (string name, string surname, int age) GetName()
        {
            string firstNAME, lastNAME; int age;
            firstNAME = "Zastosowano";
            lastNAME = "KROTKI";
            age = 23;
            return (firstNAME, lastNAME, age); // zwracanie wielu wartości za pomocą krotki
        }

        // REFAKTORYZACJA - służy do zmniejszania liczby powtórzeń w kodzie, bo metode można wywołać wiele razy

        // LAMBDA - metoda z ciałem w postaci wyrażenia
        private static string GetFullName2(string firstname, string lastname) => $"{firstname} {lastname}";

        // ALIAS USING System.Timers.Timer;
        private readonly CountDownTimer timer; // alias
    }
}