using System;

namespace Rozdzial5_7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //przekazywanie parametrów za pomocą nazw
            DisplayGreetings(firstName: "Inigo", lastName: "Montoya");

            // przekształcanie string na int
            string firstName;
            string ageText;
            int age, result = 0;
            Console.WriteLine("Hej, ty!");
            Console.WriteLine("Wprowadź imię: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Wprowadź wiek: ");
            ageText = Console.ReadLine();
            try
            {
                age = int.Parse(ageText);
                Console.WriteLine($"Hej, {firstName}! Twój wiek w miesiącach to: {age * 12}.");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Wprowadzony wiek, {ageText}, nie jest prawidłowy");
                result = 1;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Nieoczekiwany błąd: {exception.Message}");
                result = 1;
            }
            finally
            {
                Console.WriteLine($"Żegnaj, {firstName}");
            }

            Console.WriteLine();
            // zgłaszanie błędów throw
            try
            {
                Console.WriteLine("Rozpoczęcie wykonywania kodu");
                Console.WriteLine("Zgłoszenie wyjątku");
                throw new Exception("Dowolny wyjątek");
                Console.WriteLine("Koniec wykonywania kodu");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Nieoczekiwany błąd: {exception.Message}");
                Console.WriteLine($@"Ponowne zgłaszanie nieoczekiwanego błędu: {exception.Message}");
                // Ponowne zgłoszenie wyjątku - wpisz w tym bloku 'throw;'
                // throw;
            }
            catch
            {
                Console.WriteLine("Nieoczekiwany błąd!");
            }
            Console.WriteLine("Zamykanie programu");

            // TryParse
            if (int.TryParse(ageText, out int age2))
                Console.WriteLine($"Hej, {firstName}! Twój wiek w miesiącach to {age2 * 12}.");
            else
                Console.WriteLine($"Wprowadzony wiek, {ageText}, nie jest prawidłowy");
        }

        public static void DisplayGreetings(
            string firstName,
            string? middleName = null,
            string? lastName = null
        )
        {
            Console.WriteLine(firstName.Length + lastName.Length);
        }
    }
}