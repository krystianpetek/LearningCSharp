using System;

namespace ConsoleApp19_removeReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = "12345John Smith          5000  3  ";
            string updatedData = data.Remove(5, 20);
            Console.WriteLine(updatedData);

            string message = "This--is--ex-amp-le--da-ta";
            message = message.Replace("--", " ");
            message = message.Replace("-", "");
            Console.WriteLine(message);

            const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

            string quantity = "";
            string output = "";

            const string spanTag = "<span>";

            int poczatek = input.IndexOf(spanTag) + 6;
            int koniec = input.IndexOf("</span>");
            int dlugosc = koniec - poczatek;

            quantity += $"Quantity: {input.Substring(poczatek, dlugosc)}";

            int poczatek1 = input.IndexOf("<div>");
            int koniec1 = input.IndexOf("</div>") - 6;
            output += input;
            output = output.Remove(poczatek1, 5);
            output = output.Remove(koniec1,6);

            output = output.Replace("&trade;", "&reg;");

            Console.WriteLine(quantity);
            Console.WriteLine(output);
        }
    }
}
