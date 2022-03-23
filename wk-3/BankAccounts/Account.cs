namespace BankAccounts
{
    abstract class Account
    {// abstract class objects cannot be created, and do not have a constructor.

        // Fields
        public string? accountName;
        protected int accountNumber;
        protected double accountBalance;
        protected double interestRate;

        // Methods
        public int GetAccountNumber()
        {
            return this.accountNumber;
        }

        public double GetAccountBalance()
        {
            return this.accountBalance;
        }

        public double GetInterestRate()
        {
            return this.interestRate;
        }

        public abstract void Withdrawl (double withdrawl);

        public abstract void Deposit (double deposit);


        protected void Record(double TransactionAmmount)
        {
            DateTime Current = DateTime.Now;
            string[] content = {(Current.ToString("F")) + "\t" + this.accountNumber + "\t" + this.accountName + "\t" + TransactionAmmount + "\t" + this.accountBalance};
            string path = @".\TransactionRecords.txt";

            if( !File.Exists(path) )
            {
                File.WriteAllLines(path, content);
            }
            else
            {
                File.AppendAllLines(path, content);
            }
        }

    }
}