using System;

namespace Rozdzial6_9
{
    internal class Program
    {
        private static void Main()
        {
        }
    }

    partial class Person
    {
        // Metody częściowe, można tworzyc tylko w klasach częściowych
        partial void OnLastNameChanging(string value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (value.Trim().Length == 0)
            {
                throw new ArgumentException(
                "Argument LastName nie może być pusty.",
                nameof(value));
            }
        }
    }
}