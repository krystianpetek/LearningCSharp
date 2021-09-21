using System;

namespace Rozdzial9
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new Angle(90, 10, 10);
            var z = x.Move(10, 10, 10);
            Console.WriteLine(z.ToString());
        }
    }
    // Do deklarowania typów bezpośrednich służy słowo kluczowe struct.
    readonly struct Angle
    {
        public Angle(int degrees, int minutes, int seconds)
        {
            Degrees = degrees;
            Minutes = minutes;
            Seconds = seconds;
        }
        public int Degrees { get; }
        public int Minutes { get; }
        public int Seconds { get; }
        
        readonly public Angle Move(int degrees, int minutes, int seconds)
        {
            return new Angle(Degrees + degrees, Minutes + minutes, Seconds + seconds);
        }
        public override string ToString()
        {
            return $"{Degrees} {Minutes} {Seconds}";
        }
    }

    // Deklaracja klasy, czyli typu referencyjnego.
    // Użycie w deklaracji słowa kluczowego struct spowodowałoby powstanie typu bezpośredniego zajmującego więcej niż 16 bajtów.
    class Coordinate
    {
        public Angle Longitude { get; set; }
        public Angle Latitude { get; set; }
    }

}
