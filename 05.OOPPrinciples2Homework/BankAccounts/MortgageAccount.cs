namespace BankAccounts
{
    class MortgageAccount : Account, IDepositable
    {
        const int INDIVIDUALS_NO_INTEREST_MONTHS_COUNT = 6;
        const int COMPANIES_REDUCED_INTEREST_MONTHS_COUNT = 12;
        const int COMPANIES_REDUCED_INTEREST_COEFFICIENT = 2;

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
                if (numberOfMonths < COMPANIES_REDUCED_INTEREST_MONTHS_COUNT)
                {
                    return this.InterestRate * numberOfMonths / COMPANIES_REDUCED_INTEREST_COEFFICIENT;
                }
                return this.InterestRate * COMPANIES_REDUCED_INTEREST_MONTHS_COUNT / COMPANIES_REDUCED_INTEREST_COEFFICIENT
                    + this.InterestRate * (numberOfMonths - COMPANIES_REDUCED_INTEREST_MONTHS_COUNT);
            }
        }
    }
}
