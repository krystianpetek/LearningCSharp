using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace LiskovSubstitution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Weapon weapon = new Weapon();
            weapon.Shoot();
            weapon = new Sword();
            weapon.Shoot(); 
            weapon = new Bow();
            weapon.Shoot();

            Console.ReadKey();
        }
    }
}
