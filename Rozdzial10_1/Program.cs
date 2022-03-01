using System;
using System.Diagnostics;

namespace Rozdzial10_1
{
    public struct Longitude
    {
        public Longitude(double longitude)
        {
            _longitude = longitude;
        }
        public override string ToString()
        {
            return $"{_longitude}";
        }
        public double _longitude { get; set; }
    }

    public struct Latitude
    {
        public Latitude(double latitude)
        {
            _latitude = latitude;
        }
        public override string ToString()
        {
            return $"{_latitude}";
        }
        public double _latitude { get; set; }
    }

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
        
        // override EQUALS
        public override bool Equals(object obj)
        {
            // krok 1. sprawdzenie czy obiekt jest rozny od null
            if (obj is null)
            {
                return false;
            }
            // krok 2. sprawdzenie czy typy pasujądo siebie

            if (GetType() != obj.GetType())
            {
                return false;
            }
            // krok 3. wywolanie pomocniczej wersji metody equals dla konkretnego typu

            return Equals((Coordinate)obj);
        }

        public bool Equals(Coordinate obj)
        {
            // krok 4 sprawdzenie(w przypadku typow referencytjnych, czy obiekt jest różny od null)
            if (ReferenceEquals(obj, null))
                return false;

            // krok 5. opcjonalne sprawdzenie, czy skróty sa identyczne
            if (GetHashCode() != obj.GetHashCode())
                return false;

            // krok 6. sprawdzenie wyniku wywolania base.Equals, jesli w bazie klasowej przeloniejta jewst metoda equals()
            if (!base.Equals(obj))
                return false;

            // krok 7. sprawdzenie czy pola identyfikujhace maja rowną wartość
            return ((Longitude.Equals(obj.Longitude)) && (Latitude.Equals(obj.Latitude)));
        }

        // krok 8. przesloniecie metody gethashcode
    }


    internal class Program
    {
        private static void Main(string[] args)
        {
            Coordinate x = new Coordinate(new Longitude(200), new Latitude(100));
            Console.WriteLine(x);
            Trace.WriteLine(x);
            Trace.WriteLine(x.GetHashCode());

            ProductSerialNumber serialNumber1 = new ProductSerialNumber("PV", 1000, 09187234);
            ProductSerialNumber serialNumber2 = serialNumber1;
            ProductSerialNumber serialNumber3 = new ProductSerialNumber("PV", 1000, 09187234);

            if (!ProductSerialNumber.ReferenceEquals(serialNumber1, serialNumber2))
            {
                throw new Exception("serialNumber1 NIE zawiera tej samej referencji co serialNumber2");
            }
            else if (!serialNumber1.Equals(serialNumber2))
            {
                throw new Exception("serialNumber1 NIE ma wartości równej serialNumber2");
            }
            else
            {
                Console.WriteLine("serialNumber1 ma referencję równą z serialNumber2");
                Console.WriteLine("serialNumber1 ma wartość równą z serialNumber2");
            }

            if (ProductSerialNumber.ReferenceEquals(serialNumber1, serialNumber3))
            {
                throw new Exception("serialNumber1 MA referencje równą z serialNumber3");
            }
            else if (!serialNumber1.Equals(serialNumber3))
            {
                throw new Exception("serialNumber1 NIE ma wartości równej z serialNumber3");
            }
            Console.WriteLine("serialNumber1 ma wartość równą z serialNumber3");

            Coordinate coordinate2 = new Coordinate(new Longitude(200), new Latitude(100));
            // obiekty typu bezposredniego nigdy nie sa rowne ze wzgledu na referencje
            if (Coordinate.ReferenceEquals(coordinate2, coordinate2))
            {
                throw new Exception("coordinate1 jest rowna ze względu na referencje z coordinate1");
            }
            Console.WriteLine("coordinate NIE jest równa ze względu na referencje z samą sobą");

            Console.WriteLine(x.Equals(coordinate2));
            Console.WriteLine(x.Equals(x));
        }
    }

    public sealed class ProductSerialNumber
    {
        private string v1;
        private int v2;
        private int v3;

        public ProductSerialNumber(string v1, int v2, int v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;

            return Equals((ProductSerialNumber)obj);
        }
        public bool Equals(ProductSerialNumber obj)
        {
            if (obj.GetHashCode() != this.GetHashCode())
                return false;

            if (this.v1 == obj.v1 && this.v2 == obj.v2 && this.v3 == obj.v3)
            {
                return true;
            }
            return false;
        }
        public static bool operator==(ProductSerialNumber left, ProductSerialNumber right)
        {
            if (left is null)
                return right is null;
            return left.Equals(right);
        }
        public static bool operator!=(ProductSerialNumber left, ProductSerialNumber right)
        {
            return !(left == right);
        }
        public override int GetHashCode()
        {
            int hash = HashCode.Combine( this.v1.GetHashCode(), this.v2.GetHashCode(), this.v3.GetHashCode());
            return hash;
        }
    }
}