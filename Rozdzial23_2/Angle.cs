namespace Rozdzial23_2
{
    internal struct Angle
    {
        private readonly int v1;
        private readonly int v2;
        private readonly int v3;

        public Angle(int v1, int v2, int v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        public int Seconds { get; internal set; }
        public int Minutes { get; internal set; }
        public char[] Hours { get; internal set; }
    }
}