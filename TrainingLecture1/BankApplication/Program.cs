using System;
using System.Collections.Generic;

namespace TrainingLecture1.BankApplication
{

    class BankingOperations
    {

        private string accountHolderName;
        private long accountNumber;
        private long initialAccountBalance;
        private long accountBalance;
        private List<string> statement = new List<string>();


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
                statement.Add($"{DateTime.Now} : Credit of Rs {credit}");
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
                statement.Add($"{DateTime.Now} : Credit of Rs {debit}");

            }
            else
            {
                Console.WriteLine("Insufficient Debit Amount");
            }

        }

        public void DisplayStatement()
        {
            Console.WriteLine(  "\n-----------------Statement-----------------------------\n");
            foreach (string str in statement) { Console.WriteLine($"{str}\n"); }
            DisplayCurrentBalance();
            Console.WriteLine("\n-----------------End-----------------------------\n");

        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            BankingOperations User = new BankingOperations();
            User.AccountHolderName = "Anirudha Sahoo";
            User.AccountNumber = 1234567999;
            User.InitialAccountBalance = 1000;
            Console.WriteLine($"Account Holder Name is {User.AccountHolderName} \nAccount Number is {User.AccountNumber}");

            while(true)
            {
                Console.WriteLine("Enter your choice");
                Console.WriteLine("Press \'a\' for Diplaying Balance");
                Console.WriteLine("Press \'b\' for Balace Deposit");
                Console.WriteLine("Press \'c\' for Balace Withdrawl");
                Console.WriteLine("Press \'d\' for Statement");
                Console.WriteLine("Press \'e\' To Exit");

                char ch = Console.ReadLine()[0];
                if (ch == 'e') { break; };
                switch (ch)
                {
                    case 'a':
                        User.DisplayCurrentBalance();
                        break;
                    case 'b':
                        Console.WriteLine("Enter the Deposit Amount\n");
                        long credit = Convert.ToInt64(Console.ReadLine());
                        User.DepositAmount(credit);
                        break;

                    case 'c':
                        Console.WriteLine("Enter the Withdrawl Amount\n");
                        long debit = Convert.ToInt64(Console.ReadLine());
                        User.WithdrawalAmount(debit);
                        break;

                    case 'd':
                        User.DisplayStatement();
                        break;

                    default:
                        Console.WriteLine("Invalid Choice\n");
                        break;
                }
            }
            

            
        }
    }
}
