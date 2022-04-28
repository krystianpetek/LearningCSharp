namespace OpenClose2
{
    internal class CircleHouse : Facility
    {
        public double Radius { get; set; }

        public override double CalculateSurface()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}