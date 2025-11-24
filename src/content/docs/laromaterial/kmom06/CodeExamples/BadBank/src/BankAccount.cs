namespace BadBank.src;

public class BankAccount
{
    private string accountNumber;
    public double balance;

    public BankAccount(string accountNumber, double balance)
    {
        this.accountNumber = accountNumber;
        this.balance = balance;
    }

    public void Deposit(double amount)
    {
        balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
        }
        else
        {
            Console.WriteLine("Error: Insufficient funds.");
        }
    }

    public override string ToString()
    {
        return "Account Number: " + accountNumber + ", Balance: " + balance;
    }
}
