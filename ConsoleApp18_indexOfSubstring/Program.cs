using System;

namespace ConsoleApp18_indexOfSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "Find what is (inside the parentheses)";
            int openingPosition = message.IndexOf('(');
            int closingPosition = message.IndexOf(')');
            //Console.WriteLine(openingPosition);
            //Console.WriteLine(closingPosition);
            openingPosition += 1;
            int length = closingPosition - openingPosition;
            Console.WriteLine(message.Substring(openingPosition, length));

            //

            string message2 = "What is the value <span>between the tags</span>?";
            int openingPosition2 = message2.IndexOf("<span>");
            int closingPosition2 = message2.IndexOf("</span>");
            openingPosition2 += 6;
            int length2 = closingPosition2 - openingPosition2;
            Console.WriteLine(message2.Substring(openingPosition2, length2));

            //

            string message3 = "What is the value <span>between the tags</span>?";
            const string openSpan = "<span>";
            const string closeSpan = "</span>";
            int openingPosition3 = message3.IndexOf(openSpan);
            int closingPosition3 = message3.IndexOf(closeSpan);
            openingPosition3 += openSpan.Length;
            int length3 = closingPosition3 - openingPosition3;
            Console.WriteLine(message3.Substring(openingPosition3, length3));

            //

            string message4 = "(What if) I am (only interested) in the last (set of parentheses)?";
            int openingPosition4 = message4.LastIndexOf('(');
            openingPosition4 += 1;
            int closingPosition4 = message4.LastIndexOf(')');
            int length4 = closingPosition4 - openingPosition4;
            Console.WriteLine(message4.Substring(openingPosition4, length4));

            //

            Console.WriteLine();
            string message5 = "(What if) there are (more than) one (set of parentheses)?";
            while (true)
            {
                int openingPosition5 = message5.IndexOf('(');
                if (openingPosition5 == -1) break;

                openingPosition5 += 1;
                int closingPosition5 = message5.IndexOf(')');
                int length5 = closingPosition5 - openingPosition5;
                Console.WriteLine(message5.Substring(openingPosition5, length5));
                message5 = message5.Substring(closingPosition5+1);
            
            }

            //

            Console.WriteLine();
            string message6 = "(What if) I have [different symbols] but every {open symbol} needs a [matching closing symbol]?";
            char[] openSymbols = { '[', '{', '(' };

            int closingPosition6 = 0;
            
            while(true)
            {
                int openingPosition6 = message6.IndexOfAny(openSymbols, closingPosition6);
                if (openingPosition6 == -1) break;
                string currentSymbol = message6.Substring(openingPosition6, 1);
                char matchingSymbol = ' ';

                switch(currentSymbol)
                {
                    case "[":
                        matchingSymbol = ']';
                            break;
                    case "{":
                        matchingSymbol = '}';
                        break;
                    case "(":
                        matchingSymbol = ')';
                        break;
                }

                openingPosition6 += 1;
                closingPosition6 = message6.IndexOf(matchingSymbol, openingPosition6);

                int length6 = closingPosition6 - openingPosition6;
                Console.WriteLine(message6.Substring(openingPosition6, length6));
            }

        }
    }
}
