using System;
using System.Diagnostics.CodeAnalysis;

namespace Rozdzial7_2
{
    //override i new
    public class BaseClass
    {
        public void DisplayName()
        {
            Console.WriteLine("BaseClass");
        }
    }
    public class DerivedClass : BaseClass
    {
        public virtual void DisplayName()
        {
            Console.WriteLine("DerivedClass");
        }
    }
    public class SubDerivedClass : DerivedClass
    {
        public override void DisplayName()
        {
            Console.WriteLine("SubDerivedClass");
        }
    }
    public class SuperSubDerivedClass : SubDerivedClass
    {
        public new void DisplayName()
        {
            Console.WriteLine("SuperSubDerivedClass");
        }
    }


    // SEALED - zapieczętowana klasa/metoda - nie mozna jej dziedziczyć
    class A
    {
        public virtual void Method()
        { }
    }
    class B : A
    {
        public override sealed void Method()
        { }
    }
    class C : B
    {
        // nie można przesłaniać składowych z modyfikatorem SEALED
        // public override void Method() { }
    }


    // Składowa BASE
    public class Address
    {
        public string StreetAddress;
        public string City;
        public string State;
        public string Zip;
        public override string ToString()
        {
            return $"{StreetAddress + Environment.NewLine}{City}, {State} {Zip}";
        }
    }
    public class InternationalAddress : Address
    {
        public string Country;
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + Country;
        }
    }

    // Wywolywanie konstruktora klasy bazowej
    public class PdaItem
    {
        public PdaItem(string name)
        {
            Name = name;
        }
        public virtual string Name { get; set; }
    }
    public class Contact : PdaItem
    {
        public Contact(string name) : base(name)
        {
            Name = name;
        }
        public override string Name
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
            set 
            {
                string[] names = value.Split(' ');
                FirstName = names[0];
                LastName = names[1];
            }
        }
        [NotNull][DisallowNull]
        public string FirstName { get; set; }
        [NotNull][DisallowNull]
        public string LastName { get; set; }
    }
    public class Appointment :PdaItem
    {
        public Appointment(string name, string location, DateTime startDateTime, DateTime endDateTime) : base(name)
        {
            Location = location;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Location { get; set; }
    }

    class Program
    {
         static void Main(string[] args)
        {
            // override i new
            SuperSubDerivedClass superSubDerivedClass = new SuperSubDerivedClass();
            SubDerivedClass subDerivedClass = superSubDerivedClass;
            DerivedClass derivedClass = superSubDerivedClass;
            BaseClass baseClass = superSubDerivedClass;
            superSubDerivedClass.DisplayName();
            subDerivedClass.DisplayName();
            derivedClass.DisplayName();
            baseClass.DisplayName();

            InternationalAddress international = new InternationalAddress();
            Address adres = new Address();
            adres = international;
            international.Country = "Polska";
            international.City = "Koziniec";
            international.State = "Mucharz";
            international.Zip = "34-106";
            Console.WriteLine(international.ToString());

        }
    }
}
