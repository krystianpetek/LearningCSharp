using System;
using System.Collections.Generic;
using System.IO;

namespace CreateFilesAndDirectories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory("../../../");

            string sciezka = Path.Combine(Directory.GetCurrentDirectory(), "stores", "201", "newDir");
            bool czyFolderIstnieje = Directory.Exists(sciezka);
            if (czyFolderIstnieje)
            {
                Console.WriteLine("Folder newDir już istnieje");
            }
            else
            {
                Directory.CreateDirectory(sciezka);
                Console.WriteLine("Folder został utworzony");
            }
            File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "greeting.txt"), "Witaj świecie!");

            sciezka = Path.Combine(Directory.GetCurrentDirectory(), "stores","salesTotalDir");
            if (Directory.Exists(sciezka))
                Console.WriteLine($"Folder salesTotalDir już istnieje");
            else
                Directory.CreateDirectory(sciezka);

            //Tworzenie pliku
            var sciezkaDoTotals = Path.Combine(sciezka, "totals.txt");
            File.WriteAllText(sciezkaDoTotals,String.Empty);

            var listaPlikowJson = szukanePliki(".json", Directory.GetCurrentDirectory());
            File.AppendAllLines(sciezkaDoTotals, listaPlikowJson);
            
            
        }
        static IEnumerable<string> szukanePliki(string extension, string folderName)
        {
            var listaPlikow = Directory.EnumerateFiles(Path.Combine(folderName, "stores"), "*", SearchOption.AllDirectories);
            List<string> listaPlikowJson = new List<string>(); 
            foreach(var pliki in listaPlikow)
            {
                var skroconaNazwa = new FileInfo(pliki);
                if(Path.GetExtension(pliki) == extension)
                    listaPlikowJson.Add(skroconaNazwa.FullName);
            }
            return listaPlikowJson;
        }
    }
}