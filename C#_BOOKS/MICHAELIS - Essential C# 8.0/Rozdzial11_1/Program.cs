using System;
using System.ComponentModel;

namespace Rozdzial11_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Przechwytywanie wyjątku
            try
            {
                throw new InvalidOperationException("Dowolny wyjątek");
            }
            catch (Win32Exception exception)
            when (exception.NativeErrorCode == 42)
            {
                // Obsługa wyjątku typu Win32Exception, gdy
                // właściwość NativeErrorCode ma wartość 42.
            }
            catch (ArgumentException exception)
            {
                // Obsługa wyjątków typu ArgumentException.
            }
            catch (InvalidOperationException exception)
            {
                bool exceptionHandled = false;
                // Obsługa wyjątków typu InvalidOperationException.
                if (!exceptionHandled)
                {
                    // Unikaj zgłaszania w instrukcjach warunkowych!!!!
                    throw;
                }
            }
            catch (Exception exception)
            {
                // Obsługa wyjątków typu Exception.
            }
            finally
            {
                // Tu umieść kod porządkujący zasoby. Ten kod
                // jest wykonywany niezależnie od tego, czy wystąpił wyjątek.
            }
        }
    }

    public sealed class TextNumberParser
    {
        public static int Parse(string textDigit)
        {
            string[] digitTexts = { "zero", "jeden", "dwa", "trzy", "cztery", "pięć", "sześć", "siedem", "osiem", "dziewięć" };
            int result = Array.IndexOf(digitTexts, textDigit ?? throw new ArgumentNullException(nameof(textDigit).ToLower()));
            if (result < 0)
            {
                throw new ArgumentException("Argument nie reprezentuje cyfry", nameof(textDigit));
            }
            return result;
        }
    }
}