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
        private string LastName;
        public string GetLastName()
        {
            return LastName;
        }
        public void SetLastName(string newLastName)
        {
            if(newLastName != null && newLastName != "")
            {
                LastName = newLastName;
            }
        }
        public string? Salary;
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
        private string _firstNAME;
        public string firstNAME
        {
            get // odpowiada metodzie GetFirstName
            {
                return _firstNAME;
            }
            set // odpowiada metodzie SetFirstName
            {
                _firstNAME = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.SetFirstName("Inigo");
            employee.SetLastName("Montoya");
            // employee.Password - pole Password jest prywatne, dlatego nie ma do niego dostępu z poza klasy
            employee.firstNAME = "Inigo";
            Console.WriteLine(employee.firstNAME);
        }
    }
}
