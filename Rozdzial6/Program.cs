using System;
using System.IO;

namespace Rozdzial6 // Hermetyzacja, część 1. Obiekty łączą dane z metodami
{
    public class Employee
    {
        public string FirstName;
        public string LastName;
        public string? Salary = "Za niskie";

        public string GetName()
        {
            return $"{FirstName} {LastName}";
        }

        public void SetName(string FirstName, string LastName) // Używanie słowa kluczowego this w celu uniknięcia wieloznaczności
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            Console.WriteLine($"Imię i nazwisko zmieniono na '{this.GetName()}'");
        }

        public void Save() // Przekazywanie obiektu this w wywołaniu metody
        {
            DataStorage.Store(this);
        }

        public static Employee Load(string firstName, string lastName)
        {
            Employee employee = new Employee();
            FileStream stream = new FileStream(firstName + lastName + ".dat", FileMode.Open);
            StreamReader reader = new StreamReader(stream);
            employee.FirstName = reader.ReadLine() ?? throw new InvalidOperationException("FirstName nie może być równe null");
            employee.LastName = reader.ReadLine() ?? throw new InvalidOperationException("LastName nie może być równe null");
            employee.Salary = reader.ReadLine();
            reader.Dispose();
            return employee;
        }
    }

    public class DataStorage
    {
        public static void Store(Employee employee)
        {
            FileStream stream = new FileStream(employee.FirstName + employee.LastName + ".dat", FileMode.Create);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(employee.FirstName);
            writer.WriteLine(employee.LastName);
            writer.WriteLine(employee.Salary);
            writer.Dispose(); // Zamyka obiekt typu StreamWriter i powiązany z nim strumień.
        }
    }

    internal class Program
    {
        private static void Main()
        {
            Employee employee1;
            employee1 = new Employee();
            Employee employee2 = new Employee();

            employee1.FirstName = "Inigo";
            employee1.LastName = "Montoya";
            employee1.Salary = "Za niskie";
            Console.WriteLine("{0} {1}: {2}", employee1.FirstName, employee1.LastName, employee1.Salary);
            IncreaseSalary(employee1);
            employee1.SetName("Krystian", "Petek");
            Console.WriteLine($"{employee1.GetName()}: {employee1.Salary}");
            employee1.Save();
            employee2 = Employee.Load("Krystian", "Petek");
            Console.WriteLine($"{employee2.GetName()}: {employee2.Salary}");
        }

        private static void IncreaseSalary(Employee employee)
        {
            employee.Salary = "Wystarczające, by przeżyć";
            Console.WriteLine("Zwiększanie dochodu na: " + employee.Salary);
        }
    }
}