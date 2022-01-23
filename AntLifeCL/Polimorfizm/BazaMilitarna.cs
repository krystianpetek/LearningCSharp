using System.Diagnostics;

namespace SZAntLifeCL.Polimorfizm
{
    public class BazaMilitarna : BazaBody
    {
        public BazaMilitarna() { }
        public BazaMilitarna(int wallResistance)
        {
            WallResistance = wallResistance;
        }

        public BazaMilitarna(string name, float longitude, float latitude) : base(name, longitude, latitude)
        {
            WallResistance = 0;
        }

        public BazaMilitarna(string name, float longitude, float latitude, int wallResistance) : base(name, longitude, latitude)
        {
            WallResistance = wallResistance;
        }

        public int WallResistance { get; set; }
        public override void CreateBase(string name, float longitude, float latitude)
        {
            base.CreateBase(name, longitude, latitude);
            if (WallResistance != 0)
                CreateDefense(WallResistance);

        }
        public virtual void CreateBase(string name, float Longitude, float Latitude, int WallResistance)
        {
            base.CreateBase(name, Longitude, Latitude);
            CreateDefense(WallResistance);
        }

        public override void CreateDefense(int val)
        {
            Debug.WriteLine("BM - defence value is set to: " + val);
        }
    }
}
