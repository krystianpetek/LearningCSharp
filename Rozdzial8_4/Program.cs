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
            Person z = new Person("Inigo", "Montoya");
            Console.WriteLine(((IPerson)z).Name);

            PersonPublic x = new PersonPublic("Inigo", "Montoya");
            Console.WriteLine(((IPersonPublic)x).Name); // Domyślnie wszystkie składowe instancji w interfejsach są publiczne.

            PersonPrivate c = new PersonPrivate("Inigo", "Montoya");
            Console.WriteLine(((IPersonPrivate)c).Name); // private powoduje, że składową można wywoływać tylko w interfejsie z jej deklaracją

            PersonInternal v = new PersonInternal("Inigo", "Montoya");
            Console.WriteLine(((IPersonInternal)v).Name); // Internal są widoczne tylko w podzespole

            // protected internal są dostępne w bieżącym podzespole i w typach pochodnych od klasy z deklaracją danej składowej.

            PersonPrivateProtected b = new PersonPrivateProtected("Krystian", "Petek"); // private protected jest możliwy tylko w zawierającym je interfejsie i interfejsach pochodnych od niego.
            Console.WriteLine(((IPersonPrivateProtected)b).Name);

            PersonVirtual n = new PersonVirtual("Krystian", "Petek"); // virtual - Zaimplementowane składowe domyślnie są wirtualne ,możesz dodać modyfikator virtual, aby zwiększyć czytelność kodu.
            Console.WriteLine(((IPersonVirtual)n).Name);


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
            FirstName = imie;
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
        public PersonPublic(string imie, string nazwisko)
        {
            FirstName = imie;
            LastName = nazwisko;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    // MODYFIKATOR DOSTĘPU PRIVATE
    public interface IPersonPrivate
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Name => GetName();
        private string GetName() => $"{FirstName} {LastName}";
    }
    public class PersonPrivate : IPersonPrivate
    {
        public PersonPrivate(string imie, string nazwisko)
        {
            FirstName = imie;
            LastName = nazwisko;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    // MODYFIKATOR DOSTĘPU INTERNAL
    public interface IPersonInternal
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Name => GetName();
        internal string GetName() => $"{FirstName} {LastName}";
    }
    public class PersonInternal : IPersonInternal
    {
        public PersonInternal(string imie, string nazwisko)
        {
            FirstName = imie;
            LastName = nazwisko;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    // MODYFIKATOR DOSTEPU PRIVATE PROTECTED
    public interface IPersonPrivateProtected
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Name => GetName();
        private protected string GetName() => $"{FirstName} {LastName}"; // dostępne tylko w innym dziedziczącym interfejsie
    }
    public interface IEmployeePrivateProtected : IPersonPrivateProtected
    {
        int EmployeeId => GetName().GetHashCode();
    }
    public class PersonPrivateProtected : IPersonPrivateProtected
    {
        public PersonPrivateProtected(string firstName, string lastName)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    // Modyfikator VIRTUAL
    public interface IPersonVirtual
    {
        // Mofyfikator virtual jest niedozwolony dla składowych bez implementacji
        /*virtual*/
        string FirstName { get; set; }
        string LastName { get; set; }
        virtual string Name => GetName();
        private string GetName() => $"{FirstName} {LastName}";
    }
    public class PersonVirtual : IPersonVirtual
    {
        public PersonVirtual(string imie, string nazwisko)
        {
            FirstName = imie;
            LastName = nazwisko;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    // MODYFIKATOR SEALED
    // Aby uniemożliwić przesłanianie metody w klasach pochodnych, należy opatrzyć metodęmodyfikatorem sealed.
    // To gwarantuje, że w klasach pochodnych nie będzie można zmodyfikować implementacji takiej metody.
    public interface IWorkflowActivity
    {
        // Prywatna, a więc niewirtualna
        private void Start() => Console.WriteLine("IWorkflowActivity.Start()...");
 
        // Modyfikator sealed, aby uniemożliwić przesłanianie
        sealed void Run()
        {
            try
            {
                Start();
                InternalRun();
            }
            finally
            {
                Stop();
            }
        }
        protected void InternalRun();
        private void Stop() => Console.WriteLine("IWorkflowActivity.Stop()..");
    }

    // MODYFIKATOR ABSTRACT - Modyfikator abstract jest dozwolony dla składowych bez implementacji.
    public interface IPersonAbstract 
    // To słowo kluczowe nic jednak nie zmienia, ponieważ takie składowe domyślnie są abstrakcyjne
    {
        abstract string FirstName { get; set; }
        string LastName { get; set; }
        string Name => GetName();
        private string GetName() => $"{FirstName} {LastName}";
    }
}
