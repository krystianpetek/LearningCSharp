using System;
using System.Text;

namespace teamformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
                Reader r = new Reader();
            
            StringBuilder sb = new StringBuilder();

                long no_of_teams;
                long n, p = 1000000007;

                while ((n = r.nextUnsignedInt()) != 0)
                {
                    no_of_teams = (((n * (n - 1)) % p) * power(2, n - 2, p)) % p;

                    sb.Append(no_of_teams);
                    sb.Append('\n');
                }
            Console.WriteLine(sb.ToString());
            }

        public class Reader
        {
            private int BUFFER_SIZE = 1 << 16;
            private DataInputStream dis;
            private byte[] buffer;
            private int bufferPointer, bytesRead;

            public Reader()
            {
                dis = new DataInputStream(System.in);
                buffer = new byte[BUFFER_SIZE];
                bufferPointer = bytesRead = 0;
            }
        }
            


        public static long power(long x, long y, long p)
        {
            long result = 1;

            x = x % p;
            while (y > 0)
            {
                if ((y & 1) == 1)
                {
                    result = (result * x) % p;
                }

                y = y >> 1;
                x = (x * x) % p;
            }

            return result;
        }

        public int nextUnsignedInt(){
                int ret = 0;
                byte c = read();
                while (c <= ' ')
                    c = read();
                do
                {
                    ret = ret * 10 + c - '0';
                } while ((c = read()) >= '0' && c <= '9');

                return ret;
            }
        private byte read()
        {
        if (bufferPointer == bytesRead)
            fillBuffer();
        return buffer[bufferPointer++];

            

        }
    }
}
