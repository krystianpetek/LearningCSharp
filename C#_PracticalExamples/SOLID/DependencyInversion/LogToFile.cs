namespace DependencyInversion
{
    internal class LogToFile
    {
        private IDoAnAction _action;

        public LogToFile(IDoAnAction action)
        {
            _action = action;
        }

        public void Notify(string message)
        {
            Console.WriteLine("Zapis logu do pliku");
            if (_action == null)
            {
                _action = new SMSSender();
            }
            _action.DoAction(message);
        }
    }
}