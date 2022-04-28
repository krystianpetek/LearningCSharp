using System;

namespace LiskovSubstitution
{
    internal class Program
    {
        private static void Main(string[] args)
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