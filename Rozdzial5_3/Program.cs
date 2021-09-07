using System;

namespace Rozdzial5_3
{
    class Program
    {
        static int Main(string[] args)
        {
            //Zamiana parametrow wiersza polecen na cyfry
            
            if (args.Length == 0)
            {
                Console.WriteLine(
                "'_' oznacza, że nie podano standardowego przycisku telefonu");
                return 1;
            }
            // Krystian Petek Koziniec 2 34-106 Mucharz
            foreach (string word in args)
            {
                foreach(char character in word)
                {
                    if(TryGetPhoneButton(character, out char button))
                    {
                        Console.Write(button);
                    }
                    else
                    {
                        Console.WriteLine("_");
                    }
                }
                Console.Write(" ");
            }
            return 0;

            static bool TryGetPhoneButton(char znak, out char button)
            {
                bool success = true;
                switch(char.ToLower(znak))
                {
                    case '1':
                        button = '1';
                        break;
                    case '2': case 'a': case 'b': case 'c':
                        button = '2';
                        break;
                    case '3': case 'd': case 'e': case 'f':
                        button = '3';
                        break;
                    case '4': case 'g': case 'h': case 'i':
                        button = '4';
                        break;
                    case '5': case 'j': case 'k': case 'l':
                        button = '5';
                        break;
                    case '6': case 'm': case 'n': case 'o':
                        button = '6';
                        break;
                    case '7': case 'p': case 'q': case 'r': case 's':
                        button = '7';
                        break;
                    case '8': case 't': case 'u': case 'v':
                        button = '8';
                        break;
                    case '9': case 'w': case 'x': case 'y': case 'z':
                        button = '9';
                        break;
                    case '0':
                        button = '0';
                        break;
                    case '-':
                        button = '-';
                        break;
                    default:
                        button = '_';
                        success = false;
                        break;
                }
                return success;
            }
        }
    }
}
