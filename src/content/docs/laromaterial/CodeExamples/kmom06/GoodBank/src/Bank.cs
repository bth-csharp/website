namespace GoodBank.src;

public class Bank
{
    public string BankName { get; }
    private List<BankAccount> _accounts;

    public Bank(string name)
    {
        BankName = name;
        _accounts = [];
    }

    public void AddAccount(BankAccount account)
    {
        _accounts.Add(account);
    }

    public void DisplayAllAccounts()
    {
        Console.WriteLine($"Accounts in {BankName} bank:");
        foreach (var account in _accounts)
        {
            Console.WriteLine(account.ToString());
        }
    }
}