using System;

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

        // REFAKTORYZACJA - służy do zmniejszania liczby powtórzeń w kodzie, bo metode można wywołać wiele razy
        
    }
}
