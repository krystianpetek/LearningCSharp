namespace DependencyInversion
{
    internal class SMSSender : IDoAnAction
    {
        public void DoAction(string message)
        {
            Console.WriteLine("wysłano sms");
        }
    }
}