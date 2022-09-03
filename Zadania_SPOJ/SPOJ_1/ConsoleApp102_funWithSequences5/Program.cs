using System;

namespace ConsoleApp102_funWithSequences5_ROWNE
{
    class Program
    {
        static void Main0(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // ilość liczb w sekwencji S
            if (n < 2)

                throw new ArgumentException("Zle wprowadzone dane");
            string S = Console.ReadLine();
            string[] tablicaS = S.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int dlugoscTablicy = tablicaS.Length;

            if (tablicaS.Length != n)
                throw new ArgumentException("Zle wprowadzone dane");

            int x = 0;

            for (int i = 0; i < dlugoscTablicy / 2; i++)
            {

                x++;

                if (x == dlugoscTablicy / 2)
                    break;

                if (int.Parse(tablicaS[i]) > int.Parse(tablicaS[x]))
                {

                }
                else
                {
                    Console.WriteLine("No");
                    return;
                }

            }
            dlugoscTablicy = tablicaS.Length;
            int y = dlugoscTablicy - 1;
            for (int j = dlugoscTablicy - 1; j > dlugoscTablicy / 2; j--)
            {

                y--;
                if (y == dlugoscTablicy / 2 - 1)
                    break;

                if (int.Parse(tablicaS[j]) > int.Parse(tablicaS[y]))
                {
                }
                else
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            Console.WriteLine("Yes");

        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n < 2 || n > 100)
            {
                return;
            }
            string S = Console.ReadLine();
            string[] tablicaS = S.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //Moze wyrzucać błędy na SPOJ

            if (tablicaS.Length != n)
                throw new ArgumentException("BŁĄD");


            int dlugoscS = tablicaS.Length;
            int dlugoscCzesci = dlugoscS / 2;

            if (dlugoscS % 2 == 1)
            {
                dlugoscCzesci++;
            }

            //LEWA CZESC
            string[] lewaCzesc = new string[dlugoscCzesci];
            for (int a = 0; a < dlugoscCzesci; a++)
            {
                lewaCzesc[a] = tablicaS[a];
            }
            dlugoscCzesci--;
            //PRAWA CZESC
            Array.Reverse(tablicaS);
            string[] prawaCzesc = new string[dlugoscCzesci];
            for (int b = 0; b < dlugoscCzesci; b++)
            {
                prawaCzesc[b] = tablicaS[b];
            }

            //LEWA CZESC
            for (int x = 0; x < lewaCzesc.Length; x++)
            {
                if (x + 1 == lewaCzesc.Length)
                    break;
                if (Convert.ToInt32(lewaCzesc[x]) > Convert.ToInt32(lewaCzesc[x + 1]))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("No");
                    return;
                }
            }

            //PRAWA CZESC
            for (int y = 0; y < prawaCzesc.Length; y++)
            {
                if (y + 1 == prawaCzesc.Length)
                    break;
                if (Convert.ToInt32(prawaCzesc[y]) > Convert.ToInt32(prawaCzesc[y + 1]))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            Console.WriteLine("Yes");


        }
    }
}
