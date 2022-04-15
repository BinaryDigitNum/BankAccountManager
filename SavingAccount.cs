using System;
namespace BankAccountManager
{
    /// <summary>
    ///  SavingAccount should not be able to withdraw more than 80 and less than 5
    ///  TaxRate is 0.25 %     
    /// </summary>
    public class SavingAccount : IAccount
    {
        public decimal Balance { get; private set; } = 100;

        public decimal TaxRate { get; } = 0.25M;

        public string AccountType { get; } = "Saving";

        public decimal MaximumAmount { get; } = 50;

        public decimal MinimumAmount { get; } = 5;

        public void CreateReceipt(string transitionType, decimal amount, decimal taxRate)
        {
            Console.WriteLine("\n");
            Console.WriteLine($"-------- {transitionType} receipt ---------");
            Console.WriteLine($"Amount : {amount}");
            Console.WriteLine($"Tax rate : {taxRate}");
            Console.WriteLine($"Remaining balance : {Balance}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("\n");
        }

        public void DisplayDashboard()
        {
            Console.WriteLine($"{AccountType} account \t\t\t\t Balance{Balance}");
            Console.WriteLine("(1) Withdraw money");
            Console.WriteLine("(2) Deposit money");
        }

        public void Deposit()
        {
            decimal depositAmount = 0;
            try
            {
                Console.WriteLine("Enter the amount you want to deposit to your account");
                depositAmount = Convert.ToDecimal(Console.ReadLine());
                Balance += depositAmount;
            }
            catch (FormatException fx)
            {
                Console.WriteLine(fx.Message);
                Console.WriteLine(fx.StackTrace);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void Withdraw()
        {
            decimal withdrawAmount = 0;
            if (Balance <= 0)
            {
                Console.WriteLine("There is no balance left in the account");
            }
            else
            {
                try
                {
                    Console.WriteLine("How many would you like to withdraw ?");
                    withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                    decimal tax = withdrawAmount * TaxRate;
                    decimal totalAmount = withdrawAmount + tax;
                    if (withdrawAmount < MinimumAmount || withdrawAmount > MaximumAmount)
                    {
                        Console.WriteLine($"{AccountType} account withdraw amount must be between {MinimumAmount} to {MaximumAmount}");
                    }
                    else
                    {
                        if (totalAmount >= Balance)
                        {
                            Console.WriteLine("Not enought balance left to withdraw.");
                        }
                        else
                        {
                            Balance -= totalAmount;
                            CreateReceipt(AccountType, withdrawAmount, tax);
                        }
                    }
                }
                catch (FormatException fx)
                {
                    Console.WriteLine(fx);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

        }
    }
}