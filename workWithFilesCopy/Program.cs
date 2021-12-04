using System;
using System.Collections.Generic;
using System.IO;


namespace workWithFilesCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            //var salesFiles = FindFiles("../../../stores");
            var salesFiles = FindFiles("stores");

            foreach (var file in salesFiles)
            {
                Console.WriteLine(file);
            }
            Console.WriteLine();

            char Z = Path.DirectorySeparatorChar;
            Directory.SetCurrentDirectory($"stores{Z}201{Z}sales");
            string[] x = Directory.GetCurrentDirectory().Split(Z);
            Console.WriteLine(String.Join(Z,x));

            // KATALOGI SPECJALNE
            string docuPath = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            Console.WriteLine(docuPath);
            Console.WriteLine($"stores{Z}201");
            Console.WriteLine(Path.Combine(x));

            // rozszerzenie
            Console.WriteLine();
            var a = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),"*.mp4",SearchOption.AllDirectories);

            IEnumerator<string> f = a.GetEnumerator();

            while (f.MoveNext())
            {
                //Console.WriteLine(f.Current);
                FileInfo file = new FileInfo(f.Current);
                Console.Write($"{Environment.NewLine}Name: {file.Name + Environment.NewLine }Directory: {file.Directory+Environment.NewLine}Extension: {file.Extension+Environment.NewLine}Create Date: {file.CreationTime+Environment.NewLine}");
            }            
        }

        static IEnumerable<string> FindFiles(string folderName )
        {
            List<string> salesFiles = new List<string>();
            var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

            foreach (var file in foundFiles)
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
