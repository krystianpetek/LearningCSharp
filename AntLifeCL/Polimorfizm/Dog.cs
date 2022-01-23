using System;

namespace SZAntLifeCL.Polimorfizm
{
    public class Dog : Wolf, IPet, ICloth, IReactOnSound
    {
        public override void Eat() // z wilfa wpierdala
        {
            base.Eat();
        }

        public void GiveCloth()
        {
            throw new NotImplementedException();
        }

        public void GiveName()
        {
            throw new NotImplementedException();
        }

        public void RunToSoundSource()
        {
            throw new NotImplementedException();
        }
    }
}
