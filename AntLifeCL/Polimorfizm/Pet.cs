using System;

namespace AntLifeCL.Polimorfizm
{
    internal class Pet : Animal, IPet
    {
        public override void Eat()
        {
            throw new NotImplementedException();
        }

        public virtual void GiveName() { }
    }
}
