using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Zadanie06_05
{
    class Serializacja
    {
        double[] pomiary = { 10.17, 12.83, 11.78, 15.23, 11.08, 13.67 };
        public void zapisz_czytaj_dane()
        {
            Console.WriteLine("Wszystkie pomiary: ");
            for (int i = 0; i < pomiary.Length; i++)
            {
                Console.WriteLine(pomiary[i] + " ");
            }
            Stream StreamWrite = new FileStream("pomiary.dat", FileMode.Create);

        }
    }
}
