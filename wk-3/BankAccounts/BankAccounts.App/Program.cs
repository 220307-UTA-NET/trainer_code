using System;
using System.IO;

namespace BankAccounts.App
{
    class Program
    {
        static void Main()
        {
            SavingsAccount newSavingsAccount = new SavingsAccount("Personal Savings", 2500.75);

            Console.WriteLine("newAccount.AccountName = " + newSavingsAccount.accountName);
            Console.WriteLine("Current account number: " + newSavingsAccount.GetAccountNumber());
            Console.WriteLine("Current account balance: " + newSavingsAccount.GetAccountBalance());
            Console.WriteLine("Current interest rate: " + newSavingsAccount.GetInterestRate());

    // testing the withdrawl method
            newSavingsAccount.Withdrawl(1500);
            Console.WriteLine("Current account balance: " + newSavingsAccount.GetAccountBalance());
            newSavingsAccount.Withdrawl(1500);
            Console.WriteLine("Current account balance: " + newSavingsAccount.GetAccountBalance());
            newSavingsAccount.Withdrawl(-1000);
            Console.WriteLine("Current account balance: " + newSavingsAccount.GetAccountBalance());

    // testing the deposit method
            newSavingsAccount.Deposit(-1000);
            Console.WriteLine("Current account balance: " + newSavingsAccount.GetAccountBalance());
            newSavingsAccount.Deposit(234);
            Console.WriteLine("Current account balance: " + newSavingsAccount.GetAccountBalance());

    // testing the ApplyInterest method
            newSavingsAccount.ApplyInterest();
            Console.WriteLine("Current account balance: " + newSavingsAccount.GetAccountBalance());

            CheckingAccount newCheckingAccount = new CheckingAccount("Personal Checking", 250);

            Console.WriteLine("newAccount.AccountName = " + newCheckingAccount.accountName);
            Console.WriteLine("Current account number: " + newCheckingAccount.GetAccountNumber());
            Console.WriteLine("Current account balance: " + newCheckingAccount.GetAccountBalance());
            Console.WriteLine("Current interest rate: " + newCheckingAccount.GetInterestRate());
            
            newCheckingAccount.Deposit(-200);
            newCheckingAccount.Deposit(150);
            Console.WriteLine("Current account balance: " + newCheckingAccount.GetAccountBalance());
            newCheckingAccount.Withdrawl(-100);
            newCheckingAccount.Withdrawl(1000000000);
            newCheckingAccount.Withdrawl(150);
            Console.WriteLine("Current account balance: " + newCheckingAccount.GetAccountBalance());

            newCheckingAccount.SerializeAsXml();
            newSavingsAccount.SerializeAsXml();
        }
    }
}