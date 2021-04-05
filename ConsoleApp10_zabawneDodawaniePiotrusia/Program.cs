using System;

namespace ConsoleApp10_zabawneDodawaniePiotrusia
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for(int i = 0;i<t;i++)
            {
                int liczba = int.Parse(Console.ReadLine());


                

                if (liczba > 0 && liczba < 81)
                {
                    if (liczba.ToString().Length == 1)
                    {
                        Console.WriteLine($"{liczba} 0");
                        continue;
                    }

                    string lewa = liczba.ToString().Substring(0, 1);
                    string prawa = liczba.ToString().Substring(1,1);
                    if(lewa == prawa)
                    {
                        Console.WriteLine($"{liczba} 0");
                    }
                    else
                    {

                    }

                }
                else
                {
                    Console.WriteLine("blad");
                }
            }
        }
    }
}
