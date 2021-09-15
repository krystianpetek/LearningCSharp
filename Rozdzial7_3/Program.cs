using System;

namespace Rozdzial7_3
{
    // KLASY ABSTRAKCYJNE
    // modyfikator abstract

    public abstract class PdaItem
    {
        public PdaItem(string name)
        {
            Name = name;
        }
        public virtual string Name { get; set; }
        public abstract string GetSummary();
    }
    public class Contact : PdaItem
    {
        public Contact(string name) : base(name)
        {
        }
        public override string Name 
        {
            get { return $"{FirstName} {LastName}"; }
            set { string[] names = value.Split(' ');
                FirstName = names[0];
                LastName = names[1];
            }
        }
        public string FirstName 
        {
            get { return _FirstName!; }
            set { _FirstName = value ?? throw new ArgumentNullException(nameof(value)); }
        }
        private string? _FirstName;
        public string LastName
        {
            get { return _LastName!; }
            set { _LastName = value ?? throw new ArgumentNullException(nameof(value)); }
        }
        private string? _LastName;
        public string? Address { get; set; }
        public override string GetSummary()
        {
            return $"FirstName: {FirstName + Environment.NewLine}"
                + $"LastName: {LastName + Environment.NewLine}"
                + $"Address: {Address + Environment.NewLine}";
        }
    }

    public class Appointment : PdaItem
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

        public override string GetSummary()
        {
            return $"Subject: {Name + Environment.NewLine}" +
                $"Start: {StartDateTime + Environment.NewLine}" +
                $"End: {EndDateTime + Environment.NewLine}" +
                $"Location: {Location + Environment.NewLine}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PdaItem[] pda = new PdaItem[3];
            Contact contact = new Contact("Sherlock Holmes")
            {
                Address = "221B Baker Street, Londyn, Anglia"
            };
            pda[0] = contact;

            Appointment appointment = new Appointment("Zawody piłkarskie", "Estadio da Machava", new DateTime(2008, 7, 19), new DateTime(2008, 7, 18));
            pda[1] = appointment;

            contact = new Contact("Hercules Poirot");
            contact.Address = "Apt 56B, Whitehaven Mansions, Sandhurst Sq, Londyn";
            pda[2] = contact;

            List(pda);

        }
        public static void List(PdaItem[] items)
        {
            foreach(var item in items)
            {
                Console.WriteLine("________");
                Console.WriteLine(item.GetSummary());
            }
        }
    }
}
