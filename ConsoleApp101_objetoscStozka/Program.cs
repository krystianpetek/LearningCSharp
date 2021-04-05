using System;

namespace ConsoleApp101_objetoscStozka
{
    class Program
    {
        /*66,6*/
        static void Main1(string[] args)
        {
            string wejscie = Console.ReadLine();
            string[] linia = wejscie.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int R = int.Parse(linia[0]);
            int L = int.Parse(linia[1]);
            if (R > L)
            {
                Console.WriteLine("obiekt nie istnieje");
            }
            else if (R < 0 || L < 0)
            {
                Console.WriteLine("ujemny argument");
            }
            else
            {
                const double PI = 3.14;
                double h = Math.Sqrt(Math.Pow(L, 2) - Math.Pow(R, 2));
                double polePodstawy = PI * Math.Pow(R, 2);

                double Obj = (polePodstawy * h) / 3;
                int a = (int)Obj;
                int b = Convert.ToInt32(Obj);
                Console.WriteLine($"{a} {b}");
            }
        }
        static void Main(string[] args)
        {
            string wejscie = Console.ReadLine();
            string[] linia = wejscie.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int R = int.Parse(linia[0]);
            int L = int.Parse(linia[1]);
            if(R > 1000000 || R < -1000000)
            {
                throw new ArgumentException("błędne dane");
            }
            if (L > 1000000 || L < -1000000)
            {
                throw new ArgumentException("błędne dane");
            }
            else if (R > L)
            {
                Console.WriteLine("obiekt nie istnieje");
            }
            else if (R < 0 || L < 0)
            {
                Console.WriteLine("ujemny argument");
            }
            else if(R == 0 && L > 0)
            {
                Console.WriteLine("obiekt nie istnieje");
            }
            /*else if (R == 0 || L == 0)
            {
                throw new ArgumentException("błędne dane");
            }*/
            else
            {
                const double PI = 3.141592653589793238462643383279;
                double h = Math.Sqrt(Math.Pow(L, 2) - Math.Pow(R, 2));
                double polePodstawy = PI * Math.Pow(R, 2);

                double Obj = (polePodstawy * h) / 3;

                int wynik = (int)Math.Round(Obj);
                int wynik2 = (int)(Obj);            


                if(wynik2 == wynik && R != L)
                {
                    wynik++;
                }

                if(wynik>wynik2)
                {
                    int temp = wynik;
                    wynik = wynik2;
                    wynik2 = temp;
                }
                Console.WriteLine($"{wynik} {wynik2}" );

                
            }
        }
    }
}
