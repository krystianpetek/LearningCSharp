using System;

namespace LiskovSubstitution
{
    public class Weapon
    {
        public string Name { get; set; }
        public virtual void Shoot()
        {
            Console.WriteLine("Use Your weapon to shot or hit.");
        }
    }
}
