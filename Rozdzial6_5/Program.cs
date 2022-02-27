using System;
using System.IO;

namespace Rozdzial6_5
{
    public class Employee
    {
        // DEKLARACJA Pól statycznych
        public static int NextId = 42;

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

    // METODY STATYCZNE
    public static class DirectoryInfoExtension
    {
        public static void CopyTo(DirectoryInfo sourceDirectory, string target, SearchOption option, string searchPattern)
        {
            if (target[target.Length - 1] != Path.DirectorySeparatorChar) // jeśli na ostatniej pozycji nie ma separatora, to ma go dopisać "\"
            {
                target += Path.DirectorySeparatorChar;
            }
            if (!Directory.Exists(target)) // sprawdza czy jest folder o takiej nazwie, jesli nie to go tworzy
            {
                Directory.CreateDirectory(target);
            }
            for (int i = 0; i < searchPattern.Length; i++)
            {
                foreach (string file in Directory.GetFiles(sourceDirectory.FullName, searchPattern))
                {
                    File.Copy(file, target + Path.GetFileName(file), true);
                }
            }
            // REKURENCYJNE KOPIOWANIE PODKATALOGÓW
            if (option == SearchOption.AllDirectories)
            {
                foreach (string element in Directory.GetDirectories(sourceDirectory.FullName))
                {
                    File.Copy(element, target + Path.GetFileName(element), true);
                }
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Employee.NextId = 1000000;
            Employee employee1 = new Employee("Inigo", "Montoya");
            Employee employee2 = new Employee("Princes", "Buttercup");
            Console.WriteLine("{0} {1} ({2})", employee1.FirstName, employee1.LastName, employee1.Id);
            Console.WriteLine("{0} {1} ({2})", employee2.FirstName, employee2.LastName, employee2.Id);
            Console.WriteLine($"NextId = {Employee.NextId}");

            DirectoryInfo directory = new DirectoryInfo(".\\Source");
            directory.MoveTo(".\\Root");
            DirectoryInfoExtension.CopyTo(directory, ".\\Target", SearchOption.AllDirectories, "*");
        }
    }
}