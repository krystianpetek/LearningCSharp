using System;
using System.IO;
namespace Zadanie06_04
{
    class Plik_swobodny
    {
        FileStream f;
        char[] litery = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        public void zapisz_czytaj_dane()
        {
            int i;
            f = new FileStream("litery.dat", FileMode.Create);
            for (i = 0; i < litery.Length; i++)
            {
                f.WriteByte((byte)litery[i]);
            }
            f.Close();

            f = new FileStream("litery.dat", FileMode.Open);
            Console.WriteLine("Dane przeczytane z pliku to: ");
            for (i = 0; i < litery.Length; i++)
            {
                f.Seek(i, SeekOrigin.Begin);
                char ch = (char)f.ReadByte();
                if (i < litery.Length - 1)
                {
                    Console.Write(ch + ", ");
                }
                else
                {
                    Console.Write(ch + ".");
                }
            }
            f.Close();
        }

        static void Main(string[] args)
        {
            Plik_swobodny tab = new Plik_swobodny();
            tab.zapisz_czytaj_dane();

        }
    }
}