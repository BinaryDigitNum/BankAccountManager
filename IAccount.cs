using System;
namespace BankAccountManager
{
    public interface IAccount
    {
        decimal Balance { get; }
        decimal TaxRate { get; }
        string AccountType { get; }
        decimal MaximumAmount { get; }
        decimal MinimumAmount { get; }
        void Withdraw();
        void Deposit();
        void CreateReceipt(string transitionType, decimal amount, decimal taxRate);
        void DisplayDashboard();
    }
}

