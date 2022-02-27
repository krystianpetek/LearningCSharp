using System;

namespace Rozdzial8
{
    // interfejs w porównaniu do rzeczywistości mozna określić że jest to gniazdo elektryczne
    // to jak prąd dociera do gniazda jest szczegółem implementacji
    // Dla urządzenia nie jest ważne, w jaki sposób szczegóły implementacji prowadzą do dostarczenia prądu do gniazdka.Urządzenie ma tylko zapewniać odpowiednią wtyczkę.

    internal interface IFileCompression
    {
        void Compress(string targetFileName, string[] fileList);

        void Uncompress(string compressFileName, string expandDirectoryName);
    }

    // polimorfizm oparty na interface'ach
    internal interface IListable
    {
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

    internal class Contact : PdaItem, IListable
    {
        public Contact(string firstName, string lastName, string address, string phone) : base(GetName(firstName, lastName))
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Phone = phone;
        }

        public string LastName { get; }
        public string? FirstName { get; }
        public string? Address { get; }
        public string? Phone { get; }

        public static string GetName(string firstName, string lastName) => $"{firstName} {lastName}";

        public string[] CellValues
        {
            get
            {
                return new string?[]
                {
                        FirstName.PadRight(10), LastName.PadRight(10), Phone.PadRight(15), Address.PadRight(15)
                };
            }
        }

        public static string[] Headers
        {
            get
            {
                return new string[]
                {
                        "Imie".PadRight(11), "Nazwisko".PadRight(11),"Telefon".PadRight(16), "Adres".PadRight(15)
                };
            }
        }
    }

    internal class Publication : IListable
    {
        public string Title { get; }
        public string Author { get; }
        public string Year { get; }

        public Publication(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year.ToString();
        }

        public string[] CellValues
        {
            get
            {
                return new string[]
                {
                    Title.PadRight(50), Author.PadRight(20), Year.ToString().PadRight(20)
                };
            }
        }

        public static string[] Headers
        {
            get
            {
                return new string[] { "Tytuł".PadRight(51), "Autor".PadRight(21), "Rok".PadRight(21) };
            }
        }
    }

    internal class ConsoleListControl
    {
        public static void List(string[] headers, IListable[] items)
        {
            int[] columnWidths = DisplayHeaders(headers);
            for (int count = 0; count < items.Length; count++)
            {
                string?[] values = items[count].CellValues;
                DisplayItemRow(columnWidths, values);
            }
            Console.WriteLine();
        }

        private static int[] DisplayHeaders(string[] headers)
        {
            int[] wyjscie = new int[headers.Length];
            int licznik = 0;
            while (true)
            {
                wyjscie[licznik] = headers[licznik].Length;
                licznik++;
                if (licznik == headers.Length)
                    break;
            }
            foreach (var x in headers)
                Console.Write(x);

            return wyjscie;
        }

        private static void DisplayItemRow(int[] columnWidths, string?[] values)
        {
            Console.WriteLine();
            foreach (var x in values)
                Console.Write(x + " ");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Contact[] contacts = new Contact[]
            {
                    new Contact("Jan", "Kowal", "ul. Budowlanych 12/13, Opole 45-287", "123-123-1234"),
                    new Contact("Andrzej", "Litwin", "ul. Krótka 1/23, 30-037 Kraków", "555-123-4567"),
                    new Contact("Maria", "Harbiel", "ul. Liliowa 7, 25-129 Kępno", "444-123-4567"),
                    new Contact("Janusz", "Stocki", "ul. Opolska 5/7, 43-290 Wrocław", "222-987-6543"),
                    new Contact("Patrycja", "Wielgosz", "ul. Kościuszki 321, 28-092 Sochaczew", "123-456-7890"),
                    new Contact("Janina", "Frątczak", "ul. Majowa 9/18, 01-154 Warszawa", "333-345-6789")
            };
            ConsoleListControl.List(Contact.Headers, contacts);
            Console.WriteLine();
            Publication[] publications = new Publication[]
            {
                new Publication("Koniec z nędzą. Zadanie dla naszego pokolenia", "Jeffrey Sachs", 2006),
                new Publication("Ortodoksja", "G.K. Chesterton", 1908),
                new Publication("Autostopem przez galaktykę","Douglas Adams",1979)
            };
            ConsoleListControl.List(Publication.Headers, publications);
        }
    }
}