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
            if(number is null)
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
       
            //112
        
        }
    }
}
