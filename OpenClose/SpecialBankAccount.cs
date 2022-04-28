namespace OpenClose
{
    internal class SpecialBankAccount : IAccountFees
    {
        public readonly decimal _specialAccountFee;

        public SpecialBankAccount(decimal accountFees)
        {
            _specialAccountFee = accountFees;
        }

        public decimal getAccountFee(decimal amountFee, decimal percentage)
        {
            return _specialAccountFee * amountFee * percentage;
        }
    }
}