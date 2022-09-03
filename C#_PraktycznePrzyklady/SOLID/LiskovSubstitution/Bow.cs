using System;

namespace LiskovSubstitution
{
    internal class Bow : Weapon
    {
        public override void Shoot()
        {
            base.Shoot();
            Console.WriteLine("Fire aim!");
        }
    }
}