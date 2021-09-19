using System;

namespace Rozdzial8_4
{
    // Interfejsy w C# 8.0 - nowe cechy
    public interface IListable
    {
        string?[] CellValues { get; }
        ConsoleColor[] CellColors
        {
            get
            {
                var result = new ConsoleColor[CellValues.Length];
                Array.Fill(result, DefaultColumnColor);
                return result;
            }
        }
        public static ConsoleColor DefaultColumnColor { get; set; }
    }
    public class Contact : IListable
    {
        public string[] CellValues
        {
            get
            {
                return new string[]
                {
                    FirstName, LastName, Phone, Address
                };
            }
        }
        string FirstName { get; set; }
        string LastName { get; set; }
        string? Phone { get; set; }
        string? Address { get; set; }
        // brak implementacji cellColors
    }

    public class Publication : IListable
    {
        string?[] IListable.CellValues
        {
            get
            {
                return new string?[]
                {
                    Title,Author,Year.ToString()
                };
            }
        }
        ConsoleColor[] IListable.CellColors
        {
            get
            {
                string?[] columns = ((IListable)this).CellValues;
                ConsoleColor[] result = ((IListable)this).CellColors;
                if (columns[YearIndex]?.Length != 4)
                {
                    result[YearIndex] = ConsoleColor.Red;
                }
                return result;
            }
        }
        string Title { get; set; }
        string Author { get; set; }
        string Year { get; set; }
        int YearIndex = 0;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person inigo = new Person("Inigo", "Montoya");
            Console.WriteLine(   ((IPerson)inigo).Name   );
        }
    }

    // Mechanizmy wprowadzone w C# 8.0
    // Składowe statyczne
    public interface ISampleInterface
    {
        private static string? _Field;
        public static string? Field { get => _Field; private set => _Field = value; }
        static ISampleInterface() => Field = "Nelson Mandela";
        public static string? GetField() => Field;
    }


    // Implementacje właściwości i metod instancji
    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }

        public string Name => GetName();
        public string GetName() => $"{FirstName} {LastName}";
    }
    public class Person : IPerson
    {
        public Person(string imie, string nazwisko)
        {
            FirstName= imie;
            LastName = nazwisko;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
    
    // MODYFIKATOR DOSTĘPU PUBLIC
    public interface IPersonPublic
    {
        string FirstName { get; set; }
        public string LastName { get; set; }
        string Initials => $"{FirstName[0]} {LastName[0]}";
        public string Name => GetName();
        public string GetName() => $"{FirstName} {LastName}";
    }
    public class PersonPublic : IPersonPublic
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
