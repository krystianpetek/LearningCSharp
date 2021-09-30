using System;
using System.IO;

namespace Rozdzial9_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"enumtest.txt";
            FileInfo file = new FileInfo(fileName);
            if (!(File.Exists(fileName)))
            {
                file.Open(FileMode.Create).Close();
            }
            FileAttributes startingAttributes = file.Attributes;
            file.Attributes = FileAttributes.Hidden | FileAttributes.ReadOnly;
            Console.WriteLine("\"{0}\" wyświetlane jako \"{1}\"",file.Attributes.ToString().Replace(","," |"),file.Attributes);
            FileAttributes attributes = (FileAttributes) Enum.Parse(typeof(FileAttributes), file.Attributes.ToString());
            Console.WriteLine(attributes);
            File.SetAttributes(fileName, startingAttributes);
            file.Delete();
        }
    }
}
