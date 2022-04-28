namespace OpenClose2
{
    internal class SquareHouse : Facility
    {
        public double Width { get; set; }

        public override double CalculateSurface()
        {
            return Math.Pow(Width, 2);
        }
    }
}