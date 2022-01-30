using System;
using System.Collections.Generic;
namespace TypyGeneryczne
{
    internal static class Program
    {
        static void Main()
        {
            var restauracje = new List<Restauracja>();

            var rezultat = new PaginacjaRezultatow<Restauracja>
            {
                Rezultat = restauracje
            };

            var stringRepozytorium = new RepozytoriumGen<string>();
            stringRepozytorium.DodajElement("troche wartosci");
            stringRepozytorium.DodajElement("troche więcej wartosci");
            var pierwszyElement = stringRepozytorium.ZwrocElementOId(0);
            Console.WriteLine(pierwszyElement);

            var repozytoriumUzytkownikow = new RepozytoriumGen<string, Klient>();
            repozytoriumUzytkownikow.DodajElement("Krystian", new Klient { Nazwa = "Krystian" });
            Klient krystian = repozytoriumUzytkownikow.ZwrocElementOKluczu("Krystian");

            var repozytoriumOgraniczenia = new RepozytoriumOgraniczenia<Klient>();
            repozytoriumOgraniczenia.DodajElement(krystian);

            int[] tablicaIntow = new int[] { 1, 2, 3, 4, 5 };
            Narzedzia.ZamianaRefow(ref tablicaIntow[1], ref tablicaIntow[^2]);
            foreach(var i in tablicaIntow)
                Console.WriteLine(i);
        }
    }
}
