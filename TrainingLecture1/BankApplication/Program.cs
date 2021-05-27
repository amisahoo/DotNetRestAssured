using System;

namespace TrainingLecture1.BankApplication
{

    class BankingOperations
    {

        private string accountHolderName;
        private long accountNumber;
        private long initialAccountBalance;
        private long accountBalance;


        public string AccountHolderName { get { return this.accountHolderName; } set { this.accountHolderName = value; } }
        public long AccountNumber
        {
            get
            {


                return this.accountNumber;


            }
            set
            {

                if ((value > 10000000000) || (value < 999999999))
                {

                    throw new ArgumentOutOfRangeException("Not A Valid Account Number");

                }
                else
                {
                    this.accountNumber = value;
                }
            }
        }

        public long InitialAccountBalance { get {return this.accountBalance; } set { if (value > 0) { this.accountBalance = value; } else { throw new ArgumentOutOfRangeException("Invalid Balance"); } } }
        

        public void DisplayCurrentBalance() { Console.WriteLine($"Current Balance is {this.accountBalance}"); }
        public void DepositAmount(long credit)
        {
            if (credit > 0)
            {
                this.accountBalance += credit;
                Console.WriteLine("Amount Credited successfully");
            }
            else
            {
                Console.WriteLine("Invalid Credit Amount");
            }
        }
        public void WithdrawalAmount(long debit)
        {
            if((this.accountBalance>= debit)&&(debit>0))
            { 
                this.accountBalance -= debit;
                Console.WriteLine("Amount Debited successfully");

            }
            else
            {
                Console.WriteLine("Invalid Debit Amount");
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            BankingOperations User = new BankingOperations();
            User.AccountHolderName = "Anirudha Sahoo";
            User.AccountNumber = 1234567899;
            User.InitialAccountBalance = 1000;
            Console.WriteLine($"Account Holder Name is {User.AccountHolderName} \nAccount Number is {User.AccountNumber}");
            User.DepositAmount(500);
            User.WithdrawalAmount(1600);
            User.DisplayCurrentBalance();       
        }
    }
}
