using System;

namespace AntLifeCL.Polimorfizm
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
