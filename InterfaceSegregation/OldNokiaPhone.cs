using System;

namespace InterfaceSegregation
{
    class OldNokiaPhone : ICallable, ITextable
    {
        public void Call(int number)
        {
            throw new NotImplementedException();
        }

        public void Text(int number, string textMessage)
        {
            throw new NotImplementedException();
        }
    }
}
