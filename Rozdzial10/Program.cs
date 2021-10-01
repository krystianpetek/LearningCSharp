using System;

namespace Rozdzial10
{
    // przesłanianie składowych z klasy object

    // ToString()
    public struct Coordinate
    {
        public Coordinate(Longitude longitude, Latitude latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
        public Longitude Longitude { get; }
        public Latitude Latitude { get; }
        public override string ToString() => $"{Longitude} {Latitude}";
        public override int GetHashCode() => HashCode.Combine(Longitude.GetHashCode(), Latitude.GetHashCode());
    }
    public struct Longitude {
        public Longitude(double Long)
        {
            this.Long = Long;
        }
        public override string ToString()
        {
            return $"{Long}";
        }
        public double Long { get; set; }
    }
    public struct Latitude { 
        public Latitude(double Lati)
        {
            this.Lati = Lati;
        }
        public override string ToString()
        {
            return $"{Lati}";
        }
        public double Lati { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Coordinate x = new Coordinate(new Longitude(200),new Latitude(100));
            Console.WriteLine( x.ToString() );
        }
    }
    // 412
}

