using System;

namespace FifthAPP_tablice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            /*
            string[] fraudulentOrderIDs = new string[3];
            fraudulentOrderIDs[0] = "A123";
            fraudulentOrderIDs[1] = "B456";
            fraudulentOrderIDs[2] = "C789";
            //fraudulentOrderIDs[3] = "D000";
            */
            string[] fraudulentOrderIDs = { "A123", "B456", "C789" };
            Console.WriteLine($"Pierwsze: {fraudulentOrderIDs[0]}");
            Console.WriteLine($"Drugie: {fraudulentOrderIDs[1]}");
            Console.WriteLine($"Trzecie: {fraudulentOrderIDs[2]}");

            fraudulentOrderIDs[0] = "F000";
            Console.WriteLine($"Ponowne przypisanie Pierwsze: {fraudulentOrderIDs[0]}");
            Console.WriteLine($"Mamy {fraudulentOrderIDs.Length} fałszywe zamówienia do sprawdzenia.");

            string[] names = { "Bob", "Conrad", "Grant" };
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            int[] inventory = { 200, 450, 700, 175, 250 };
            int suma = 0;
            int pojemnik = 0;
            foreach (int items in inventory)
            {
                pojemnik++;
                suma += items;
                Console.WriteLine($"Pojemnik {pojemnik} = {items} przedmiotów (W sumie: {suma})");
            }
            Console.WriteLine($"Mamy {suma} przedmiotów w ekwipunku\n");

            string[] falszyweZamowienia = { "B123", "C234", "A345", "C15", "B177", "G3003", "C235", "B179" };
            foreach (string i in falszyweZamowienia)
            {
                if(i.StartsWith("B"))
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
