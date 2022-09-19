using System;
namespace _13._NEWiOverride
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
    class Triangle : Polygon
    {
        public new void Draw()
        {
            Console.WriteLine("Drawing: Triangle");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Triangle T = new Triangle();
            T.Draw();
            Polygon p = T;
            p.Draw();

        }
    }
}
