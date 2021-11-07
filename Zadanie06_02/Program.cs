using System;
using System.IO;

namespace Zadanie06_02
{
    class Program
    {
        static void Main(string[] args)
        {
            TablicaPlik instancja = new TablicaPlik();
            instancja.CzytajDane();
            instancja.ZapiszDaneDoPliku();
            instancja.CzytajDaneZPliku();
        }
    }
    public class TablicaPlik
    {
        int[,] Tablica2D;
        public void CzytajDane()
        {
            Tablica2D = new int[10, 10];
            for (int i = 0; i < Tablica2D.GetLength(0); i++)
            {
                for (int j = 0; j < Tablica2D.GetLength(1); j++)
                {
                    if (i == j)
                        Tablica2D[i, j] = 1;
                    else
                        Tablica2D[i, j] = 0;
                }
            }
        }
        public void ZapiszDaneDoPliku()
        {
            FileStream plik = new FileStream($"dane.txt", FileMode.Create);
            StreamWriter plikZapisz = new StreamWriter(plik);
            for (int i = 0; i < Tablica2D.GetLength(0); i++)
            {
                for (int j = 0; j < Tablica2D.GetLength(1); j++)
                {
                        plikZapisz.Write($"{Tablica2D[i, j]} ");
                }
                plikZapisz.WriteLine();
            }
            plikZapisz.Close();
            plik.Close();

        }
        public void CzytajDaneZPliku()
        {
            string linia;
            FileStream plik = new FileStream($"dane.txt", FileMode.Open);
            StreamReader plikOdczyt = new StreamReader(plik);
            while ((linia = plikOdczyt.ReadLine()) != null)
            {
                Console.WriteLine(linia);
            }
            plikOdczyt.Close();
            plik.Close();
        }
    }
}
