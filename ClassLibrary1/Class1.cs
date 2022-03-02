using System;
namespace ClassLibrary1
{

    public struct Latitude
    {
        public Latitude(int x, int y = 0)
        {
            X = x;
            Y = y;
            DecimalDegrees = default;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return X + " " + Y;
        }

        public static Latitude operator -(Latitude latitude)
        {
            return new Latitude(-latitude.X, -latitude.Y);
        }
        public static Latitude operator +(Latitude latitude)
        {
            return latitude;
        }

        // konwersja niejawna miedzy typami latitude i double, zle
        public Latitude(double decimalDegrees)
        {
            X = default;
            Y = default;
            DecimalDegrees = decimalDegrees;
        }
        public double DecimalDegrees { get; }
        public static implicit operator double(Latitude latitude)
        {
            return latitude.DecimalDegrees;
        }
        public static implicit operator Latitude(double degrees)
        {
            return new Latitude(degrees);
        }
    }


    public struct Longitude
    {
        public Longitude(int x, int y = 0)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return X + " " + Y;
        }

        public static Longitude operator -(Longitude longitude)
        {
            return new Longitude(-longitude.X, -longitude.Y);
        }
    }

    public struct Arc
    {
        public Arc(int x, int y)
        {
            LongitudeDifference = x;
            LatitudeDifference = y;
        }

        public int LongitudeDifference { get; private set; }
        public int LatitudeDifference { get; private set; }

        public static Arc operator -(Arc arc)
        {
            return new Arc(-arc.LongitudeDifference,
            -arc.LatitudeDifference);
        }
        public static Arc operator +(Arc arc)
        {
            return arc;
        }
    }
}