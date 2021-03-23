using System;

namespace FourthAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Random random = new Random();
            int dayUntilExpiration = random.Next(12);
            int discountPercentage = 0;

            if(dayUntilExpiration == 0)
            {
                Console.WriteLine("Twoja subskrypcja wygasła");
            }
            else if(dayUntilExpiration == 1)
            {
                Console.WriteLine("Twoja subskrypcja wygaśnie za jeden dzień!");
                discountPercentage = 20;
            }
            else if(dayUntilExpiration <=5)
            {
                Console.WriteLine($"Twoja subskrypcja wygasa za {dayUntilExpiration} dni");
                discountPercentage = 10;
            }
            else if (dayUntilExpiration <= 10)
            {   
                Console.WriteLine("Twoja subskrypcja wkrótce wygaśnie. Odnów teraz!");
            }
            if(discountPercentage > 0)
            {
                Console.WriteLine($"Odnów teraz i zaoszczędź {discountPercentage}%!");
            }
        }
    }
}
