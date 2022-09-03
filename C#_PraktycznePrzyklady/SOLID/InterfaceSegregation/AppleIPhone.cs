namespace InterfaceSegregation
{
    public class AppleIPhone : ITextable, ICallable, IConnectable, ITransferable, INavigable
    {
        public void Call(int number)
        {
            throw new System.NotImplementedException();
        }

        public void ConnectInternet()
        {
            throw new System.NotImplementedException();
        }

        public void Text(int number, string textMessage)
        {
            throw new System.NotImplementedException();
        }

        public void TransferFiles(int blueID)
        {
            throw new System.NotImplementedException();
        }

        public void UseGPS()
        {
            throw new System.NotImplementedException();
        }
    }
}
