using System;

namespace ConsoleApp6_zadanie1_regulyBiznesowe
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wartosci = { "12.3", "45", "ABC", "11", "DEF" };
            string wiadomosc = "";
            float suma = 0;
            float dlugoscTablicy = wartosci.Length;
            for (int i = 0; i < dlugoscTablicy; i++)
            {
                float dodaj = 0;
                if (float.TryParse(wartosci[i], out dodaj))
                {
                    suma += dodaj;
                }
                else
                {
                    wiadomosc += wartosci[i];
                }
            }
            Console.WriteLine($"Wiadomosc: {wiadomosc}");
            Console.WriteLine($"Calosc: {suma}");

            decimal total = 0m;
            string message = "";
            foreach(var value in wartosci)
            {
                decimal number;
                if(decimal.TryParse(value, out number))
                {
                    total += number;
                }
                else
                {
                    message += value;
                }

            }
            Console.WriteLine($"Message: {message}");
            Console.WriteLine($"Total: {total}");
        }
    }
}
