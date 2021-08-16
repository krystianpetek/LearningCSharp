using System;

namespace Rozdzial3
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = 42;
            char letter = 'A';
            float pi = 3.14f;
            int number2 = number1;

            int? number = null;
            if (number is null)
            {
                Console.WriteLine("'number' wymaga wartości i musi być różna od null");
            }
            else
            {
                Console.WriteLine($"Podwojna wartość 'number': { number * 2 }.");
            }
#nullable enable
            string? text = null;
            //Console.WriteLine(text.Length);

            Console.Write("Wprowadź tekst: ");
            var tekst = Console.ReadLine();
            var uppercase = tekst.ToUpper();
            Console.WriteLine(uppercase);

            // TYPY ANONIMOWE
            var patent1 = new { Title = "Soczewki dwuogniskowe", YearOfPublication = "1784" };
            var patent2 = new { Title = "Fonograf", YearOfPublication = "1877" };
            Console.WriteLine($"{patent1.Title} ({patent1.YearOfPublication})");
            Console.WriteLine($"{patent2.Title} ({patent2.YearOfPublication})");

            // KROTKI Wprowadzone w C# 7.0
            (string country, var capital, double gdpPerCapita) = ("Sudan Południowy", "Juba", 275.18);
            Console.WriteLine($@"Najbiedniejszym krajem w 2019 r. był {country}, {capital}: {gdpPerCapita}");
            (string Name, string Capital, double GdpPerCapita) countryInfo = ("Sudan Południowy", "Juba", 275.18);
            Console.WriteLine($@"Najbiedniejszym krajem w 2019 r. był {countryInfo.Name}, {countryInfo.Capital}: {countryInfo.GdpPerCapita}");
            var countryInfo2 = (Name: "Sudan Południowy", Capital: "Juba", GdpPerCapita: 275.18);
            Console.WriteLine($@"Najbiedniejszym krajem świata w 2019 r. był {countryInfo2.Name}, {countryInfo2.Capital}: {countryInfo2.GdpPerCapita}");

            string Acountry = "Sudan Południowy";
            string Acapital = "Juba";
            double AgdpPerCapita = 275.18;
            var AcountryInfo = (Acountry, Acapital, AgdpPerCapita);
            Console.WriteLine($@"Najbiedniejszym krajem świata w 2019 r. był {AcountryInfo.Acountry}, {AcountryInfo.Acapital}: {AcountryInfo.AgdpPerCapita}");
            var t1 = ("Indigo Montoya", 42);
            Console.WriteLine(t1.GetType() + " " + t1.Item1);

            // TABLICE
            int[] liczby = { 1, 5, 2, 4, 3 };
            Console.WriteLine(liczby[^1]); // Indeksowanie od końca tablicy ^1 wskazuje na ostatni element tablicy
            int[,] liczbyDrugiWymiar = new int[3, 3] {
                {1, 0, 2},
                {1, 2, 0},
                {1, 2, 1}
            };
            Console.WriteLine(liczbyDrugiWymiar[1, 1]);

            string[] languages = { "C#", "COBOL", "Java", "C++", "TypeScript", "Pascal", "Python", "Lisp", "JavaScript" };
            languages = new string[9];
            languages = new string[] { "C#", "COBOL", "Java", "C++", "TypeScript", "Pascal", "Python", "Lisp", "JavaScript" };
            string language = languages[4];
            // Wyświetli „TypeScript”.
            Console.WriteLine(language);
            // Pobieranie trzeciego elementu od końca (Python)..
            language = languages[^3];
            Console.WriteLine(language);
            Console.WriteLine();
            Console.WriteLine( string.Join(",",languages) );
            Console.WriteLine($@"^4..^2: { string.Join(", ", languages[^4..^2]) }"); // wypisze Pascal, Python
            Console.WriteLine($@"^3..: { string.Join(", ", languages[^3..]) }");
            Console.WriteLine($@" 3..^3: { string.Join(", ", languages[3..^3]) }");
            Console.WriteLine($@" ..^6: { string.Join(", ", languages[..^6]) }");
        }
    }
}