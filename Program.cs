using System;
using BankAccountManager;
Console.WriteLine("------------Bank account manager ----------------");

string? accountType = null;

void GetAccountType()
{
    while (true)
    {
        try
        {
            Console.WriteLine("Choose your account :");
            Console.WriteLine("(1) Checking account");
            Console.WriteLine("(2) Saving account");
            Console.WriteLine("(3) Business account");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    accountType = "checking";
                    break;
                case 2:
                    accountType = "saving";
                    break;
                case 3:
                    accountType = "business";
                    break;
                default:
                    break;
            }
            if (accountType != null)
            {
                break;
            }
        }
        catch (FormatException fx)
        {
            Console.WriteLine($"Error : {fx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
}

void MainProgram()
{
    bool exit = false;
    IAccount? currentAccount = null;

    switch (accountType)
    {
        case "business":
            currentAccount = new BusinessAccount();
            break;
        case "saving":
            currentAccount = new SavingAccount();
            break;
        case "checking":
            currentAccount = new CheckingAccount();
            break;
        default:
            break;
    }


    while (!exit)
    {
        if (currentAccount != null)
        {
            currentAccount.DisplayDashboard();
            string operations = Console.ReadLine().Trim();
            if (operations == "1")
            {
                currentAccount.Withdraw();
            }
            else if (operations == "2")
            {
                currentAccount.Deposit();
            }
            else if (operations == "exit")
            {
                exit = true;
            }
            else
            {
                Console.WriteLine("Please enter valid operation number");
            }
        }
    }
}

GetAccountType();
MainProgram();