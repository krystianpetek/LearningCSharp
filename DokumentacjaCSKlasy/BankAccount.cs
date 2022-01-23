using System;
using System.Collections.Generic;

namespace DokumentacjaCSKlasy
{
    internal class BankAccount
    {
        public BankAccount(string name, decimal initialBalance = 0)
        {
            accountNumberSeed++;
            Number = accountNumberSeed.ToString();
            Owner = name;
            Deposit(initialBalance, DateTime.Now, "Wpłata");
        }
        public void AccountInfo()
        {
            Console.WriteLine($"konto numer: {this.Number} nalezy do {this.Owner} wartość: {this.Balance}");
        }
        public string Number { get; }
        public string Owner { get; }
        static int accountNumberSeed = 0;

        List<Transakcje> lista = new List<Transakcje>();
        public decimal Balance
        {
            get
            {
                decimal suma = 0;
                foreach (var item in lista)
                {
                    suma += item.kwota;
                }
                return suma;
            }

        }
        public void Withdraw(decimal amount, DateTime date, string note)
        {
            if (amount < 0)
            {

                throw new ArgumentOutOfRangeException("Wartość wypłaty musi być wieksza niż 0");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("nie masz tyle srodkow na koncie");
            }
            lista.Add(new Transakcje(-amount, date, note));
        }
        public void Deposit(decimal amount, DateTime date, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Wartość wpłaty musi być wieksza niż 0");
            }

            lista.Add(new Transakcje(amount, date, note));
        }
        public void GetHistoryAccount()
        {
            decimal suma = 0;
            Console.WriteLine("Historia");
            Console.WriteLine("Data\t\tKwota\tNota");
            foreach (var item in lista)
            {
                Console.WriteLine($"{item.dateTime.ToShortDateString()}\t{item.kwota}\t{item.notatka}\t\tBilans: {suma += item.kwota}");
            }
        }
    }
}
