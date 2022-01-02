using System;

namespace ADATEAMS___Ada_and_Teams
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int MaxN = 1000005;
            long[] fact = new long[MaxN];
             long[] invp = new long[MaxN];
            long MOD = 1000000007;

            void init()
            {
                fact[0] = 1; invp[0] = 1;
                for (int i = 1; i < MaxN; i++)
                    fact[i] = (fact[i - 1] * i) % MOD;
                invp[MaxN - 1] = invFermat(fact[MaxN - 1], MOD);
                for (int i = MaxN - 2; i >= 1; i--)
                    invp[i] = (invp[i + 1] * (i + 1)) % MOD;
            }
            long nCr(long n, long r)
            {
                if (r < 0 || r > n) return 0;
                return (fact[n] * ((invp[n - r] * invp[r]) % MOD)) % MOD;
            }

                init();
                long n, a, b, d;
                while ( n = Console.ReadLine())
                {
                    cin >> a >> b >> d;
                    ll ans1 = nCr(n, a);
                    ll ans2 = nCr(b, d);
                    ll ans3 = mod_exp(ans2, a, MOD);
                    ll final_ans = ans1 * ans3;
                    final_ans %= MOD;
                    cout << final_ans << endl;
                }
                return 0;
            

            long invFermat(long a, long p) { return mod_exp(a, p - 2, p); }
            void mod_exp(long b, int p, long m) { long x = 1; while (p) { if (p & 1) x = (x * b) % m; b = (b * b) % m; p = p >> 1; } return x; }

        }
    }
}

#define EPS                 1e-9
#define io                  ios_base::sync_with_stdio(false);cin.tie(NULL);
#define M_PI                3.14159265358979323846

template<typename T> T gcd(T a, T b) { return (b == 0) ? a : gcd(b, a % b); }
template<typename T> T lcm(T a, T b) { return a * (b / gcd(a, b)); }
template<typename T> T mod_exp(T b, T p, T m) { T x = 1; while (p) { if (p & 1) x = (x * b) % m; b = (b * b) % m; p = p >> 1; } return x; }




