namespace Prostokaty
{
    internal class Rectangle
    {
        public int Ax { get; }
        public int Ay { get; }
        public int Bx { get; }
        public int By { get; }

        public Rectangle(int ax, int ay, int bx, int by)
        {
            if (ax < bx)
            {
                Ax = ax;
                Bx = bx;
            }
            else
            {
                Ax = bx;
                Bx = ax;
            }

            if (ay < by)
            {
                Ay = ay;
                By = by;
            }
            else
            {
                Ay = by;
                By = ay;
            }
        }

        public Point A => new Point(Ax, Ay);
        public Point B => new Point(Ax, By);
        public Point C => new Point(Bx, By);
        public Point D => new Point(Bx, Ay);

        public override string ToString()
        {
            return $"Prostokąt o wspołrzędnych: \nA - {Ax},{Ay}\nB - {Ax},{By}\nC - {Bx},{By}\nD - {Bx},{Ay}";
        }

        public static void CheckRectangle(Rectangle rect1, Rectangle rect2)
        {
        }
    }
}