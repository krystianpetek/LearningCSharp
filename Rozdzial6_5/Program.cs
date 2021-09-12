using System;

namespace Rozdzial6_5
{
    public class Employee
    {
        // DEKLARACJA Pól statycznych
        public static int NextId=42;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Salary { get; set; } = "Za niskie";

        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = NextId;
            NextId++;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee.NextId = 1000000;

            Employee employee1 = new Employee("Inigo", "Montoya");
            Employee employee2 = new Employee("Princes", "Buttercup");
            Console.WriteLine("{0} {1} ({2})", employee1.FirstName, employee1.LastName, employee1.Id);
            Console.WriteLine("{0} {1} ({2})", employee2.FirstName, employee2.LastName, employee2.Id);
            Console.WriteLine($"NextId = {Employee.NextId}");
        }
    }
}
