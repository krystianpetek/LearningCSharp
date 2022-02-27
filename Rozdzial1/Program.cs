using System;

namespace Rozdzial1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // PODSTAWY
            Console.WriteLine("Witaj! Nazywam się Krystian Petek.");

            // ZAAWANSOWANE

            // SLOWO KLUCZOWE JAKO IDENTYFIKATOR
            int @int = 2;
            @int = 14;
            double @return = 5.4;
            Console.WriteLine(@int + @return);

            Console.WriteLine(Environment.CommandLine);

            Console.WriteLine("Góra"); Console.WriteLine("Dół");

            string max;
            max = "Dobrej zabawy w trakcie szturmowania zamku!";
            Console.WriteLine(max);

            string message1, message2;

            message1 = message2 = "WIADOMOŚĆ";
            Console.WriteLine(message2);

            string firstName;
            string lastName;
            Console.WriteLine("Hej, ty!");
            Console.Write("Podaj imię: ");
            firstName = Console.ReadLine();
            Console.Write("Podaj nazwisko: ");
            lastName = Console.ReadLine();
            Console.WriteLine($"Twoje imię i nazwisko to { firstName } { lastName}.");
            Console.WriteLine("Twoje imię i nazwisko to {0} {1}.", firstName, lastName);
            Console.WriteLine("Twoje nazwisko i imię to {1} {0}", firstName, lastName);

            int readValue;
            char character;
            readValue = Console.Read();
            character = (char)readValue;
            Console.WriteLine(character);
            Console.Write(readValue);
            // INT PRZECHOWUJE ASCII
            // https://pl.wikipedia.org/wiki/ASCII
        }
    }
}

//====================================   CLI   ====================================
// dotnet build - skompilowanie wszystkich projektow
// dotnet publish --runtime linux-x64 - polecenie wygenerowania pliku wykonywalnego
// .bin/Debug/net5.0/linux-x64/publish/HelloWorld - lokalizacja pliku wykonywalnego
// platformy przykładowe to: linux-x64, win-x64, osx-x64 https://docs.microsoft.com/en-us/dotnet/core/rid-catalog

// JEDEN PLIK WYKONYWALNY
// dotnet publish --runtime linux-x64 -p:PublishSingleFile=true

// dotnet run -p <plik_projektu> - ścieżka projektu
// dotnet test - wykonanie wszystkich testów