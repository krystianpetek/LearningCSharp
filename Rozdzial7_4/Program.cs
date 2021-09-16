using System;
using System.IO;

namespace Rozdzial7_4
{
    // POLIMORFIZM
    class Program
    {
        const int Action = 0;
        const int FileName = 1;
        public const string DataFile = "data.dat";

        // dopasowanie do wzorca za pomocą operatora is
        public static void Save(object data)
        {
            if (data is string)
            {
                string text = (string)data;
                if (text.Length > 0)
                {
                    //data = Encrypt(text);
                    // jesli obiekt jest typu string to kod szyfruje dane
                }
            }
            else if (data is null)
            {
                //
            }
            //
        }

        public static void Main(params string[] args)
        {
            string a = "a";
            string b = "a";
            string c = "c";
            string d = c;
            Console.WriteLine(ReferenceEquals(a, b));
            Console.WriteLine(ReferenceEquals(c, d));
            // dopasowywanie wzorca krotek za pomoca operatora IS

            if ((args.Length, args[Action]) is (1, "show"))
            {
                Console.WriteLine(File.ReadAllText(DataFile));
            }
            else if ((args.Length, args[Action].ToLower(), args[FileName]) is (2, "encrypt", string fileName))
            {
                string data = File.ReadAllText(DataFile);
                //File.WriteAllText(fileName, Encrypt(data).ToString());
            }

            // dopasowanie pozycyjne
            Person person = new Person("Inigo", "Montoya");
            if(person is (string firstName, string lastName))
                Console.WriteLine($"{firstName} {lastName}");

            // dopasowanie właściwości
            Person person2 = new Person("", "");
            if (person2 is { FirstName: string firstName2, LastName: string lastName2 })
            {
                Console.WriteLine($"{firstName2} {lastName2}");
            }
        }
    }
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public void Deconstruct(out string firstName, out string lastName) => (firstName, lastName) = (FirstName, LastName); 
    }
}
