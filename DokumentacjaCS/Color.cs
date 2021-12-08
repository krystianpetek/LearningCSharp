using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokumentacjaCS
{
    internal class Color
    {
        public static readonly Color Black = new Color(0, 0, 0);
        public static readonly Color White = new Color(255, 255, 255);
        public static readonly Color Red = new Color(255, 0, 0);
        public static readonly Color Green = new Color(0, 255, 0);
        public static readonly Color Blue = new Color(0, 0, 255);

        public byte R;
        public byte G;
        public byte B;

        public Color(byte r, byte g, byte b) => (R, G, B) = (r, g, b);

        public override string ToString()
        {
            return $"R: {R}\nG: {G}\nB: {B}";
        }
        static void SwapColor( ref Color x, ref Color y)
        {
            Color temp = x;
            x = y;
            y = temp;
        }
        public static void SwapColorExample()
        {
            Color x = Color.Black;
            Color y = Color.Blue;
            SwapColor(ref x, ref y);
            Console.WriteLine(x);
            Console.WriteLine(y);
        }

        static Color OutColor (out Color x)
        {
            x = new Color(0, 0, 0);
            x.R = 255;
            x.G = 255;
            x.B = 255;
            return x;
        }
        
    }
}
