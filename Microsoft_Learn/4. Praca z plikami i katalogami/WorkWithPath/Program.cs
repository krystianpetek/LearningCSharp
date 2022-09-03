using System;
using System.IO;

namespace WorkWithPath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            Directory.SetCurrentDirectory("../../../stores/201");
            Console.WriteLine(Directory.GetCurrentDirectory());
            Directory.SetCurrentDirectory("../../");


            Console.WriteLine();
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Console.WriteLine(docPath);
            string sciezkaZSeparatorem = $"stores{Path.DirectorySeparatorChar}201";
            Console.WriteLine(sciezkaZSeparatorem);
            string sciezkaCombine = Path.Combine("stores", "201");
            Console.WriteLine(sciezkaCombine);

            Console.WriteLine();
            foreach (var item in Directory.EnumerateFiles("stores"))
            {
                var rozszerzenie = Path.GetExtension(item);
                Console.WriteLine("Nazwa pliku: "+item + "\nRozszerzenie: " + rozszerzenie+"\n");
            }

            foreach(var item in Directory.EnumerateFiles("stores","*",SearchOption.AllDirectories))
            {
                FileInfo informacjaOPliku = new FileInfo(item);
                Console.WriteLine($"" +
                    $"Full Name: {informacjaOPliku.FullName}{Environment.NewLine}" +
                    $"Directory: {informacjaOPliku.Directory}{Environment.NewLine}" +
                    $"Extension: {informacjaOPliku.Extension}{Environment.NewLine}" +
                    $"Creation date: {informacjaOPliku.CreationTime}");
            }

            Console.WriteLine();
            var aktualnyFolder = Directory.GetCurrentDirectory();
            Console.WriteLine(aktualnyFolder);
            var aktualnyFolderMod = Path.Combine(aktualnyFolder, "stores");
            Console.WriteLine(aktualnyFolderMod);

            var wszystkiePlikiJson = Directory.EnumerateFiles(aktualnyFolderMod,"*.json",SearchOption.AllDirectories);
            foreach(var x in wszystkiePlikiJson)
                Console.WriteLine(x);

            Console.WriteLine();
            var wszystkiePliki = Directory.EnumerateFiles(aktualnyFolderMod, "*", SearchOption.AllDirectories);
            foreach(var x in wszystkiePliki)
            {
                if (Path.GetExtension(x) == ".json")
                {
                    Console.WriteLine(x);
                }
            }
        }

    }
}
