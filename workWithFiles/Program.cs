using System;
using System.Collections.Generic;
using System.IO;
namespace workWithFiles
{
    class Program
    {
        static void Main(string[] args)
        {

            IEnumerable<string> listOfDirectories = Directory.EnumerateDirectories("stores");

            foreach (var dir in listOfDirectories)
                Console.WriteLine(dir);

            Console.WriteLine();
            IEnumerable<string> files = Directory.EnumerateFiles("stores");
            foreach (var file in files)
                Console.WriteLine(file);

            Console.WriteLine();
            IEnumerable<string> allFilesInAllFolders = Directory.EnumerateFiles("stores", "*.txt", SearchOption.AllDirectories);
            foreach (var fileTxt in allFilesInAllFolders)
                Console.WriteLine(fileTxt);
        }
    }
}
