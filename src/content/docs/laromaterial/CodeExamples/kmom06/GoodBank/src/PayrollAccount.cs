namespace GoodBank.src;

public class PayrollAccount : BankAccount
{
    private double _overdraftLimit;
    private const double OVERDRAFT_FEE = 25;

    public PayrollAccount(string accountNumber, double balance, double overdraftLimit)
        : base(accountNumber, balance)
    {
        this._overdraftLimit = overdraftLimit;
    }

    public override void Withdraw(double amount)
    {
        if (Balance - amount < -this._overdraftLimit)
        {
            Console.WriteLine("Error: Exceeds overdraft limit.");
        }
        else
        {
            Balance -= amount;
            if (Balance < 0)
            {
                Balance -= OVERDRAFT_FEE;
            }
        }
    }

    public override string ToString()
    {
        return base.ToString() + $", Overdraft Limit: {this._overdraftLimit}";
    }
}