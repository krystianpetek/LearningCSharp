using System.Diagnostics;

namespace SZAntLifeCL.Polimorfizm
{
    public abstract class BazaBody
    {
        public virtual string Name { get; set; }
        public virtual float Longitude { get; set; }
        public virtual float Latitude { get; set; }
        public virtual void CreateBase(string name, float longitude, float latitude)
        {
            Debug.WriteLine("BB - Name: " + name);
            Debug.WriteLine("BB - Localization: " + longitude + " | " + latitude);
        }
        public abstract void CreateDefense(int val);

        public BazaBody()
        {

        }
        public BazaBody(string name, float longitude, float latitude)
        {
            Name = name;
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
