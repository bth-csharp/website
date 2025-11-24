namespace BadBank.src;

public class InterestAccount : BankAccount
{
    private double InterestRate;
    public InterestAccount(string accountNumber, double balance, double interestRate) 
        : base(accountNumber, balance)
    {
        this.InterestRate = interestRate;
    }

    public void AddInterest()
    {
        Deposit(balance * InterestRate);
    }

    public override string ToString()
    {
        return base.ToString() + ", Interest Rate: " + InterestRate;
    }
}