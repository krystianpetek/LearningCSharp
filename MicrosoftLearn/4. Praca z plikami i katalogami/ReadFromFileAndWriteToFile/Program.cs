using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ReadFromFileAndWriteToFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory("../../../");
            Console.WriteLine(File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json"));

            var salesJson = File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
            var salesData = JsonConvert.DeserializeObject<SalesTotal>(salesJson);
            Console.WriteLine(Environment.NewLine + "Wynik JsonConvert: " + salesData.Total);


            File.WriteAllText($"SalesTotals{Path.DirectorySeparatorChar}totals.txt", salesData.Total.ToString() + Environment.NewLine);
            File.AppendAllText($"SalesTotals{Path.DirectorySeparatorChar}totals.txt", salesData.Total.ToString());

            Console.WriteLine("\n\nZADANIE");
            IEnumerable<string> listaPlikowSalesJson = ListaPlikow("sales.json", Directory.GetCurrentDirectory());
            List<SalesTotal> odczytaneDane = OdczytDanych(listaPlikowSalesJson);
            string sumaSales = SumowanieSales(odczytaneDane);
            Console.WriteLine(sumaSales);
            
        }

        private static List<SalesTotal> OdczytDanych(IEnumerable<string> listaPlikowSalesJson)
        {
            List<SalesTotal> listaSprzedazy = new List<SalesTotal>();
            foreach(var x in listaPlikowSalesJson)
            {
                var plik = File.ReadAllText(x);
                listaSprzedazy.Add(JsonConvert.DeserializeObject<SalesTotal>(plik));
                
            }
            return listaSprzedazy;
        }

        static IEnumerable<string> ListaPlikow(string extension, string path)
        {
            var plikiEnumerable = Directory.EnumerateFiles(path, extension, SearchOption.AllDirectories);
            return plikiEnumerable;
        }

        static string SumowanieSales(List<SalesTotal>sumka)
        {
            double wynik = 0;
            foreach (var s in sumka)
                wynik += s.Total;

            return wynik.ToString("Suma: 0.00");
        }
    }

    public class SalesTotal
    {
        public double Total { get; set; }
    }
}
