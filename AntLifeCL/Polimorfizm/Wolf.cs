using System;

namespace SZAntLifeCL.Polimorfizm
{
    public class Wolf : Animal, IPet
    {
        public override void Eat()
        {
            throw new NotImplementedException();
        }

        public void GiveName()
        {
            throw new NotImplementedException();
        }
    }
}
