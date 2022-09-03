using System;

namespace ConsoleApp2_zadanie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int wartoscSprzedazy = 1001;
            int znizka = wartoscSprzedazy > 1000 ? 100 : 50;
            Console.WriteLine($"Zniżka: {znizka}zł");

            Console.WriteLine($"Zniżka: {(wartoscSprzedazy = 900 > 1000 ? 100 : 50)}zł");

            Random losowanie = new Random();
            int szansa = losowanie.Next(0, 100);
            Console.WriteLine($"Liczba: {szansa}: {(szansa>=50 ? "orzeł":"reszka")}");

            szansa = losowanie.Next(0, 2);
            Console.WriteLine($"Liczba: {szansa}: {(szansa > 0 ? "orzeł" : "reszka")}");

            string permission = "Admin|Manager";
            int level = 55;
            bool checkAdmin = permission.Contains("Admin");
            bool checkManager = permission.Contains("Manager");
            if (checkAdmin && level > 55)
            {
                Console.WriteLine("Welcome, Super Admin user");
            }
            else if (checkAdmin && level <= 55)
            {
                Console.WriteLine("Welcome, Admin user");
            }
            else if (checkManager && level >= 20)
            {
                Console.WriteLine("Contact an Admin for access.");
            }
            else if (checkManager && level < 20)
            {
                Console.WriteLine("You do not have sufficient privileges.");
            }
            else if(!checkAdmin || !checkManager)
            {
                Console.WriteLine("You do not have sufficient privileges. NULL");
            }

            if(permission.Contains("Admin"))
            {
                if(level > 55)
                {
                    Console.WriteLine("Welcome, Super Admin user");
                }
                else
                {
                    Console.WriteLine("Welcome, Admin user");
                }
            }
            else if(permission.Contains("Manager"))
            {
                if(level >=20 )
                {
                    Console.WriteLine("Contact an Admin for access.");
                }
                else
                {
                    Console.WriteLine("You do not have sufficient privileges.");
                }
            }
            else
            {
                Console.WriteLine("You do not have sufficient privileges.");
            }
        }
    }
}
