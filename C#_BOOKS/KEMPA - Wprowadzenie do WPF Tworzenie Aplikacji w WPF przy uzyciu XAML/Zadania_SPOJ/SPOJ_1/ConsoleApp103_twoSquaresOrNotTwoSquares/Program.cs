using System;

namespace ConsoleApp103_twoSquaresOrNotTwoSquares
{
    class Program
    {
        static void Main(string[] args)
        {
            int c = int.Parse(Console.ReadLine());
            for (int a = 0; a < c; a++)
            //for (int b = 2; b < c; b++)
            {
                int b = int.Parse(Console.ReadLine());

                bool check = false;
                int dzielnik = 2;
                while (dzielnik != b)
                {
                    if (b == 1)
                    {
                        check = true;
                        break;
                    }
                    if (b % dzielnik == 0)
                    {
                        check = true;
                        break;
                    }
                    dzielnik++;
                }
                if (check == false && b % 4 == 1)
                    Console.WriteLine("Yes");
                else
                    Console.WriteLine("No");
                    
            }
        }
    }
}
