using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
