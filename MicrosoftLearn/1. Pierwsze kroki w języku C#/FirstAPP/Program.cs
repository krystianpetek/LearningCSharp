using System;

namespace FirstAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Hello World!");
            Console.WriteLine('a'); //literal char
            Console.WriteLine(123); //literal int
            Console.WriteLine(12.3m); //literal decimal
            Console.WriteLine(true);
            Console.WriteLine(false);

            Console.WriteLine("123");
            Console.WriteLine(123);
            Console.WriteLine("true");
            Console.WriteLine(true);

            char userOption;
            int gameScore;
            decimal particlesPerMilion;
            bool processedCustomer;
            
            string imie = "Bob";
            int liczba = 3;
            decimal temperatura = 34.4m;
            Console.WriteLine($"Hello, {imie}! You have {liczba} in your inbox.  The temperature is {temperatura} celsius.");
            */
            /*
            Console.WriteLine("Hello\nWorld!");
            Console.WriteLine("Hello\tWorld!");

            Console.WriteLine("Hello \"World\"!");

            Console.WriteLine("c:\\source\\repos");
            
            Console.WriteLine("Generating invoices for customer \"ABC Corp\" ...\n");
            Console.WriteLine("Invoice: 1021\t\tComplete!");
            Console.WriteLine("Invoice: 1022\t\tComplete!");
            Console.WriteLine("\nOutput directory:\t");
            Console.WriteLine(@"c:\invokes");
            Console.WriteLine("\n"+@"     c:\source\repos
       (this is where your code goes)");
            
                            // Kon'nichiwa World
            Console.WriteLine("\u3053\u3093\u306B\u3061\u306F World!"); // nie działa tutaj
                            // Nihon no seikyū-sho o seisei suru ni wa:
            Console.Write("\n\n\u65e5\u672c\u306e\u8acb\u6c42\u66f8\u3092\u751f\u6210\u3059\u308b\u306b\u306f\uff1a\n\t");
            Console.WriteLine(@"c:\invoices\app.exe -j");
            */
            string projectName1 = "first-project";
            Console.WriteLine($@"C:\output\{projectName1}\data");
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            string projectName = "ACME";

            string russianMessage = "\u041f\u043e\u0441\u043c\u043e\u0442\u0440\u0435\u0442\u044c \u0440\u0443\u0441\u0441\u043a\u0438\u0439 \u0432\u044b\u0432\u043e\u0434";

            Console.WriteLine("View English output:\n\t\t" + $@"c:\Exercise\{projectName}\data.txt");
            Console.WriteLine($"\n{russianMessage}:\n\t\t" + $@"c:\Exercise\{projectName}\ru-RU\data.txt");
        }
    }
}
