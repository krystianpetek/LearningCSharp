using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public interface ICallable
    {
        void Call(int number);
    }
    public interface ITextable
    {
        void Text(int number, string textMessage);
    }

    public interface IConnectable
    {

        void ConnectInternet();
    }

    public interface ITransferable
    {

        void TransferFiles(int blueID);
    }

    public interface INavigable
    {

        void UseGPS();
    }

    public class OldNokiaPhone : ICallable, ITextable
    {
        public void Call(int number)
        {
            throw new System.NotImplementedException();
        }

        public void Text(int number, string textMessage)
        {
            throw new System.NotImplementedException();
        }
    }

    public class AppleIPhone : ICallable, ITextable, ITransferable, INavigable, IConnectable
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
