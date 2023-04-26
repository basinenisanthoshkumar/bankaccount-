using System;
namespace BankApplication
{
    interface IBankAccount
    {
        bool DepositAmount(decimal amount);
        bool WithdrawAmount(decimal amount);
        decimal CheckBalance();
    }
    public class SavingAccount : IBankAccount
    {
        private decimal Balance = 0;
        private readonly decimal PerDayWithdrawLimit = 10000;
        private decimal TodayWithdrawal = 0;
        public bool DepositAmount(decimal Amount)
        {
            Balance = Balance + Amount;
            Console.WriteLine($"Deposited: {Amount}");
            Console.WriteLine($"Account Balance: {Balance}");
            return true;
        }
        public bool WithdrawAmount(decimal Amount)
        {
            if (Balance < Amount)
            {
                Console.WriteLine("Insufficient balance");
                return false;
            }
            else if (TodayWithdrawal + Amount > PerDayWithdrawLimit)
            {
                Console.WriteLine("Withdrawal attempt failed");
                return false;
            }
            else
            {
                Balance = Balance - Amount;
                TodayWithdrawal = TodayWithdrawal + Amount;
                Console.WriteLine($"Successfully Withdraw: {Amount}");
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

        public bool DepositAmount(decimal Amount)
        {
            Balance = Balance + Amount;
            Console.WriteLine($"Deposited: {Amount}");
            Console.WriteLine($"Account Balance: {Balance}");
            return true;
        }
        public bool WithdrawAmount(decimal Amount)
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
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            static int ValidateInput(int inputValue)
            {

                if (inputValue >= 0)
                {
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

            try
            {
                Console.WriteLine("Saving Account:");
                IBankAccount savingAccount = new SavingAccount();
                Console.WriteLine("Enter Depoist Amount:-");
                savingAccount.DepositAmount(ValidateInput((Convert.ToInt32(Console.ReadLine()))));
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
             catch(Exception ex)
            {
                Console.WriteLine("Enter Valid Format");
            }
        }
    }

}
