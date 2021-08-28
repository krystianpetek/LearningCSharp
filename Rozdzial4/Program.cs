using System;
using System.Diagnostics;

namespace Rozdzial4
{
    class Program
    {
        static void Main(string[] args)
        {
            // OPERATORY

            int difference = 4 - 2;
            decimal debt = -26457079712930.80M;
            int licznik, mianownik, iloraz, reszta;
            Console.WriteLine("Wprowadź licznik: ");
            licznik = int.Parse(Console.ReadLine());
            Console.WriteLine("Wprowadź mianownik: ");
            mianownik = int.Parse(Console.ReadLine());
            iloraz = licznik / mianownik;
            reszta = licznik % mianownik;
            Console.WriteLine($"{licznik} / {mianownik} = {iloraz}, reszta {reszta}");

            short predkoscWiatru = 42;
            Console.WriteLine($"Pierwszy most Tacoma w Waszyngtonie został\nzniszczony przez wiatr wiejący z prędkością {predkoscWiatru} mil na godzinę");

            int n = '3' + '4';
            char c = (char)n;
            Console.WriteLine(c);

            int distance = 'f' - 'c';
            Console.WriteLine(distance);

            decimal decimalNumber = 4.2M;
            double doubleNumber1 = 0.1F * 42F;
            double doubleNumber2 = 0.1D * 42D;
            float floatNumber = 0.1F * 42F;
            Trace.Assert(decimalNumber != (decimal)doubleNumber1);
            Console.WriteLine($"{decimalNumber} != {(decimal)doubleNumber1}");
            Trace.Assert((double)decimalNumber != doubleNumber1);
            Console.WriteLine($"{(double)decimalNumber} != {doubleNumber1}");
            Trace.Assert((float)decimalNumber != floatNumber);
            Console.WriteLine($"(float){(float)decimalNumber}M != {floatNumber}F");
            // Trace.Assert(doubleNumber1 != (double)floatNumber);
            Console.WriteLine($"{doubleNumber1} != {(double)floatNumber}");
            Trace.Assert(doubleNumber1 != doubleNumber2);
            Console.WriteLine($"{doubleNumber1} != {doubleNumber2}");
            Trace.Assert(floatNumber != doubleNumber2);
            Console.WriteLine($"{floatNumber}F != {doubleNumber2}D");
            Trace.Assert((double)4.2F != 4.2D);
            Console.WriteLine($"{(double)4.2F} != {4.2D}");
            Trace.Assert(4.2F != 4.2D);
            Console.WriteLine($"{4.2F}F != {4.2D}D");

            // UNIKAJ w instrukcjach warunkowych porównań wartości binarnych typów
            // zmiennoprzecinkowych.Powinieneś albo odjąć od siebie dwie wartości i sprawdzić,
            // czy różnica między nimi jest mniejsza niż wartość progowa, albo zastosować
            // typ decimal.

            float N = 0f;
            Console.WriteLine(N / 0); // dzielenie float przez 0 zawsze daje NaN
                                      // to samo w przypadku System.Math.Sqrt(-1) pierwiastek z ujemnej liczby daje NaN

            Console.WriteLine(-1f / 0); // Wyświetla: –Infinity
            Console.WriteLine(3.402823E+38f * 2f); // Wyświetla: Infinity


            // ZŁOŻONE OPERATORY PRZYPISANIA
            int x = 123;
            x = x + 2;
            x += 2;
            x -= 2;
            x /= 2;
            x *= 2;
            x %= 10;
            Console.WriteLine(x);
            // INKREMENATACJA I DEKREMENTACJA
            int spaceCount = 10;
            spaceCount = spaceCount + 1;
            spaceCount += 1;
            spaceCount++;

            // DEKREMENTACJA W PĘTLI
            char current;
            current = 'z';
            do
            {
                Console.Write($"{current} = {(int)current} ");
                current--;
            } while (current >= 'a');

            Console.WriteLine(); // Wypisanie UNICODE w FOR
            for (int i = 0; i < 255; i++) // UNICODE
            {
                Console.Write($"{(char)i} ");
            }

            Console.WriteLine();// POST i PRE inkrementacja
            int count = 123;
            int result;
            result = count++;
            Console.WriteLine($"result = {result} i count = {count}");
            result = ++count;
            Console.WriteLine($"result = {result} i count = {count}");
            // STAŁE
            const int secondsPerDay = 60 * 60 * 24;
            const int secondsPerWeek = secondsPerDay * 7;

            // PRZYKŁAD IF ELSE
            Console.Write(
            "1 – Gra przeciwko komputerowi\n" +
            "2 – Gra przeciwko innemu graczowi\n" +
            "Wybierz:"
            );
            int input = Convert.ToInt32(Console.ReadLine());
            if (input == '1')
                Console.WriteLine("Wybrano grę przeciw komputerowi");
            else
                Console.WriteLine("Wybrano grę przeciw drugiej osobą");

            // ZAGNIEŻDZONE IFY
            Console.WriteLine("\nJaka jest maksymlna liczba ruchów w grze kółko i krzyżyk?" + "(Wpisz 0 aby zakończyć.)");
            input = int.Parse(Console.ReadLine());
            if (input <= 0)
                Console.WriteLine("Zamykanie programu...");
            else if (input < 9)
                Console.WriteLine($"Maksymalna liczba ruchów w grze w kółko i krzyżyk jest większa niż {input}.");
            else if (input > 9)
                Console.WriteLine($"Maksymalna liczba ruchów w grze w kółko i krzyżyk jest mniejsza niż {input}.");
            else
                Console.WriteLine("Dobrze, maksymalna liczba ruchów w grze w kółko i krzyżyk wynosi 9.");

            // XOR - ^ zawsze sprawdza wszystkie warunki, w odróżnieniu do np. OR
            bool valid = false;
            bool rezultat = !valid;
            Console.WriteLine(rezultat);

            // SYMULACJA GRY
            int currentPlayer = 1;
            for (int turn = 1; turn <= 10; turn++) // TURA
            {
                currentPlayer = (currentPlayer == 2) ? 1 : 2; // zmiana gracza w zależności od tury
                Console.WriteLine(currentPlayer);
            }

            // PROGRAMOWANIE A NULL
            string? nullowaty = null;
            if (nullowaty != null)
                Console.WriteLine($"nullowaty jest równe: {nullowaty}");
            else
                Console.WriteLine($"nullowaty jest równe null");

            if (object.ReferenceEquals(nullowaty, null))
                Console.WriteLine("nullowaty jest równe null");

            if (nullowaty is object)                                     // ZALECANE
                Console.WriteLine($"nullowaty jest równe: {nullowaty}");
            else
                Console.WriteLine($"nullowaty jest równe null");

            if (nullowaty is null)                                       // ZALECANE
                Console.WriteLine($"nullowaty jest równe null");
            else
                Console.WriteLine($"nullowaty jest równe: {nullowaty}");

            // OPERATOR ?? - jeśli dana wartość to null, zastosuj inną wartość
            //string fullName = GetDefaultDirectory();
            //string fileName = GetFileName() ?? "config.json";
            //string directory = GetConfigurationDirectory() ??
            //GetApplicationDirectory() ??
            //System.Environment.CurrentDirectory;
            //fullName ??= $"{ directory }/{ fileName }";

            string a = null, b = "b", d = "d";
            Console.WriteLine(a ?? b ?? d);
            // NOWY OPERATOR W C# 8.0 - ??= - sprawdza czy po lewej stronie jest wartość rózna od null, jeśli nie to przypisuje tam wartość;
            string f = null;
            f ??= "aa";
            f ??= "A";
            Console.WriteLine(f);

            // OPERATOR ?. i ?[] - Operator ?. sprawdza, czy operand (segments na listingu 4.37) ma wartość null. Dopiero potem wywołuje metodę lub właściwość(tu jest to Length).
            string[]? segments = null;
            int? length = segments?.Length;
            string uri = null;
            if (length is object && length != 0)
                uri = string.Join("/", segments!);

            if (uri is null || length is 0)
                Console.WriteLine("brak elementów do połączenia");
            else
                Console.WriteLine($"URI: {uri}");

            length = (segments != null) ? (int?)segments.Length : null;

            string?[]? segments2; // SEGMENTS2 moze byc równe null i każdy element tej tablicy też
            uri = segments?[0]?.ToLower().Trim() ?? "intellitect.com";

            // OPERATOR ! - deklaracja wartości róznej od null
            // ?. razem z delegatami strona 163 !!!!!!!!!!!!!!!!!!!!!!!!!!!!
            

        }   
    }
}