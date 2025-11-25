namespace BadBank.src;

public class Bank
{
    public string BankName;
    private BankAccount[] accounts;
    private int numAccounts;

    public Bank(string name)
    {
        this.BankName = name;
        accounts = new BankAccount[100];
        numAccounts = 0;
    }

    public void AddAccount(BankAccount account)
    {
        if (numAccounts < accounts.Length)
        {
            accounts[numAccounts] = account;
            numAccounts++;
        }
        else
        {
            Console.WriteLine("Error: Bank full, cannot add account.");
        }
    }

    public void DisplayAllAccounts()
    {
        Console.WriteLine("Accounts in " + BankName + " bank:");
        for (int i = 0; i < numAccounts; i++)
        {
            Console.WriteLine(accounts[i].ToString());
        }
    }
}