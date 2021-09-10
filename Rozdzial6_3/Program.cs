using System;
using System.Collections.Generic;

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
        public Employee(int id) => Id = id; // od c# 7.0 - implementacja konstruktorów jako składowych z ciałem w postaci wyrazenia
        public int Id
        {
            get => Id;
            private set
            {
                // wyszukiwanie imienia i nazwiska pracownika o podanym id
            }
        }
        public Employee(int id, string imie, string nazwisko) : this(imie, nazwisko) // wywołanie innego konstruktora w innym konstruktorze
        {
            Id = id;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee("Inigo", "Montoya") { Title = "Maniak komputerowy", Salary = "Za niskie" };

            // inicjatory kolekcji
            List<Employee> listaPracownikow = new List<Employee>()
            {
                new Employee("Krystian", "Petek"),
                new Employee("Patrycja", "Petek")
            };
            listaPracownikow.Add(employee1);

            foreach(var pracownik in listaPracownikow)
                Console.Write(pracownik.imie+" "+pracownik.nazwisko+"\n");


        }
    }
}
