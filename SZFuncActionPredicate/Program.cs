using System;

namespace SZFuncActionPredicate
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CalculateAreaPointer cpointer = new CalculateAreaPointer( // delegat funkcja anonimowa
                delegate (double r)
                {
                    return Math.PI * r * r;
                });
            double area = cpointer.Invoke(20);
            Console.WriteLine(area);

            cpointer = r => Math.PI * r * r; // lambda
            area = cpointer.Invoke(20);
            Console.WriteLine(area);

            Func<double, double> cpointerNew = r => Math.PI * r * r; // skrocenie delegatu z uzyciem lambdy
            area = cpointer(20);
            Console.WriteLine(area);

            Action<string> myAction = s => Console.WriteLine(s);// action nie zwraca niczego, skrot do tworzenia void delegatu
            myAction.Invoke("To ja");

            Predicate<string> CheckIfStringIsGreaterThan5 = g => g.Length > 5; // nietypowy delegat, ktory zwraca prawda lub fałsz
            bool wynik = CheckIfStringIsGreaterThan5("Ala ma kota");
            Console.WriteLine(wynik);
            wynik = CheckIfStringIsGreaterThan5("Ala");
            Console.WriteLine(wynik);
        }

        delegate double CalculateAreaPointer(double r);

        //static CalculateAreaPointer cpointer = CalculateArea;
        //static double CalculateArea(double r)
        //{
        //    return Math.PI * r * r;
        //}
    }
}
