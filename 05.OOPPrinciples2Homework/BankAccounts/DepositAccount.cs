namespace BankAccounts
{
    class DepositAccount : Account, IDepositable, IWithdrawable
    {
        const int MINIMAL_ACCRUABLE_AMOUNT = 1000;
        const int MINIMAL_AMOUNT = 0;

        public override Customer Customer { get; protected set; }

        public override decimal Balance { get; protected set; }

        public override decimal InterestRate { get; protected set; }

        public override void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }

        public override decimal CalculateInterest(int numberOfMonths)
        {
            if (MINIMAL_AMOUNT < this.Balance && this.Balance < MINIMAL_ACCRUABLE_AMOUNT)
            {
                return 0M;
            }
            else
            {
                return base.CalculateInterest(numberOfMonths);
            }
        }
    }
}
