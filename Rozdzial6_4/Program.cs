using System;

namespace Rozdzial6_4
{
    //  CENTRALIZOWANIE INICJONOWANIA
    public class Employee
    {
        private int Id { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        public string Salary { get; set; }

        // FirstName i LastName są ustawiane w metodzie Initialize()
        public Employee(string firstName, string lastName)
        {
            int id = 0;
            Initialize(id, firstName, lastName);
        }

        public Employee(int id, string firstName, string lastName)
        {
            Initialize(id, firstName, lastName);
        }

        public Employee(int id)
        {
            string firstName = null;
            string lastName = null;
            Initialize(id, firstName, lastName);
        }

        private void Initialize(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        private string? _Name;

        public string Name
        {
            get => _Name!; // operator braku wartości null
            set => _Name = value ?? throw new ArgumentNullException(nameof(value)); // ?? chroni przed przypisaniem nulla
        }

        public Employee(string Name)
        {
            this.Name = Name;
        }

        //Automatycznie implementowane właściwości typu referencyjnego tylko do odczytu
        public string NAME { get; }

        public Employee(string name, bool x) // bool jest nieistotny, tylko miałem duplikat
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        // DEKONSTRUKTORY
        public void Deconstruct(out int id, out string firstName, out string lastName, out string salary)
        {
            (id, firstName, lastName, salary) = (Id, FirstName, LastName, Salary);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Employee employee;
            employee = new Employee("Inigo", "Montoya");
            employee.Salary = "Za niskie";
            employee.Deconstruct(out _, out string firstName, out string lastName, out string salary);
            Console.WriteLine($"{firstName} {lastName}: {salary}");
        }
    }
}