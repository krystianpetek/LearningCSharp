using System.IO;
using System;
namespace Zadanie06_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileStream x = new FileStream("plik.txt", FileMode.Create);
            PlikTekstowy pliczek = new PlikTekstowy();
            pliczek.CzytajDane();
            pliczek.ZapiszDaneDoPliku();
            pliczek.CzytajDaneZPliku();
            Console.Read();
        }
        
    }
    public class PlikTekstowy
    {
        static string nazwisko;
        static string imie;
        static string nazwaPliku = "dane.txt";
        static string odczyt = string.Empty;
        public void CzytajDane()
        {
            Console.WriteLine("Wczytaj imię: ");
            imie = Console.ReadLine();
            Console.WriteLine("Wczytaj nazwisko: ");
            nazwisko = Console.ReadLine();
        }
        public void ZapiszDaneDoPliku()
        {
            FileStream x = new FileStream($"{nazwaPliku}", FileMode.Create);
            StreamWriter fstr_out = new StreamWriter(x);
            fstr_out.WriteLine(imie);
            fstr_out.WriteLine(nazwisko);
            fstr_out.Close();
            x.Close();
        }
        public void CzytajDaneZPliku()
        {
            Console.WriteLine($"odczyt z pliku {nazwaPliku}");
            FileStream x = new FileStream($"{nazwaPliku}", FileMode.Open);
            StreamReader fstr_in = new StreamReader(x);
            while ((odczyt = fstr_in.ReadLine()) != null)
            {
                Console.WriteLine(odczyt);
            }
            fstr_in.Close();
            x.Close();
        }
    }
}
