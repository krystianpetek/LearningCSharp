namespace DokumentacjaCS
{
    internal class Point
    {
        public int X { get; }
        public int Y { get; }
        public Point(int x, int y) => (X, Y) = (x, y);
        public override string ToString()
        {
            return $"X: {X}\nY: {Y}";
        }
    }
}
