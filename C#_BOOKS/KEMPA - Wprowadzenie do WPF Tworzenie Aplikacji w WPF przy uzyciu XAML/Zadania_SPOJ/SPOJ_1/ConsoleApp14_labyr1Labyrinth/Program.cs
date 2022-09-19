using System;
using System.Collections;

namespace ConsoleApp14_labyr1Labyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0, y = 0;
            int T = int.Parse(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                string[] linia = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int C = int.Parse(linia[0]);
                int R = int.Parse(linia[1]);

                if (C < 3 || C > 1000 || R < 3 || R > 1000)
                {
                    Console.WriteLine("Błędne dane");
                    return;
                }

                // PRZYPISANIE RZUTU DO TABLICY
                char[,] tablica = new char[C, R];

                for (x = 0; x < R; x++)
                {
                    string wejscieLinia = Console.ReadLine();
                    for (y = 0; y < C; y++)
                    {
                        tablica[x, y] = wejscieLinia[y];
                        Console.WriteLine(x+" "+ y);
                    }
                }
                
                for (x = 0; x < tablica.GetLength(0); x++)
                {
                    for (y = 0; y < tablica.GetLength(1); y++)
                    {
                        Console.Write(tablica[x, y]);
                        if(y == tablica.GetLength(1)-1)
                            Console.WriteLine();
                    }
                }


                //Stack stos = new Stack();
                //Console.WriteLine(tablica.GetLength(1));
                //for (x = 1; x < tablica.GetLength(1) - 1; x++)
                //{
                //    for (y = 1; y < tablica.GetLength(0) - 1; y++)
                //    {


                //        if (tablica[x, y] == '#')
                //            continue;
                //        else
                //        {

                //            while (true)
                //            {
                //                var gora = tablica[x - 1, y];
                //                var prawo = tablica[x, y + 1];
                //                var dol = tablica[x + 1, y];
                //                var lewo = tablica[x, y - 1];

                //                Console.WriteLine($"{gora},{prawo},{dol},{lewo}");
                //                if (tablica[x, y] == '.')
                //                {
                //                    stos.Push(x);
                //                    stos.Push(y);
                //                }
                //                if (gora == '.')
                //                {
                //                    x--;
                //                    Console.WriteLine("gora");
                //                    continue;
                //                }

                //                if (prawo == '.')
                //                {
                //                    y++;
                //                    Console.WriteLine("prawo");
                //                    continue;

                //                }
                //                if (dol == '.')
                //                {
                //                    x++;

                //                    continue;
                //                }
                //                if (lewo == '.')
                //                {
                //                    Console.WriteLine("dol");
                //                    y--;
                //                    continue;
                //                }

                //                Console.WriteLine(stos.Count);

                //                if (gora == '#' && prawo == '#' && dol == '#' && lewo == '#')
                //                    break;

                //            }
                //        }
                //    }
                //}

            }
        }
    }
}
