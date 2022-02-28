namespace Rozdzial10_02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Coordinate coordinate1 = new Coordinate(new Longitude(48, 52), new Latitude(-2, -20));
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

    public struct Coordinate
    {
        public Latitude latitude { get; }
        public Longitude longitude { get; }

        public Coordinate(Longitude x, Latitude y)
        {
            longitude = x;
            latitude = y;
        }

        public static Coordinate operator +(Coordinate source, Arc arc)
        {
            Coordinate result = new Coordinate(new Longitude(source.longitude.X + arc.LongitudeDifference.X, source.longitude.Y + arc.LongitudeDifference.Y), new Latitude(source.latitude.X, arc.LatitudeDifference.X));
            return result;
        }
        public override bool Equals(object obj)
        {
            if(obj is null)
                return false;

            if (this.GetType() != obj.GetType())
                return false;

            return Equals((Coordinate)obj);
        }
        public bool Equals(Coordinate? coordinate) => (latitude, longitude).Equals((coordinate?.longitude, coordinate?.latitude));

        public static bool operator ==(Coordinate left, Coordinate right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Coordinate left, Coordinate right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return (longitude.X,longitude.Y,latitude.X,latitude.Y).GetHashCode();
        }
    }

    // dodawanie operatora +
    public struct Arc
    {
        public Arc(Longitude longitudeDifference, Latitude latitudeDifference)
        {
            LongitudeDifference = longitudeDifference;
            LatitudeDifference = latitudeDifference;
        }

        public Longitude LongitudeDifference { get; }
        public Latitude LatitudeDifference { get; }
    }

    // przeslanianie operatora == i !=
    public sealed class ProductSerialNumber
    {
        public static bool operator ==(ProductSerialNumber leftHandSide, ProductSerialNumber rightHandSide)
        {
            if (leftHandSide is null)
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

    //421
}