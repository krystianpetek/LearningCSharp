using System;

namespace Rozdzial10_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Coordinate coordinate1 = new Coordinate(new Longitude(48, 52), new Latitude(-2, -20));
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
        public Latitude(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
    public struct Longitude
    {
        public Longitude(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
    struct Coordinate
    {
        public Latitude Latitude { get; }
        public Longitude Longitude { get; }
        public Coordinate(Longitude x, Latitude y)
        {
            Longitude = x;
            Latitude = y;
        }

        public static Coordinate operator +(Coordinate source, Arc arc)
        {
            Coordinate result = new Coordinate(new Longitude(source.Longitude.X+arc.LongitudeDifference.X,source.Longitude.Y+arc.LongitudeDifference.Y), new Latitude(source.Latitude.X,arc.LatitudeDifference.X));
            return result;


        }
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
}
