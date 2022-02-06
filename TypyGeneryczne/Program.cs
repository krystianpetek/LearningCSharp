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


            int fun(int n)
            {
                if (n < 2) return n;
                if (n % 2 == 1) return fun(n - 2);
                else return fun(n - 1);
            };

            Console.WriteLine();
            Console.WriteLine(fun(6));
            Console.WriteLine(fun(7));
            Console.WriteLine(fun(8));

            Console.WriteLine();


            int nwd(int a, int b)
            {
                return (a == 0) ? b : nwd(b % a, a);
            }
            bool czyWzgledniePierwsze2(int a, int b)
            {
                return (nwd(a, b) == 1);
            }
            Console.WriteLine(czyWzgledniePierwsze2(1,10));
        }
    }
}
