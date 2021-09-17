using System;

namespace Rozdzial8_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Contact contact = new Contact("Krystian", "Petek", "Koziniec 2", "884284782");
            var x = ((IListable)contact).CellValues;
            Console.WriteLine(x[2]);
        }
    }
    interface IListable
    {
        // Zwraca wartość każdej komórki wiersza.
        string?[] CellValues { get; }
    }
    public abstract class PdaItem
    {
        public PdaItem(string name)
        {
            Name = name;
        }
        public virtual string Name { get; set; }
    }

    public class Contact : PdaItem, IListable, IComparable
    {
        public Contact(string firstName, string lastName, string address, string phone) : base(GetName(firstName, lastName))
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Phone = phone;
        }
        public string LastName { get; }
        // ...
        public string? FirstName { get; }
        public string? Address { get; }
        public string? Phone { get; }
        public static string GetName(string firstName, string lastName)
        => $"{ firstName } { lastName }";
        
        #region IComparable Members

        public int CompareTo(object obj) => obj switch
        {
            null => 1,
            Contact contact when ReferenceEquals(this, contact) => 0,
            Contact { LastName: string lastName } when LastName.CompareTo(lastName) != 0 => LastName.CompareTo(lastName),
            Contact { FirstName: string firstName } when FirstName.CompareTo(firstName) != 0 => FirstName.CompareTo(firstName),
            Contact _ => 0,
            _ => throw new ArgumentException($"Parametr nie jest wartością typu { nameof(Contact) }",
            nameof(obj))
        };
        #endregion
        #region Składowe interfejsu IListable
        string?[] IListable.CellValues
        {
            get
            {
                return new string?[]
                {
                    FirstName,LastName,Phone,Address
                };
            }
        }
        #endregion
    }
}
