namespace OpenClose
{
    internal class VIPBankAccount : IAccountFees
    {
        public readonly decimal _vipAccountFee;
        public VIPBankAccount(decimal accountFee)
        {
            _vipAccountFee = accountFee;
        }

        public decimal getAccountFee(decimal amountFee, decimal percentage)
        {
            return _vipAccountFee * amountFee * percentage;
        }
    }
}
