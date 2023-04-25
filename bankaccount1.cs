using System;
namespace BankApplication
{
    interface IBankAccount
    {
        bool DepositAmount(int amount);
        bool WithdrawAmount(int amount);
        decimal CheckBalance();
    }
    public class SavingAccount : IBankAccount
    {
        private decimal Balance = 0;
        private readonly decimal PerDayWithdrawLimit = 10000;
        private decimal TodayWithdrawal = 0;
        public bool DepositAmount(int Amount)
        {
            var result = validation.ValidateInput(Amount);
            Balance = Balance + result;
            Console.WriteLine($"Deposited: {result}");
            Console.WriteLine($"Account Balance: {Balance}");
            return true;
        }
        public bool WithdrawAmount(int Amount)
        {
            var result1 = validation.ValidateInput(Amount);

            if (Balance <result1)
            {
                Console.WriteLine("Insufficient balance");
                return false;
            }
            else if (TodayWithdrawal + result1 > PerDayWithdrawLimit)
            {
                Console.WriteLine("Withdrawal attempt failed");
                return false;
            }
            else
            {
                Balance = Balance - result1;
                TodayWithdrawal = TodayWithdrawal + result1;
                Console.WriteLine($"Successfully Withdraw: {result1}");
                Console.WriteLine($"Your Account Balance: {Balance}");
                return true;
            }
        }
        public decimal CheckBalance()
        {
            return Balance;
        }
    }
    public class CurrentAccount : IBankAccount
    {
        private decimal Balance = 0;

        public bool DepositAmount(int Amount)
        {
            Balance = Balance + Amount;
            Console.WriteLine($"Deposited: {Amount}");
            Console.WriteLine($"Account Balance: {Balance}");
            return true;
        }
        public bool WithdrawAmount(int Amount)
        {
            if (Balance < Amount)
            {
                Console.WriteLine("Insufficient balance");
                return false;
            }
            else
            {
                Balance = Balance - Amount;
                Console.WriteLine($"Successfully Withdraws: {Amount}");
                Console.WriteLine($"Account Balance: {Balance}");
                return true;
            }
        }
        public decimal CheckBalance()
        {
            return Balance;
        }
    }
    public static class validation
    {
        public static int ValidateInput(int inputValue)
        {
            // Check if the input is a positive integer
            if (inputValue >= 0)
            {
                // Check if the input is a decimal or float
                if (inputValue == (int)inputValue)
                {
                    return inputValue;
                }
                else
                {
                    
                    throw new Exception("Enter valid amount");
                }
            }
               return 0;
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
     
            Console.WriteLine("Saving Account:");
            IBankAccount savingAccount = new SavingAccount();
            Console.WriteLine("Enter Depoist Amount:-");
            savingAccount.DepositAmount(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Enter Withdraw Amount:-");
            savingAccount.WithdrawAmount(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine($"Saving Account Balance: {savingAccount.CheckBalance()}");
            Console.WriteLine("\n Current Account:");
            IBankAccount currentAccount = new CurrentAccount();
            Console.WriteLine("Enter Depoist Amount:-");
            currentAccount.DepositAmount(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Enter Withdraw Amount:-");
            currentAccount.WithdrawAmount(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine($"Current Account Balance: {currentAccount.CheckBalance()}");
            Console.ReadKey();
        }
    }

}
