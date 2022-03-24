namespace BankAccounts
{
    class SavingsAccount : Account
    {
        // Fields

        // Constructor
        public SavingsAccount( string accountName, double accountBalance)
        {
            this.accountName = accountName;
            this.Deposit(accountBalance, "First Deposit");
            this.interestRate = 0.003;
        }
        // Methods

        public void ApplyInterest()
        {
            this.Deposit( Math.Round((this.accountBalance * this.interestRate), 2), "Interest Payment");
        }
    }
}