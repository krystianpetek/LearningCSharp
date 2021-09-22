using System;

namespace Rozdzial9_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // OPAKOWYWANIE, WYPAKOWYWANIE

            Angle angle = new Angle(25, 58, 23);

            // Przykład 1. Prosta operacja opakowywania.
            object objectAngle = angle; // Opakowywanie.
            Console.Write(((Angle)objectAngle).Degrees);

            // Przykład 2. Wypakowywanie wartości, modyfikowanie wypakowanej wartości i usuwanie jej.
            ((Angle)objectAngle).MoveTo(26, 58, 23);
            Console.Write(", " + ((Angle)objectAngle).Degrees);

            // Przykład 3. Opakowywanie wartości, modyfikowanie opakowanej wartości i usuwanie referencji do niej.
            ((IAngle)angle).MoveTo(26, 58, 23);
            Console.Write(", " + ((Angle)angle).Degrees);

            // Przykład 4. Bezpośrednie modyfikowanie opakowanej wartości.
            ((IAngle)objectAngle).MoveTo(26, 58, 23);
            Console.WriteLine(", " + ((Angle)objectAngle).Degrees);
        }
    }
    interface IAngle
    {
        void MoveTo(int degrees, int minutes, int seconds);
    }
    struct Angle : IAngle
    {
        public Angle(int degrees, int minutes, int seconds)
        {
            _Degrees = degrees;
            _Minutes = minutes;
            _Seconds = seconds;
        }
        public int Degrees { get { return _Degrees; } set { _Degrees = value; } }
        private int _Degrees;
        public int Minutes { get { return _Minutes; } set { _Minutes = value; } }
        private int _Minutes;
        public int Seconds { get { return _Seconds; } set { _Seconds = value; } }
        private int _Seconds;

        public void MoveTo(int degrees, int minutes, int seconds) // ten kod sprawia ze typ angle staje sie modyfikowalny, jest to niezgodne ze wskazówkami
        {
            Degrees = degrees;
            Minutes = minutes;
            Seconds = seconds;
        }
    }
}
