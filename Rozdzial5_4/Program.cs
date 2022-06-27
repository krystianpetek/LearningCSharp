using System;

namespace Rozdzial5_4
{
    internal class Program
    {
        // ZWRACANIE PRZEZ REFERENCJE
        public static ref byte FindFirstRedEyePixel(byte[] image)
        {
            // zaawansowane wykrywanie cech obrazu, mozliwe z użyciem uczenia maszynowego
            for (int counter = 0; counter < image.Length; counter++)
            {
                if (image[counter] == (byte)ConsoleColor.Red)
                {
                    return ref image[counter];
                }
            }
            throw new InvalidOperationException("Nie występują czerwone piksele.");
        }

        public static void Main(string[] args)
        {
            byte[] image = new byte[254];
            // wczytywanie obrazu
            int index = new Random().Next(0, image.Length - 1);
            image[index] = (byte)ConsoleColor.Red;
            Console.WriteLine($"image[{index}]={(ConsoleColor)image[index]}");

            // Pobieranie referencji do pierwszego czerwonego pixela
            ref byte redPixel = ref FindFirstRedEyePixel(image);
            redPixel = (byte)ConsoleColor.Black;
            Console.WriteLine($"image[{index}]={(ConsoleColor)image[redPixel]}");
        }
    }
}