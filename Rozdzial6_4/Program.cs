using System;

namespace Rozdzial6_4
{
    //  CENTRALIZOWANIE INICJONOWANIA
    public class Employee
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Salary { get; set; }
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
            Id = id;
            Initialize(id, firstName, lastName);
        }
        private void Initialize(int id,string firstName, string lastName)
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
        public Employee (string name, bool x) // bool jest nieistotny, tylko miałem duplikat
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        //287
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
