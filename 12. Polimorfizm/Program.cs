using System;
using System.Collections.Generic;
namespace _12._Polimorfizm
{
    class Polygon
    {
        public virtual void Draw()
        {
            Console.WriteLine("Drawing: Polygon");
        }
    }
    class Rectangle : Polygon
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing: Rectangle");
        }
    }
    class Triangle:Polygon
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing: Triangle");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Polygon> polygons = new List<Polygon>();
            polygons.Add(new Polygon());
            polygons.Add(new Triangle());
            polygons.Add(new Rectangle());
        
            foreach (var x in polygons)
            {
                x.Draw();
            }   
        }
    }
}
