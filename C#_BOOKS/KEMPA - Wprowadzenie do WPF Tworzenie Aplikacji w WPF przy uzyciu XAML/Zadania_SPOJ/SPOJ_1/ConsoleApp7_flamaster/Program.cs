using System;

namespace ConsoleApp7_flamaster
{
    class Program
    {
        static void Main(string[] args)
        {
            int C = int.Parse(Console.ReadLine());
            if (C < 51 && C > 0)
            {
                for (int i = 0; i < C; i++)
                {
                    string linia = Console.ReadLine();
                    string wynik = "";
                    if (linia.Length <= 200)
                    {
                        int x = 0;
                        while (x < linia.Length)
                        {
                            int licznikWystapien = 1;
                            char szukaj = linia[x];
                            x++;

                            for (; x < linia.Length && linia[x] == szukaj;)
                            {
                                licznikWystapien++;
                                x++;
                            }
                            if (licznikWystapien == 1)
                            {
                                wynik += szukaj.ToString();
                            }
                            else if (licznikWystapien == 2)
                            {
                                wynik += szukaj.ToString();
                                wynik += szukaj.ToString();
                            }
                            else
                            {
                                wynik += szukaj.ToString();
                                wynik += licznikWystapien.ToString();
                            }
                        }
                        Console.WriteLine(wynik);

                    }
                }
            }
        }
    }
}
