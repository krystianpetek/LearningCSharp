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

            instancja.PrzepiszDaneZPlikuDoPliku();
            instancja.CzytajDaneZPliku("przepisz");
        }
    }
    public class TablicaPlik
    {
        int[,] Tablica2D;
        int[] Tablica1D;

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
        public void CzytajDaneZPliku(string nazwaPliku = "dane")
        {
            string linia;
            FileStream plik = new FileStream($"{nazwaPliku}.txt", FileMode.Open);
            StreamReader plikOdczyt = new StreamReader(plik);
            while ((linia = plikOdczyt.ReadLine()) != null)
                Console.WriteLine(linia);
            plikOdczyt.Close();
            plik.Close();
        }

        public void PrzepiszDaneZPlikuDoPliku()
        {
            string linia;
            Tablica1D = new int[100];
            FileStream plikZrodlowy, plikDocelowy;
            plikZrodlowy = new FileStream("dane.txt", FileMode.Open);
            StreamReader streamZrodlowy = new StreamReader(plikZrodlowy);
            plikDocelowy = new FileStream("przepisz.txt", FileMode.Create);
            StreamWriter streamDocelowy = new StreamWriter(plikDocelowy);

            int i = 0;
            while ((linia = streamZrodlowy.ReadLine()) != null)
            {
                for (int j = 0; j < Tablica1D.Length/10; j++)
                {
                    linia = linia.Replace(" ", "");

                    Tablica1D[i + j] = Convert.ToInt32(linia[j].ToString());
                    streamDocelowy.Write($"{Tablica1D[i+j]}");
                }
                streamDocelowy.WriteLine();
                i++;
            }
            streamZrodlowy.Close(); 
            streamDocelowy.Close(); 
            plikZrodlowy.Close();
            plikDocelowy.Close();
        }
    }
}
