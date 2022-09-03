using System;
using System.Collections.Generic;
using System.IO;

namespace WorkWithFileAndDirectoriesInNetApp
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Directory.SetCurrentDirectory("../../../");
            IEnumerable<string> listaFolderow = Directory.EnumerateDirectories("stores");
            foreach (var folder in listaFolderow)
                Console.WriteLine(folder);


            Console.WriteLine();
            IEnumerable<string> pliki = Directory.EnumerateFiles("stores");
            foreach (var plik in pliki)
                Console.WriteLine(plik);


            Console.WriteLine();
            IEnumerable<string> wszystkiePlikiTxt = Directory.EnumerateFiles("stores", "*.txt", SearchOption.AllDirectories);
            foreach (var plikiTxt in wszystkiePlikiTxt)
                Console.WriteLine(plikiTxt);


            Console.WriteLine();
            var plikiSalesJson = znajdzPlikiSales("stores");
            foreach (var plik in plikiSalesJson)
                Console.WriteLine(plik);

        }
        static IEnumerable<string> znajdzPlikiSales(string nazwaFolderu)
        {
            List<string> listaPlikowSales = new List<string>();
            var listaWszystkichPlikow = Directory.EnumerateFiles(nazwaFolderu, "*", SearchOption.AllDirectories);
            foreach (var plikSales in listaWszystkichPlikow)
                if (plikSales.EndsWith("sales.json"))
                    listaPlikowSales.Add(plikSales);

            return listaPlikowSales;
        }
    }

}
