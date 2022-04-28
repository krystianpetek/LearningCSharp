using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClose
{
    internal class BankAccount : IAccountFees
    {
        public readonly IAccountFees _accountFees;
        public readonly string _accountType;

        public BankAccount(string accountType, IAccountFees accountFees)
        {
            _accountType = accountType;
            _accountFees = accountFees;
        }

        public decimal getAccountFee(decimal amountFee, decimal percentage)
        {
            return _accountFees.getAccountFee(amountFee, percentage);
        }
    }
}
