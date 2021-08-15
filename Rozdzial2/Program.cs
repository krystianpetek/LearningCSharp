﻿using System;

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
        }
    }
}
