namespace BankAccounts
{
    public abstract class Account : IDepositable
    {
        public abstract Customer Customer { get; protected set; }

        public abstract decimal Balance { get; protected set; }

        public abstract decimal InterestRate { get; protected set; }

        public abstract void Deposit(decimal amount);

        public virtual decimal CalculateInterest(int numberOfMonths)
        {
            return this.InterestRate * numberOfMonths;
        }
    }
}
