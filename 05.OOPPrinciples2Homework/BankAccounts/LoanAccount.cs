namespace BankAccounts
{
    public class LoanAccount : Account, IDepositable
    {
        const int INDIVIDUALS_NO_INTEREST_MONTHS_COUNT = 3;
        const int COMPANIES_NO_INTEREST_MONTHS_COUNT = 2;

        public override Customer Customer { get; protected set; }

        public override decimal Balance { get; protected set; }

        public override decimal InterestRate { get; protected set; }

        public override void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public override decimal CalculateInterest(int numberOfMonths)
        {
            if (this.Customer is Individual)
            {
                if (numberOfMonths <= INDIVIDUALS_NO_INTEREST_MONTHS_COUNT)
                {
                    return 0M;
                }
                return this.InterestRate * (numberOfMonths - INDIVIDUALS_NO_INTEREST_MONTHS_COUNT);
            }
            else
            {
                if (numberOfMonths <= COMPANIES_NO_INTEREST_MONTHS_COUNT)
                {
                    return 0M;
                }
                return this.InterestRate * (numberOfMonths - COMPANIES_NO_INTEREST_MONTHS_COUNT);
            }
        }
    }
}
