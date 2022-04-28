using System;

namespace LiskovSubstitution
{
    internal class Sword : Weapon
    {
        public override void Shoot()
        {
            base.Shoot();
            Console.WriteLine("Hit hit!");
        }
    }
}