namespace GoodBank.src;

public class InterestAccount : BankAccount
{
    private double _interestRate;
    public InterestAccount(string accountNumber, double balance, double interestRate)
        : base(accountNumber, balance)
    {
        this._interestRate = interestRate;
    }

    public override void Withdraw(double amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("Error: Insufficient funds.");
        }
        else
        {
            Balance -= amount;
        }
    }

    public void AddInterest()
    {
        Deposit(Balance * _interestRate);
    }

    public override string ToString()
    {
        return base.ToString() + ", Interest Rate: " + _interestRate;
    }
}