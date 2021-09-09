using System;

namespace Rozdzial6_3
{
    class Employee
    {
        // Inicjatory obiektów
        public Employee(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
        private string _imie;
        public string imie
        {
            get { return _imie; }
            set { _imie = value; }
        }
        private string _nazwisko;

        public string nazwisko
        {
            get { return _nazwisko; }
            set { _nazwisko = value; }
        }
        public string Title { get; set; }
        public string? Salary { get; set; }

        // inicjatory kolekcji
        // 278
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee("Inigo", "Montoya") {Title = "Maniak komputerowy", Salary = "Za niskie" };
        }
    }
}
