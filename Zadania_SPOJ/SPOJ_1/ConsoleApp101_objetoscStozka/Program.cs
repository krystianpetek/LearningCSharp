using System;

namespace ConsoleApp2_objetoscStozka
{
    class Program
    {
        static void Main(string[] args)
        {
            string wejscie = Console.ReadLine();
            string[] linia = wejscie.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            long R = int.Parse(linia[0]);
            long L = int.Parse(linia[1]);

            //if (R > 1000000 || R < -1000000)
            //    throw new ArgumentException("Wartosc poza zakresem");
            //else if (L > 1000000 || L < -1000000)
            //    throw new ArgumentException("Wartosc poza zakresem");

            if (R < 0 || L < 0)
                Console.Write("ujemny argument");
            else if (R > L)
                Console.Write("obiekt nie istnieje");
            else
            {
                decimal wysokoscStozka = (decimal)Math.Sqrt(Math.Pow(L, 2) - Math.Pow(R, 2));
                decimal polePodstawyStozka = (decimal)Math.PI * (decimal)Math.Pow(R, 2);
                decimal objetoscStozka = (polePodstawyStozka * wysokoscStozka / 3);

                //Console.WriteLine($"Wysokosc stożka: {wysokoscStozka}");
                //Console.WriteLine($"Pole podstawy stożka: {polePodstawyStozka}");
                //Console.WriteLine($"Objętość stożka: {objetoscStozka}");
                //Console.WriteLine($"Tworząca: {L}");
                //Console.WriteLine($"{Math.Sqrt(Math.Pow(R, 2) + Math.Pow((double)wysokoscStozka, 2))}");

                decimal a = Math.Floor(objetoscStozka);
                decimal b = Math.Ceiling(objetoscStozka);
                Console.Write($"{a} {b}");
            }
        }
    }
}
