﻿using System;

namespace Rozdzial7
{
    // implicit - operator niejawnej konwersji
    // explicit - operator jawnej konwersji
    //                                  public static implicit operator UTMCoordinates(GPSCoordinates coordinates)

    // ŁAŃCUCH DZIEDZICZENIA
    public class PdaItem : Object
    {
        private string _Name;

        public string? Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public DateTime LastUpdated { get; set; }
    }

    public class Appointment : PdaItem
    { }

    public class Contact : PdaItem
    {
        public string Address { get; set; }
        public string Phone { get; set; }
    }

    public class Customer : Contact
    { }

    // modyfikator private
    public class PrivatePdaItem
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }

    public class PrivateContact : PrivatePdaItem
    { }

    // Modyfikator protected - składowe protected są dostępne tylko w klasach pochodnych

    // modyfikator sealed - tworzenie klasy zamkniętej w celu uniemożliwienia dziedziczenia
    public sealed class CommandLineParser
    { }

    public sealed class DerivedCommandLineParser // : CommandLineParser - błąd, nie można tworzyć klas pochodnych od zamkniętych
    { }

    // PRZESŁANIANIE SKŁADOWYCH Z KLAS BAZOWYCH
    // modyfikator virtual - aby przesłonić właściwości i metody trzeba zmodyfikować klasę bazową i pochodną
    public class VirtualPdaItem
    {
        public virtual string Name { get; set; }
    }

    public class VirtualContact : VirtualPdaItem
    {
        public override string Name
        {
            get { return $"{FirstName} {LastName}"; }
            set
            {
                string[] names = value.Split(' ');
                FirstName = names[0];
                LastName = names[1];
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    internal class Program
    {
        private static void Main(string[] args)
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
#pragma warning disable CS1717 // Dyrektywa #warning
            contact = (Contact)contact;
#pragma warning restore CS1717 // Dyrektywa #warning

            // virtual
            VirtualPdaItem virtualpdaitem;
            VirtualContact virtualcontact = new VirtualContact();
            virtualpdaitem = virtualcontact;
            virtualpdaitem.Name = "Inigo Montoya";
            Console.WriteLine($"{virtualcontact.FirstName} {virtualcontact.LastName}");
        }
    }
}