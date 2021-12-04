using System;
using System.Collections.Generic;
using System.IO;
namespace workWithPath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var currentDir = Directory.GetCurrentDirectory();
            var storesDir = Path.Combine(currentDir, "stores");
            var salesFiles = FindFiles(storesDir);
            foreach(var item in salesFiles)
                Console.WriteLine(item);

            Console.WriteLine(Environment.NewLine + currentDir);
            var probablyNewDir = Path.Combine(Directory.GetCurrentDirectory(), "stores", "201", "newDir");
            bool doesDirectoryExist = Directory.Exists(probablyNewDir);
            if (!doesDirectoryExist)
                Directory.CreateDirectory(probablyNewDir);

            var probablyNewFile = Path.Combine(probablyNewDir, "newFile.txt");
            if (!File.Exists(probablyNewDir))
            File.WriteAllText(probablyNewFile, "Krystian");
        }

        static IEnumerable<string> FindFiles(string name)
        {
            //List<string> salesFiles = new List<string>();
            var enumDir = Directory.EnumerateFiles(name, "*.json", SearchOption.AllDirectories);
            foreach (var file in enumDir)
            {
                yield return file;
                //salesFiles.Add(file);
            }
            //return salesFiles;
                
        }
    }
}
