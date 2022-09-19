using System;

namespace Rozdzial3
{
    internal class Program
    {
        private static void Main(string[] args)
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
                Console.WriteLine($"Podwojna wartość 'number': {number * 2}.");
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
            Console.WriteLine(string.Join(",", languages));
            Console.WriteLine($@"^4..^2: {string.Join(", ", languages[^4..^2])}"); // wypisze Pascal, Python
            Console.WriteLine($@"^3..: {string.Join(", ", languages[^3..])}");
            Console.WriteLine($@" 3..^3: {string.Join(", ", languages[3..^3])}");
            Console.WriteLine($@" ..^6: {string.Join(", ", languages[..^6])}");
            Console.WriteLine(languages[^languages.Length]); // pierwszy element tablicy

            //Zmiana pozycji danych w tablicy
            language = languages[3];
            languages[3] = languages[2];
            languages[2] = language;

            // TABLICA trójwymiarowa
            bool[,,] cells;
            cells = new bool[2, 3, 3]
            {
                {
                    { true, false, false},
                    { true, false, false},
                    { true, false, true}
                },
{
                    { false, false, true},
                    { false, true, false},
                    { false, true, true}
                }
            };

            // TABLICA POSTRZĘPIONA = tablica tablic
            int[][] jaggedTab = // [] - akcesor tablicy
            {
                new int[] {1,0,2,0},
                new int[] {1,2,0},
                new int[] {1,2},
                new int[] {1}
            };

            // Zmiana wartości w tablicy
            int[,] komorki =
            {
                {1, 0, 2},
                {0, 2, 0},
                {1, 2, 1}
            };
            komorki[1, 0] = 1;

            int[][] komorkiDwuWymiarowe =
            {
                new int[]{1, 0, 2},
                new int[]{0, 2, 0},
                new int[]{1, 2, 1}
            };
            komorkiDwuWymiarowe[1][0] = 1;

            Console.WriteLine($"Liczba języków w tablicy to {languages.Length}.");

            // ROZWAŻ  sprawdzanie wartości null przed dostępem do tablicy, zamiast przyjmować, że instancja tablicy istnieje.
            // ROZWAŻ sprawdzanie długości tablicy przed użyciem indeksu, zamiast zakładać, że ma ona określoną wielkość.
            // ROZWAŻ używanie w wersjach C# 8.0 i nowszych operatora indeksowania od końca tablicy(^) zamiast wyrażenia Length – 1

            // .. - operator przedziału Dostępny od C# 8.0
            Console.WriteLine($@" ..: {string.Join(", ", languages[..])} ");

            // INDEX and RANGE
            Index indeks = 3;
            Range przedzial = ..; // == 0..^0

            // METODY ARRAY
            Array.Sort(languages);
            string searchString = "C#";
            int indexSearch = Array.BinarySearch(languages, searchString); // przechowuje wartość indeksu gdzie wystepuje szukana fraza
            Console.WriteLine(indexSearch);
            Console.WriteLine($"Język przyszłości to {searchString} można go znaleźć na pozycji o indeksie {indexSearch}.");

            Console.WriteLine();
            Console.WriteLine($"{"Pierwszy element",-20}\t{"Ostatni element",-20}");
            Console.WriteLine($"{"----------------",-20}\t{"----------------",-20}");
            Console.WriteLine($"{languages[0],-20}\t{languages[^1],-20}"); Array.Reverse(languages);
            Console.WriteLine($"{languages[0],-20}\t{languages[^1],-20}");

            Array.Clear(languages, 0, languages.Length);
            Console.WriteLine($"{languages[0],-20}\t{languages[^1],-20}");
            Console.WriteLine($"Po wywołaniu Clear wielkość tablicy to: {languages.Length}");

            cells = new bool[2, 3, 3];
            Console.WriteLine(cells.GetLength(0)); // ilość elementów w 1(0) wymiarze tablicy wielowymiarowej
            Console.WriteLine(cells.Rank); // ilość wymiarów
            Console.WriteLine(cells.Length); // ilość elementów we wszystkich wymiarach

            // ODWRACANIE ZNAKÓW W ŁANCUCHU
            //A to kanapa pana Kota.
            string reverse, palindrome;
            char[] temp;
            Console.Write("Wprowadź palindrom: ");
            palindrome = Console.ReadLine();
            reverse = palindrome.Replace(" ", "");
            reverse = reverse.ToLower();
            temp = reverse.ToCharArray();
            Array.Reverse(temp);
            if (reverse == new string(temp))
                Console.WriteLine($"\"{palindrome}\" jest palindromem.");
            else
                Console.WriteLine($"\"{palindrome}\" NIE jest palindromem.");
        }
    }
}