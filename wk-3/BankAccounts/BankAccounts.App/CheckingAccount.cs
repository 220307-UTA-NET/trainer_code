namespace BankAccounts.App
{
    public class CheckingAccount : Account
    {
        // Fields

        // Constructor
        public CheckingAccount( string accountName, double accountBalance)
        {
            this.accountName = accountName;
            this.Deposit(accountBalance, "First Deposit");
            this.interestRate = 0.00;
        }

        // Methods

    }
}