using System;

namespace Rozdzial10_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ARC = new Arc(new Longitude(1),new Latitude(10));
            var COORDINATE = new Coordinate(new Longitude(3), new Latitude(30));
                }
    }
    // przeslanianie operatora == i !=
    public sealed class ProductSerialNumber
    {
        public static bool operator ==(ProductSerialNumber leftHandSide, ProductSerialNumber rightHandSide)
        {
            if(leftHandSide is null)
            {
                return rightHandSide is null;
            }
            return leftHandSide.Equals(rightHandSide);
        }
        public static bool operator !=(ProductSerialNumber leftHandSide, ProductSerialNumber rightHandSide)
        {
            return !(leftHandSide == rightHandSide);
        }
    }
    public struct Latitude
    {
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
    public struct Longitude
    {
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

    // dodawanie operatora +
    struct Arc
    {
        public Arc(Longitude longitudeDifference, Latitude latitudeDifference)
        {
            LongitudeDifference = longitudeDifference;
            LatitudeDifference = latitudeDifference;
        }
        public Longitude LongitudeDifference { get; }
        public Latitude LatitudeDifference { get; }
    }
    struct Coordinate
    {
        private Latitude Latitude { get; }
        private Longitude Longitude { get; }    
        public Coordinate(Longitude x, Latitude y)
        {
            Longitude = x;
            Latitude = y;
        }
        public static Coordinate operator +(Coordinate source, Arc arc)
        {
            Coordinate result = new Coordinate(
                new Longitude(
                    source.Longitude.Long + arc.LongitudeDifference.Long),
                new Latitude(
                    source.Latitude.Lati + arc.LatitudeDifference.Lati));
            return result;
            
        }
        // 421 cośjeest zle
    }
}
