namespace Rozdzial18_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Invoking reflection using dynamic
            dynamic data = "Hello!  My name is Inigo Montoya";
            Console.WriteLine(data);
            data = (double)data.Length;

            data = data * 3.5 + 28.6;
            if (data == 2.4 + 112 + 26.2)
            {
                Console.WriteLine($"{data} makes for a long triathlon.");
            }
            else
            {
                data.NonExistentMethodCallStillCompiles();
            }
            #endregion
        }
    }
}
