using System;
using System.Collections.Generic;

namespace SZIndexery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var x = new Customer();
            Console.WriteLine(x.GetAddress(123456));
            Console.WriteLine(x.GetAddress("Nisko"));

            Console.WriteLine(x[123457].City); // indexer
        }
    }
    public class Customer
    {
        private List<Address> addresses = new List<Address>();
        public Customer()
        {
            addresses.Add(new Address { Pin = 123456, Street = "ul.Lenina", City = "Stalowa Wola", Country = "Poland" });
            addresses.Add(new Address { Pin = 123457, Street = "ul.Wyzwolenia", City = "Impactowo", Country = "Republika Impactu" });
            addresses.Add(new Address { Pin = 123466, Street = "ul.Zniewolenia", City = "Warszawa", Country = "Poland" });
            addresses.Add(new Address { Pin = 123478, Street = "ul.Pisanek", City = "Warszawa", Country = "Poland" });
            addresses.Add(new Address { Pin = 123467, Street = "ul.Samopomocy", City = "Kraków", Country = "Poland" });
            addresses.Add(new Address { Pin = 123411, Street = "ul.Jana III", City = "Stalowa Wola", Country = "Poland" });
            addresses.Add(new Address { Pin = 344667, Street = "ul.Ptaka", City = "Nisko", Country = "Poland" });
        }
        public Address GetAddress(int PinCode)
        {
            foreach (var item in addresses)
            {
                if (item.Pin == PinCode)
                    return item;
            }
            return null;

        }
        public Address GetAddress(string City)
        {
            foreach (var item in addresses)
            {
                if (item.City == City)
                    return item;
            }
            return null;

        }
        public Address this[int Pin]
        {
            get
            {
                foreach (var item in addresses)
                {
                    if (item.Pin == Pin)
                        return item;
                }
                return null;
            }
        }
        public class Address
        {
            public int Pin { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
        }
    }
}
