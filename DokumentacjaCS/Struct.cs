namespace DokumentacjaCS
{
    internal struct Struct
    {
        public double X { get; }
        public double Y { get; }
        public Struct(double x, double y) => (X, Y) = (x, y);
    }
}
