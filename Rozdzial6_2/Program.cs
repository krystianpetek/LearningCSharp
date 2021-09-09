using System;

namespace Rozdzial6_2 // Hermetyzacja, część 2. Ukrywanie informacji
{
    public class Employee
    {
        // niezaszyfrowane hasła są tylko w celach edukacyjnych, nie zaleca się tego podejścia
        private string Password;
        private bool IsAuthenticated;
        public bool Logon(string password)
        {
            if (Password == password)
            {
                IsAuthenticated = true;
            }
            return IsAuthenticated;
        }
        public bool GetIsAuthenticated()
        {
            return IsAuthenticated;
        }


        private string FirstName;
        public string GetFirstName() // GETTER dla FirstName
        {
            return FirstName;
        }

        public void SetFirstName(string newFirstName) // SETTER dla FirstName
        {
            if (newFirstName != null && newFirstName != "")
                FirstName = newFirstName;
        }

        // Składnia tworzenia własciwości
        private string _LastName;
        public string LastName
        {
            get // odpowiada metodzie GetFirstName
            {
                return _LastName;
            }
            set // odpowiada metodzie SetFirstName
            {
                _LastName = value;
            }
        }

        // definiowanie własności za pomocą wyrażenia lambda
        public string lastNAME
        {
            get => _LastName;
            set => _LastName = value;
        }
        public string? Title { get; set; } // Automatyczne implementowanie własności
        public Employee? Manager { get; set; }
        public string? Salary { get; set; } = "Za niskie";
        //Ogólna zasada jest taka, że metody powinny reprezentować operacje, a właściwości — dane.
        public void Initialize(string newFirstName, string newLastName)
        {
            FirstName = newFirstName;
            LastName = newLastName;
        }
        public string LASTNAME
        {
            get => _LastName;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    value = value.Trim();
                    if (value == "")
                    {
                        throw new ArgumentException("Właściwość LastName nie może być pusta.", nameof(value));
                    }
                    else {
                        _LastName = value;
                    }
                }
            }
        }
        public bool[,,] cells { get; } = new bool[2, 3, 3]; // automatyczne implementowanie wartości tylko do odczytu, bez settera

        // Właściwości obliczane
        public string Name
        {
            get
            {
                return $"{FirstName} {_LastName}";
            }
            set
            {
                string[] names;
                names = value.Split(' ');
                if (names.Length == 2)
                {
                    FirstName = names[0];
                    _LastName = names[1];
                }
                else
                {
                    throw new ArgumentException($"Przypisana wartość {value} jest nieprawidłowa", nameof(value));
                }
            }
        }

        // KONSTRUKTOR - deklaracja
        public Employee(string podajImie, string podajNazwisko)
        {
            imie = podajImie;
            nazwisko = podajNazwisko;
        }
        public Employee()
        {

        }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string zarobki { get; set; } = "Za niskie";
        public override string ToString()
        {
            return $"{imie} {nazwisko}: {zarobki}";
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            Employee employee2 = new Employee();
            employee.SetFirstName("Inigo");
            // employee.Password - pole Password jest prywatne, dlatego nie ma do niego dostępu z poza klasy
            employee.LastName = "Montoya";
            Console.WriteLine(employee.LastName);
            employee.lastNAME = "Petek";
            Console.WriteLine(employee.lastNAME);
            employee2.Title = "Maniak komputerowy";
            employee.Manager = employee2;
            Console.WriteLine(employee.Manager.Title);
            Console.WriteLine(employee.LASTNAME);

            Console.WriteLine();
            employee.Name = "Imię Nazwisko";
            Console.WriteLine(employee.Name);

            // konstruktor
            Employee pracownik = new Employee("krystian", "petek");
            Console.WriteLine(pracownik.ToString());
        }
    }
}
