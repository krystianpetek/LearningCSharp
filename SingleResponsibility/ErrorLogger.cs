namespace SingleResponsibility
{
    internal class ErrorLogger
    {
        public int ID { get; set; }
        public string PathToLogFile { get; set; }
        public string ExceptionMessage { get; set; }

        public void WriteToErrorLog(string path, string message)
        {
            File.WriteAllText(path, message);
        }
    }
}