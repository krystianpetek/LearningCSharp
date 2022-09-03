namespace DependencyInversion
{
    internal class EmailSender : IDoAnAction
    {
        public void DoAction(string message)
        {
            Console.WriteLine("wysłano email");
        }
    }
}