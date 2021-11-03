using System;

namespace Zadanie05_02
{
    class Program
    {
        static void Main(string[] args)
        {
            RownanieKwadratowe trojmian = new RownanieKwadratowe();
            trojmian.czytaj_date();
            trojmian.przetworz_dane();
            trojmian.wyswietl_dane();
            Console.ReadKey();
        }
    }
    class RownanieKwadratowe
    {

        double a, b, c, delta, x1, x2;
        short liczbaPierwiastkow;

        public void czytaj_date()
        {
            Console.WriteLine("Program oblicza pierwiastki równania kwadratowego ax2 + bx + c = 0");
            Console.Write("Podaj a: ");
            a = double.Parse(Console.ReadLine());
            if(a == 0)
            {
                Console.WriteLine("Niedozwolona wartość współczynnika A"); 
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Console.Write("Podaj b: ");
                b = double.Parse(Console.ReadLine());
                Console.Write("Podaj c: ");
                c = double.Parse(Console.ReadLine());
            }
        }
        public void przetworz_dane()
        {
            delta = b * b - 4 * a * c;
            if (delta < 0) liczbaPierwiastkow = 0;
            if (delta == 0) liczbaPierwiastkow = 1;
            if (delta > 0) liczbaPierwiastkow = 2;

            switch(liczbaPierwiastkow)
            {
                case 1:
                    x1 = -b / (2 * a);
                    break;
                case 2:
                    x1 = (-b - Math.Sqrt(delta) )/ (2 * a);
                    x2 = (-b + Math.Sqrt(delta) )/ (2 * a);
                    break;
                default: 
                    break;
            }
        }
        public void wyswietl_dane()
        {
            Console.WriteLine($"Dla wprowadzonych liczb" +
                $"\na = {a}" +
                $"\nb = {b}" +
                $"\nc = {c}");
            switch(liczbaPierwiastkow)
            {
                case 0: 
                    Console.WriteLine("brak pierwiastków rzeczywistych");
                    break;
                case 1:
                    Console.WriteLine($"trójmian kwadratowy ma jeden pierwiastek podwójny" +
                        $"\nx1 = {x1}");
                    break;
                case 2:
                    Console.WriteLine("trójmian kwadratowy ma dwa pierwiastki" +
                        $"\nx1 = {x1}" +
                        $"\nx2 = {x2}");
                    break;
            }

        }
    }
}
