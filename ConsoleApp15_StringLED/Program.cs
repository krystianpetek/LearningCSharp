using System;

namespace ConsoleApp15_StringLED
{
    class Program
    {
        public static void Definicje()
        {

        }
        public static char[] PrzypiszTablice(char ciag, int i)
        {
            char z = '#';
            char s = '.';
            #region ZERO
            char[][] zero = new char[7][];
            zero[0] = $"{s}{z}{z}{z}{s}".ToCharArray();
            zero[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            zero[2] = $"{z}{s}{s}{s}{z}".ToCharArray();
            zero[3] = $"{z}{s}{s}{s}{z}".ToCharArray();
            zero[4] = $"{z}{s}{s}{s}{z}".ToCharArray();
            zero[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            zero[6] = $"{s}{z}{z}{z}{s}".ToCharArray();
            #endregion
            #region JEDEN
            char[][] jeden = new char[7][];
            jeden[0] = $"{s}{s}{z}{s}{s}".ToCharArray();
            jeden[1] = $"{s}{z}{z}{s}{s}".ToCharArray();
            jeden[2] = $"{z}{s}{z}{s}{s}".ToCharArray();
            jeden[3] = $"{s}{s}{z}{s}{s}".ToCharArray();
            jeden[4] = $"{s}{s}{z}{s}{s}".ToCharArray();
            jeden[5] = $"{s}{s}{z}{s}{s}".ToCharArray();
            jeden[6] = $"{z}{z}{z}{z}{z}".ToCharArray();
            #endregion
            #region DWA
            char[][] dwa = new char[7][];
            dwa[0] = $"{s}{z}{z}{z}{s}".ToCharArray();
            dwa[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            dwa[2] = $"{s}{s}{s}{s}{z}".ToCharArray();
            dwa[3] = $"{s}{s}{s}{z}{s}".ToCharArray();
            dwa[4] = $"{s}{s}{z}{s}{s}".ToCharArray();
            dwa[5] = $"{s}{z}{s}{s}{s}".ToCharArray();
            dwa[6] = $"{z}{z}{z}{z}{z}".ToCharArray();
            #endregion
            #region TRZY
            char[][] trzy = new char[7][];
            trzy[0] = $"{s}{z}{z}{z}{s}".ToCharArray();
            trzy[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            trzy[2] = $"{s}{s}{s}{s}{z}".ToCharArray();
            trzy[3] = $"{s}{s}{z}{z}{s}".ToCharArray();
            trzy[4] = $"{s}{s}{s}{s}{z}".ToCharArray();
            trzy[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            trzy[6] = $"{s}{z}{z}{z}{s}".ToCharArray();
            #endregion
            #region CZTERY
            char[][] cztery = new char[7][];
            cztery[0] = $"{s}{s}{z}{z}{s}".ToCharArray();
            cztery[1] = $"{s}{z}{s}{z}{s}".ToCharArray();
            cztery[2] = $"{z}{s}{s}{z}{s}".ToCharArray();
            cztery[3] = $"{z}{s}{s}{z}{s}".ToCharArray();
            cztery[4] = $"{z}{z}{z}{z}{z}".ToCharArray();
            cztery[5] = $"{s}{s}{s}{z}{s}".ToCharArray();
            cztery[6] = $"{s}{s}{s}{z}{s}".ToCharArray();
            #endregion
            #region PIEC
            char[][] piec = new char[7][];
            piec[0] = $"{z}{z}{z}{z}{z}".ToCharArray();
            piec[1] = $"{z}{s}{s}{s}{s}".ToCharArray();
            piec[2] = $"{z}{s}{s}{s}{s}".ToCharArray();
            piec[3] = $"{s}{z}{z}{z}{s}".ToCharArray();
            piec[4] = $"{s}{s}{s}{s}{z}".ToCharArray();
            piec[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            piec[6] = $"{s}{z}{z}{z}{s}".ToCharArray();
            #endregion
            #region SZESC
            char[][] szesc = new char[7][];
            szesc[0] = $"{s}{s}{z}{z}{s}".ToCharArray();
            szesc[1] = $"{s}{z}{s}{s}{s}".ToCharArray();
            szesc[2] = $"{z}{s}{s}{s}{s}".ToCharArray();
            szesc[3] = $"{z}{z}{z}{z}{s}".ToCharArray();
            szesc[4] = $"{z}{s}{s}{s}{z}".ToCharArray();
            szesc[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            szesc[6] = $"{s}{z}{z}{z}{s}".ToCharArray();
            #endregion
            #region SIEDEM
            char[][] siedem = new char[7][];
            siedem[0] = $"{z}{z}{z}{z}{z}".ToCharArray();
            siedem[1] = $"{s}{s}{s}{s}{z}".ToCharArray();
            siedem[2] = $"{s}{s}{s}{z}{s}".ToCharArray();
            siedem[3] = $"{s}{s}{z}{s}{s}".ToCharArray();
            siedem[4] = $"{s}{z}{s}{s}{s}".ToCharArray();
            siedem[5] = $"{s}{z}{s}{s}{s}".ToCharArray();
            siedem[6] = $"{s}{z}{s}{s}{s}".ToCharArray();
            #endregion
            #region OSIEM
            char[][] osiem = new char[7][];
            osiem[0] = $"{s}{z}{z}{z}{s}".ToCharArray();
            osiem[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            osiem[2] = $"{z}{s}{s}{s}{z}".ToCharArray();
            osiem[3] = $"{s}{z}{z}{z}{s}".ToCharArray();
            osiem[4] = $"{z}{s}{s}{s}{z}".ToCharArray();
            osiem[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            osiem[6] = $"{s}{z}{z}{z}{s}".ToCharArray();
            #endregion
            #region DZIEWIEC
            char[][] dziewiec = new char[7][];
            dziewiec[0] = $"{s}{z}{z}{z}{s}".ToCharArray();
            dziewiec[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            dziewiec[2] = $"{z}{s}{s}{s}{z}".ToCharArray();
            dziewiec[3] = $"{s}{z}{z}{z}{z}".ToCharArray();
            dziewiec[4] = $"{s}{s}{s}{s}{z}".ToCharArray();
            dziewiec[5] = $"{s}{s}{s}{z}{s}".ToCharArray();
            dziewiec[6] = $"{s}{z}{z}{s}{s}".ToCharArray();
            #endregion
            #region SPACJA
            char[][] spacja = new char[7][];
            spacja[0] = $"{s}{s}{s}{s}{s}".ToCharArray();
            spacja[1] = $"{s}{s}{s}{s}{s}".ToCharArray();
            spacja[2] = $"{s}{s}{s}{s}{s}".ToCharArray();
            spacja[3] = $"{s}{s}{s}{s}{s}".ToCharArray();
            spacja[4] = $"{s}{s}{s}{s}{s}".ToCharArray();
            spacja[5] = $"{s}{s}{s}{s}{s}".ToCharArray();
            spacja[6] = $"{s}{s}{s}{s}{s}".ToCharArray();

            #endregion

            #region A
            char[][] A = new char[7][];
            A[0] = $"{s}{s}{z}{s}{s}".ToCharArray();
            A[1] = $"{s}{z}{s}{z}{s}".ToCharArray();
            A[2] = $"{z}{s}{s}{s}{z}".ToCharArray();
            A[3] = $"{z}{s}{s}{s}{z}".ToCharArray();
            A[4] = $"{z}{z}{z}{z}{z}".ToCharArray();
            A[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            A[6] = $"{z}{s}{s}{s}{z}".ToCharArray();
            #endregion
            #region B
            char[][] B = new char[7][];
            B[0] = $"{z}{z}{z}{z}{s}".ToCharArray();
            B[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            B[2] = $"{z}{s}{s}{s}{z}".ToCharArray();
            B[3] = $"{z}{z}{z}{z}{s}".ToCharArray();
            B[4] = $"{z}{s}{s}{s}{z}".ToCharArray();
            B[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            B[6] = $"{z}{z}{z}{z}{s}".ToCharArray();
            #endregion
            #region C
            char[][] C = new char[7][];
            C[0] = $"{s}{z}{z}{z}{s}".ToCharArray();
            C[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            C[2] = $"{z}{s}{s}{s}{s}".ToCharArray();
            C[3] = $"{z}{s}{s}{s}{s}".ToCharArray();
            C[4] = $"{z}{s}{s}{s}{s}".ToCharArray();
            C[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            C[6] = $"{s}{z}{z}{z}{s}".ToCharArray();
            #endregion
            #region D
            char[][] D = new char[7][];
            D[0] = $"{z}{z}{z}{s}{s}".ToCharArray();
            D[1] = $"{z}{s}{s}{z}{s}".ToCharArray();
            D[2] = $"{z}{s}{s}{s}{z}".ToCharArray();
            D[3] = $"{z}{s}{s}{s}{z}".ToCharArray();
            D[4] = $"{z}{s}{s}{s}{z}".ToCharArray();
            D[5] = $"{z}{s}{s}{z}{s}".ToCharArray();
            D[6] = $"{z}{z}{z}{s}{s}".ToCharArray();
            #endregion

            char[] znak = new char[5];

            switch (ciag)
            {
                case '0':
                    znak = zero[i];
                    break;
                case '1':
                    znak = jeden[i];
                    break;
                case '2':
                    znak = dwa[i];
                    break;
                case '3':
                    znak = trzy[i];
                    break;
                case '4':
                    znak = cztery[i];
                    break;
                case '5':
                    znak = piec[i];
                    break;
                case '6':
                    znak = szesc[i];
                    break;
                case '7':
                    znak = siedem[i];
                    break;
                case '8':
                    znak = osiem[i];
                    break;
                case '9':
                    znak = dziewiec[i];
                    break;
                case ' ':
                    znak = spacja[i];
                    break;

                case 'A':
                case 'a':
                    znak = A[i];
                    break;
                case 'B':
                case 'b':
                    znak = B[i];
                    break;
                case 'C':
                case 'c':
                    znak = C[i];
                    break;
                case 'D':
                case 'd':
                    znak = D[i];
                    break;

            }
            return znak;
        }
        static void Main(string[] args)
        {
            char[] ciag = Console.ReadLine().ToCharArray();

            for (int x = 0; x < 7; x++)
            {
                for (int i = 0; i < ciag.Length; i++)
                {
                    char[] znak = PrzypiszTablice(ciag[i], x);
                    for (int j = 0; j < 5; j++)
                    {
                        if (znak[j] == '#')
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(znak[j]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                            Console.Write(znak[j]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
