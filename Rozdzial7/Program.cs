using System;
using System.Diagnostics.CodeAnalysis;

namespace Rozdzial7
{
    class Program
    {
        static void Main(string[] args)
        {
            //RZUTOWANIE MIEDZY TYPAMI BAZOWYMI I POCHODNYMI
            Contact contact = new Contact();
            contact.Name = "Inigo Montoya";
            // Wartości typów pochodnych można niejawnie przekształcać na typy bazowe.
            PdaItem item = contact;
            // Typy bazowe trzeba jawnie rzutować na typy pochodne.
            contact = (Contact)item;
            // C# umozliwia stosowanie operatora rzutowania nawet gdy wykonywane jest rzutowanie niejawne
            item = (PdaItem)contact;
            // lub jeśli nie jest konieczne
            contact = (Contact)contact;
        }
    }

    // ŁAŃCUCH DZIEDZICZENIA
    public class PdaItem : Object
    {
        [DisallowNull]
        public string? Name { get; set; }
        public DateTime LastUpdated { get; set; }
    }
    public class Appointment : PdaItem{ }
    public class Contact : PdaItem
    {
        public string Address { get; set; }
        public string Phone { get; set; }
    }
    public class Customer : Contact{ }
    
}
