using System;

namespace DokumentacjaCSKlasy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount konto = new("Krystian", 555);
            konto.Deposit(30, DateTime.Now, "chaking");
            konto.Withdraw(100, DateTime.Now, "wyplata");
            konto.GetHistoryAccount();
            konto.AccountInfo();
        }
    }
}
