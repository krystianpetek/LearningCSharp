namespace OpenClose2
{
    internal class TriangleHouse : Facility
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double CalculateSurface()
        {
            return ((1 / 2) * Width * Height);
        }
    }
}