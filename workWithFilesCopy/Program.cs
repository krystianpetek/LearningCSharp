using System;
using System.Collections.Generic;
using System.IO;

namespace workWithFilesCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            var salesFiles = FindFiles("../../../stores");

            foreach(var file in salesFiles)
            {
                Console.WriteLine(file);
            }
        }

        static IEnumerable<string> FindFiles(string folderName)
        {
            List<string> salesFiles = new List<string>();
            var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

            foreach(var file in foundFiles)
            {
                if (file.EndsWith("sales.json"))
                {
                    salesFiles.Add(file);
                }
            }
            return salesFiles;
        }
    }

}
