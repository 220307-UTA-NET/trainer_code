namespace BankAccounts
{
    class SavingsAccount : Account
    {
        // Fields

        // Constructor
        public SavingsAccount( string accountName, int accountNumber, double accountBalance)
        {
            this.accountName = accountName;
            this.accountNumber = accountNumber;
            this.accountBalance = accountBalance;
            this.interestRate = 0.003;
        }
        // Methods

        public override void Withdrawl(double withdrawl)
        {
            if( withdrawl < 0 )
            {
                Console.WriteLine("Withdrawls must be a positive value");
                Console.WriteLine("Transaction Canceled");
                return;
            }
            else if( (this.accountBalance - withdrawl) < 0 )
            {
                Console.WriteLine("Balance in account my not go below 0.");
                Console.WriteLine("Transaction canceled.");
                return;
            }
            else
            {
                this.accountBalance -= withdrawl;
                this.Record(-withdrawl);
            }
        }

        public override void Deposit(double deposit)
        {
            if( deposit < 0 )
            {
                Console.WriteLine("Deposits must be a positive value");
                Console.WriteLine("Transaction Canceled");
                return;
            }
            else
            {
                this.accountBalance += deposit;
                this.Record(deposit);
            }
        }

        public void ApplyInterest()
        {
            this.accountBalance += Math.Round((this.accountBalance * this.interestRate), 2);
        }
    }
}