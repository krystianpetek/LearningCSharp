using System;
namespace ClassLibrary1
{
    public struct Latitude
    {
        public double latitude { get; set; }
        public int DecimalDegrees { get; private set; }

        public Latitude(double latitude)
        {
            this.latitude = latitude;
            DecimalDegrees = 0;
        }
        public static Latitude operator -(Latitude latitude)
        {
            return new Latitude(-latitude.DecimalDegrees);
        }
        public static Latitude operator +(Latitude latitude)
        {
            return latitude;
        }
    }
    public struct Longitude
    {
        public int DecimalDegrees { get; private set; }
        public double longitude { get; set; }
        public Longitude(double longitude)
        {
            this.longitude = longitude;
            DecimalDegrees = 0;
        }
        public static Longitude operator -(Longitude longitude)
        {
            return new Longitude(-longitude.DecimalDegrees);
        }
        public static Longitude operator +(Longitude longitude)
        {
            return longitude;
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