using System.Xml.Serialization;

namespace BankAccounts
{
    class Account
    {// abstract class objects cannot be created, and do not have a constructor.

        // Fields
        private static int accountSeed = 11111111;
        public string? accountName;
        protected int accountNumber;
        protected double accountBalance
        {
            get
            {
                double balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }
        protected double interestRate;
        private List<Transaction> allTransactions = new List<Transaction>();
        public XmlSerializer Serializer { get; } = new( typeof( List<Transaction>));

        // Constructor
        protected Account()
        {
            this.accountNumber = accountSeed;
            accountSeed++;

            this.ReadFromXml();
        }

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

        public void Withdrawl (double amount, string note = "")
        {
            if( amount < 0 )
            {
                Console.WriteLine("Withdrawls must be a positive value");
                Console.WriteLine("Transaction Canceled");
                return;
            }
            else if( (this.accountBalance - amount) < 0 )
            {
                Console.WriteLine("Balance in account my not go below 0.");
                Console.WriteLine("Transaction canceled.");
                return;
            }
            else
            {
                // this.accountBalance -= withdrawl;
                // this.Record(-withdrawl);

                var withdrawl = new Transaction( -amount, DateTime.Now, note );
                allTransactions.Add(withdrawl);
            }
        }

        public void Deposit (double amount, string note = "")
        {
            if( amount < 0 )
            {
                Console.WriteLine("Deposits must be a positive value");
                Console.WriteLine("Transaction Canceled");
                return;
            }
            else
            {
                // this.accountBalance += deposit;
                // this.Record(deposit);

                var deposit = new Transaction( amount, DateTime.Now, note);
                allTransactions.Add(deposit);
            }
        }
        
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

        public void SerializeAsXml()
        {
            var newStringWriter = new StringWriter();
            Serializer.Serialize(newStringWriter, allTransactions);
            newStringWriter.Close();
            
            string path = $"./Transactions-{this.accountNumber}.xml";
            File.WriteAllText(path, newStringWriter.ToString());
        }

        public void ReadFromXml()
        {
            try
            {
                using StreamReader reader = new( $"./Transactions-{this.accountNumber}.xml");
                var records = (List<Transaction>?)Serializer.Deserialize(reader);
                reader.Dispose();

                if (records is null) throw new InvalidDataException();

                this.allTransactions = records;
            }
            catch (Exception e)
            {
                return;
            }
        }
    }
}