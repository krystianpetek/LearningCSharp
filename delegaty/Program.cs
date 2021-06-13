using System;

namespace delegaty
{
    public class Rectangle
    {
        private double length;
        private double width;
        public Rectangle(double l, double w)
        {
            this.length = l;
            this.width = w;
        }
        public double GetArea()
        {
            return this.length * this.width;
        }
        static public void DisplayArea(Rectangle rect)
        {
            Console.WriteLine(rect.GetArea());
        }
        public double GetObw() => width + width + length + length;
        static public void DisplayPole(Rectangle rect)
        {
            Console.WriteLine(rect.GetObw());
        }
    }

    public class Kalk
    {
        private int X;

        public int Xprzyp
        {
            get { return X; }
            set { X = value; }
        }
        private int Y;

        public int Yprzyp
        {
            get { return Y; }
            set { Y = value; }
        }

        public Kalk(int x, int y)
        {
            Xprzyp = x;
            Yprzyp = y;
        }

        static public void Dodaj(Kalk BG)
        {
            Console.WriteLine($"Dodaj {BG.Xprzyp + BG.Yprzyp}");
        }
        static public void Odejmij(Kalk BG)
        {
            Console.WriteLine($"Oddaj {BG.Xprzyp - BG.Yprzyp}");
        }
        static public void Pomnoz(Kalk BG)
        {
            Console.WriteLine(BG.Xprzyp * BG.Yprzyp);
        }
        static public void Podziel(Kalk BG)
        {
            Console.WriteLine(BG.Xprzyp / BG.Yprzyp);
        }

    }
    class Program
    {
        public delegate void Oblicz(Kalk BG);


        static void Main()
        {
            Oblicz kalkulator;
            kalkulator = Kalk.Dodaj;
            kalkulator += Kalk.Odejmij;
            kalkulator += Kalk.Pomnoz;
            var obliczanie = new Kalk(5, 3);
            kalkulator(obliczanie);
        }

        public delegate void RectangleHandler(Rectangle rect);
        static void Main1(string[] args)
        {
            RectangleHandler handler;
            handler = Rectangle.DisplayArea;

            var z = new Rectangle(7, 5);

            handler(z);
            handler += Rectangle.DisplayPole;

            handler(z);

        }
    }
}



