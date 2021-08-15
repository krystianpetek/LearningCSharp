using System;
using System.Text;

namespace Rozdzial2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(42);
            Console.WriteLine(1.6180339887498955343424335F); // FLOAT
            Console.WriteLine(1.6180339887498955343424335D); // DOUBLE
            Console.WriteLine(1.6180339887498955343424335M); // DECIMAL
            Console.WriteLine(9_814_072_356); // SEPARATOR OD C# 7.0
            Console.WriteLine(6.023E23F); //liczba Avogarda
            Console.WriteLine(0x002A); // reprezentacja DECYMALNA liczby SZESTNASTKOWEJ 
            Console.WriteLine(0x002A); // reprezentacja DECYMALNA liczby SZESTNASTKOWEJ 
            Console.WriteLine(0B101010); // reprezentacja DECYMALNA liczby BINARNEJ

            Console.WriteLine($"0x{42:X}"); // reprezentacja SZESTNASTKOWA liczby DECYMALNEJ
            Console.WriteLine(string.Format("{0:R}", 1.618033988749895));

            string option = "Help";
            int comparison = string.Compare(option, "/Help", true);
            Console.WriteLine("\a"); // alert
            Console.WriteLine("\b"); // backspace
            Console.WriteLine("\u0AAA"); // znaki
            Console.Write('\u003A'); Console.WriteLine('\u0029'); // uśmiech

            string firstName = "Krystian", lastName = "Petek";
            object[] args = new object[] { firstName, lastName };
            Console.WriteLine(string.Format("Twoje imię i nazwisko to {0} {1}.", args));
            Console.WriteLine(string.Format("Twoje imię i nazwisko to {0} {1}.", firstName, lastName));
            Console.WriteLine(string.Concat(firstName," ", lastName));
            string username = "uzytkownik";
            username = username.Trim("uzyt".ToCharArray());
            Console.WriteLine(username);
            // https://docs.microsoft.com/en-us/dotnet/standard/base-types/composite-formatting STRING.FORMAT

            Console.Write($"Witaj, świecie{Environment.NewLine}");

            string palindrom;
            Console.Write("Wprowadz palindrom: ");
            palindrom = Console.ReadLine();
            palindrom = palindrom.ToUpper();
            Console.WriteLine($"Liczba znaków w palindromie \"{palindrom}\" to {palindrom.Length}");

            StringBuilder ciag = new StringBuilder();
            ciag.Append("StringBuilder");
            ciag.Remove(1, 5);
            Console.WriteLine(ciag);

            int? wiek = null; // modyfikator ?(PYTAJNIK) daje możliwość przypisania do INT wartości NULL
            string imie = null;

            long longNumber = 50918309109;
            int intNumber = (int)longNumber;

            int n = int.MaxValue;
            n = n + 1; // przepełnienie int'a
            Console.WriteLine(n);

            //checked // kontrolowany blok kodu lub niekontrolowany blok to unchecked
            //{
            //    int m = int.MaxValue;
            //    m = m + 1;
            //    Console.WriteLine(m);
            //}

            string text = "9,11E-31";
            float kgElectronMass = float.Parse(text); // konwersja stringa na float
            Console.WriteLine((double)kgElectronMass);

            string tekst = "261,626";
            double tekstDouble = Convert.ToDouble(tekst);

            bool boolean = true;
            text = boolean.ToString();
            Console.WriteLine(text);

            //double number; // można deklarować zmienną w out! od C# 7.0
            string input;
            Console.Write("Wprowadź liczbę: ");
            input = Console.ReadLine();

            if (double.TryParse(input, out double number))
            {
                Console.WriteLine($"Wprowadzony tekst został poprawnie przekształcony na liczbę {number}.");
            }
            else
            {
                Console.WriteLine("Wprowadzony tekst nie jest poprawną liczbą.");
            }
        }
    }
}
