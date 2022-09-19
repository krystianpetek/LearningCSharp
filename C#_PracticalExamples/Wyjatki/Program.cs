using System;
using System.IO;

namespace wyjatki
{
    class Program
    {
        private static void TryCatchFinallyTest()
        {
            StreamReader sr = null;
            try
            {
                sr = File.OpenText(@"D:\GITHUB_REPO\Cwiczenia\wyjatki\data.txt");
                Console.WriteLine(sr.ReadToEnd());
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                if (sr != null)
                {
                    sr.Close();
                    Console.WriteLine("koniec");
                }
            }
        }

        static void Main(string[] args)
        {
            TryCatchFinallyTest();
        }
    }
}
