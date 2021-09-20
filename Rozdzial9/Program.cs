using System;

namespace Rozdzial9
{
    class Program
    {
        static void Main(string[] args)
        {


        }
    }
    // Do deklarowania typów bezpośrednich służy słowo kluczowe struct.
    struct Angle
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
        
        public Angle Move(int degrees, int minutes, int seconds)
        {
            return new Angle(Degrees + degrees, Minutes + minutes, Seconds + seconds);
        }
    }

    // Deklaracja klasy, czyli typu referencyjnego.
    // Użycie w deklaracji słowa kluczowego struct spowodowałoby powstanie typu bezpośredniego zajmującego więcej niż 16 bajtów.
    class Coordinate
    {
        public Angle Longitude { get; set; }
        public Angle Latitude { get; set; }
    }
    //384
}
