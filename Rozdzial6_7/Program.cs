using System;

namespace Rozdzial6_7
{
    
    class ConvertUnits
    {
        // deklaracja stałego pola 
        // NIE zapisuj w stałych polach wartości, które zmieniają się w czasie.
        public const float CentimetersPerInch = 2.54F;
        public const int CupsPerGallon = 16;
    }
    class Employee
    {
        // modyfikator readonly
        public Employee(int id)
        {
            _Id = id;
        }
        public readonly int _Id;
        public int Id
        {
            get { return _Id; }
        }
        // przypisanie wartości do pola readonly jest mozliwe tylko w konstruktorze lub inicjatorze zmiennej
        // pola readonly moga mieć inne wartości w róznych instancjach, ale po deklaracji są immutable
    }

    class TicTacToeBoard
    {
        // nie mozna przypisać wartości  bo jest przeznaczona tylko do odczytu, nie zdefiniowano we właściowści {set;}
        public bool[,,] Cells { get; } = new bool[2, 3, 3];
        // public void SetCells(bool[,,] value) => Cells = new bool[2,3,3];
        
    }


    // KLASY ZAGNIEŻDZONE
    class Program
    {
        private class CommandLine
        {
            public CommandLine(string[] arguments)
            {
                for (int argumentCounter = 0; argumentCounter < arguments.Length; argumentCounter++)
                {
                    switch(argumentCounter)
                    {
                        case 0:
                            Action = arguments[0].ToLower();
                            break;
                        case 1:
                            Action = arguments[1].ToLower();
                            break;
                        case 2:
                            Action = arguments[2].ToLower();
                            break;
                        case 3:
                            Action = arguments[3].ToLower();
                            break;
                    }
                }
            }
            public string? Action { get; }
            public string? Id { get; }
            public string? FirstName { get; }
            public string? LastName { get; }
        }
        static void Main(string[] args)
        {
            CommandLine commandLine = new CommandLine(args);
            switch (commandLine.Action)
            {
                case "new":
                    Console.WriteLine("Tworzenie nowego obiektu reprezentującego pracownika.");
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

