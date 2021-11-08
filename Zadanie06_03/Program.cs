using System;
using System.IO;

namespace Zadanie06_03
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new PlikTekstowy();
            x.CzytajDane();
            x.ZapiszDaneDoPliku();
            x.CzytajDaneZPliku();
            x.OdwrocMacierz();
        }
    }
    public class PlikTekstowy
    {
        int[] Tablica1D;
        int[,] Tablica2D;

        public void CzytajDane()
        {
            Tablica1D = new int[100];
            for (int i = 0; i < Tablica1D.GetLength(0); i++)
            {
                Tablica1D[i] = i + 1;
            }
        }
        public void ZapiszDaneDoPliku()
        {
            FileStream plik = new FileStream($"dane.txt", FileMode.Create);
            StreamWriter plikZapisz = new StreamWriter(plik);
            for (int i = 0; i < Tablica1D.GetLength(0); i++)
            {
                if (i % 10 == 0 && i != 0)
                    plikZapisz.WriteLine();
                plikZapisz.Write($"{Tablica1D[i]}".PadLeft(4));
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

        public void OdwrocMacierz()
        {
            string linia = "";
            Tablica1D = new int[100];
            Tablica2D = new int[10, 10];
            FileStream plikZrodlowy, plikDocelowy;
            plikZrodlowy = new FileStream("dane.txt", FileMode.Open);
            StreamReader streamZrodlowy = new StreamReader(plikZrodlowy);
            plikDocelowy = new FileStream("macierz.txt", FileMode.Create);
            StreamWriter streamDocelowy = new StreamWriter(plikDocelowy);

            string wynik = "";
            while ((linia = streamZrodlowy.ReadLine()) != null)
            {
                wynik += linia;
            }
            int j = 0;
            for (int i = 0; i < Tablica2D.GetLength(0); i++)
            {
                for (int k = 0; k < Tablica2D.GetLength(1); k++)
                {
                    string X = "";
                    for (int a = 0; a < 4; a++)
                    {
                        X += wynik[j++];
                    }
                    Tablica2D[i, k]= int.Parse(X.Trim().ToString());
                }
            }

            for (int g = 0; g < Tablica2D.GetLength(0); g++)
            {
                for (int h = 0; h < Tablica2D.GetLength(1); h++)
                {

                    streamDocelowy.Write($"{Tablica2D[h, g]}".PadLeft(4));
                }
                streamDocelowy.WriteLine();
            }

            streamZrodlowy.Close();
            streamDocelowy.Close();
            plikZrodlowy.Close();
            plikDocelowy.Close();
        }
    }

}
