namespace BankAccounts
{
    using System.Collections.Generic;
    public class Bank
    {
        public List<Account> Accounts { get; private set; }

        public Bank(List<Account> accounts)
        {
            this.Accounts = accounts;
        }
    }
}
