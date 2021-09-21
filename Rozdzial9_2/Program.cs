using System;

namespace Rozdzial9_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    struct Angle
    {
        public Angle(int degrees, int minutes, int seconds)
        {
            _Degrees = degrees;
            _Minutes = minutes;
            _Seconds = seconds;
        }
        public int Degrees { get { return _Degrees; } }
        readonly private int _Degrees;
        public int Minutes { get { return _Minutes; } }
        readonly private int _Minutes;
        public int Seconds { get { return _Seconds; } }
        readonly private int _Seconds;
    }
}
