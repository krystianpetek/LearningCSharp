using System;

namespace Zadanie05_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj ilosc liczb");
            int n = Convert.ToInt32(Console.ReadLine());
            Sortowanie x = new Sortowanie(n);
            int[] liczby = x.czytajDane();
            liczby = x.przetworzDane(liczby);
            Console.WriteLine();
            x.wyswietlWynik(liczby);
        }
    }
    class Sortowanie
    {
        public Sortowanie(int dlugoscTablicy)
        {
            dlugoscT = dlugoscTablicy;
        }
        static int dlugoscT;

        public int[] czytajDane()
        {
            int[] liczby = new int[dlugoscT];
            Random los = new Random();
            for (int i = 0; i < liczby.Length; i++)
            {
                liczby[i] = los.Next(-1000, 1000);
            }
            Console.Write("Liczby nieposortowane: ");
            foreach (var f in liczby)
                Console.Write($"{f} ");

            return liczby;
        }
        public int[] przetworzDane(int[] liczby)
        {
            bool warunek = false;
            int temp;
            while (!warunek)
            {
                warunek = true;
                for (int i = 0; i < liczby.Length - 1; i++)
                    if (liczby[i] > liczby[i + 1])
                    {
                        temp = liczby[i];
                        liczby[i] = liczby[i + 1];
                        liczby[i + 1] = temp;
                        warunek = false;
                    }
            }
            return liczby;
        }
        public void wyswietlWynik(int[] liczby)
        {
            Console.Write("Liczby posortowane: ");
            foreach (var f in liczby)
                Console.Write($"{f} ");
        }
    }
}
