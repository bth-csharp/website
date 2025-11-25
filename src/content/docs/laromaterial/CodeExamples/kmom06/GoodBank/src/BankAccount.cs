namespace GoodBank.src;

public class BankAccount
{
    public string AccountNumber { get; }
    public double Balance { get; protected set; }

    public BankAccount(string accountNumber, double balance)
    {
        AccountNumber = accountNumber;
        Balance = balance;
    }

    public virtual void Deposit(double amount)
    {
        Balance += amount;
    }

    public virtual void Withdraw(double amount) { }

    public override string ToString()
    {
        return $"Account Number: {AccountNumber}, Balance: {Balance}";
    }
}
