using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Zadanie_12._03
{
    internal class WalidatorLiczb: ValidationRule
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double sprawdzanaLiczba = 0;
            regexowa();
            try
            {
                if (value.ToString().Length > 0)
                    sprawdzanaLiczba = Convert.ToDouble(value.ToString());
            }
            catch (FormatException exception)
            {
                return new ValidationResult(false, "Niedozwolone znaki -" + exception.Message);
            }

            if (sprawdzanaLiczba < Min || sprawdzanaLiczba > Max)
                return new ValidationResult(false, "Wprowadź liczbę z zakresu: " + Min + " - " + Max);
            else
                return new ValidationResult(true,null);
        }

        public void regexowa()
        {
            string d = "KP23";
            Regex regex = new Regex("[A-Z][A-Z][0-9][0-9]");
            var g = regex.Match(d);

            string pesel = "98100603692";
            Regex peselRegex = new Regex("^[0-9]{11}$");
            var c = peselRegex.Match(pesel);
            
        }

    }
}
