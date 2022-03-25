using Xunit;
using System;
using BankAccounts.App;


namespace Test.BankAccounts
    {

    public class UnitTest1
    {
        // unit tests are supposed to be laser focused on a particular behavior or function of a very small unit of code.
        
        [Fact]
        public void Test1()
        {
            // ARRANGE - any set up that is required to perform the test.
            // ACT - where we invoke the behavior to test.
            // ASSERT - compare the result of the ACT to an expected value.

            Assert.Equal( true, true );
            // Assert.Equal( (what we expect to get back, our control), (what we actually got back))
        }

        // typical naming convention
        // UnitOfTest_TestCondition_CorrectBehavior

        [Fact]
        public void SavingsAccount_CreateSavingsAccount_ValidSavingsAccount()
        {
            // ARRANGE
            string expected = "testAccount";
            double savingsAccountBalance = 1234.56;
            // ACT
            var account = new SavingsAccount("testAccount", 1234.56);
            double actualAccountBalance = account.GetAccountBalance();

            // ASSERT
            Assert.Equal( account.accountName, expected );
            Assert.Equal (savingsAccountBalance, actualAccountBalance );
        }

        [Fact]
        public void Transaction_CreateTransaction_ValidTransaction()
        {
            // ARRANGE
            DateTime time = DateTime.Now;
            // ACT
            Transaction tran = new Transaction(1500.50, time, "TestDeposit");

            // ASSERT
            Assert.Equal( tran.Date, time );
        }
    
        [Fact]
        public void Account_GetInterestRate_ReturnInterestRate()
        {
            // ARRANGE
            SavingsAccount saving = new SavingsAccount("Test", 100000);
            double expectedInterestRate = 0.003;

            // ACT
            double actual = saving.GetInterestRate();

            // ASSERT
            Assert.Equal( expectedInterestRate, actual );
        }
    
        [Fact]
        public void Account_InvalidWithdrawl_allTransactionsLengthUnchanged()
        {
            // ARRANGE
            SavingsAccount savings = new SavingsAccount("testAccount", 1000);
            int expectedAllTransactionsCount = 1;

            // ACT
            savings.Withdrawl(1500);
            int actualAllTransactionCount = savings.GetTransactionsCount();

            // ASSERT
            Assert.Equal( expectedAllTransactionsCount, actualAllTransactionCount );
        }

        [Fact]
        public void Account_ValidWithdrawl_allTransactionsLengthIncreased()
        {
            // ARRANGE
            SavingsAccount savings = new SavingsAccount("testAccount", 1000);
            int expectedAllTransactionsCount = 2;

            // ACT
            savings.Withdrawl(100);
            int actualAllTransactionCount = savings.GetTransactionsCount();

            // ASSERT
            Assert.Equal( expectedAllTransactionsCount, actualAllTransactionCount );
        }
    
        [Fact]
        public void DummyTest_CharNotInString()
        {
            //This test is to experiment with the Assert.DoesNotContain() method.
            
            // ARRANGE
            var expected = "&";
            string actual = "this string does & contain an ampersand.";

            // ACT

            // ASSERT
            Assert.DoesNotContain( expected, actual );
        }
    }
}