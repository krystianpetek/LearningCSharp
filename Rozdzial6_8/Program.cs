using System;

namespace Rozdzial6_8
{
    // KLASY CZĘSCIOWE
    partial class Program
    {
        // Rozbicie jednej klasy na pare plików - klasa częściowa
        static void Main(string[] args)
        {
            CommandLine commandLine = new CommandLine(args);
            switch (commandLine.Action)
            {
                case "new":
                    // Tworzenie nowego obiektu reprezentującego pracownika.
                    // …
                    break;
                case "update":
                    // Aktualizowanie danych w istniejącym obiekcie reprezentującym pracownika.
                    // …
                    break;
                case "delete":
                    // Usuwanie pliku z danymi pracownika.
                    // …
                    break;
                default:
                    Console.WriteLine(
                    "Employee.exe " +
                    "new|update|delete <id> [imię] [nazwisko]");
                    break;
            }
        }
    }
}
