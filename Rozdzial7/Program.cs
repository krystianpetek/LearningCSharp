using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

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
        // implicit - operator niejawnej konwersji
        // explicit - operator jawnej konwersji
        //                                  public static implicit operator UTMCoordinates(GPSCoordinates coordinates)
    }

    // ŁAŃCUCH DZIEDZICZENIA
    public class PdaItem : Object
    {
        [DisallowNull]
        private string _Name; 
        public string? Name 
        { 
            get { return _Name; } 
            set { _Name = value; } 
        }
        public DateTime LastUpdated { get; set; }
    }
    public class Appointment : PdaItem{ }
    public class Contact : PdaItem
    {
        public string Address { get; set; }
        public string Phone { get; set; }
    }
    public class Customer : Contact{ }
    
    // modyfikator private
    public class PdaItem2
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set{ _Name = value; }
        }
    }
    public class Contact2 : PdaItem2{ }

    // Modyfikator protected - składowe protected są dostępne tylko w klasach pochodnych
    
    // modyfikator sealed - tworzenie klasy zamkniętej w celu uniemożliwienia dziedziczenia
}
