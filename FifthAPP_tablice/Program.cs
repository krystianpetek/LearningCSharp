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
        }
    }
}
