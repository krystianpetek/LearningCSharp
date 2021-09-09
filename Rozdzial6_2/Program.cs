using System;

namespace Rozdzial6_2 // Hermetyzacja, część 2. Ukrywanie informacji
{
    public class Employee
    {
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
        
        // niezaszyfrowane hasła są tylko w celach edukacyjnych, nie zaleca się tego podejścia
        private string Password;
        private bool IsAuthenticated;
        public bool Logon(string password)
        {
            if(Password == password)
            {
                IsAuthenticated = true;
            }
            return IsAuthenticated;
        }
        public bool GetIsAuthenticated()
        {
            return IsAuthenticated;
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
                if(value == null)
                {
                    throw new ArgumentNullException("nameof(value)");
                }
                else
                {
                    value = value.Trim();
                    if(value == "")
                    {
                        throw new ArgumentException("Właściwość LastName nie może być pusta");
                    }
                    else{
                        _LastName = value;
                    }
                }
            }
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
            employee.Manager = employee;
            Console.WriteLine(employee.Manager.Title);
             
        }
    }
}
