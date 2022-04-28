using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
