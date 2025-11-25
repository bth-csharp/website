namespace BadBank.src;

public class PayrollAccount : BankAccount
{
    private double OverdraftLimit;

    public PayrollAccount(string accountNumber, double balance, double overdraftLimit) 
        : base(accountNumber, balance)
    {
        this.OverdraftLimit = overdraftLimit;
    }

    public void DeductOverdraftFee()
    {
        if (balance < 0)
        {
            balance -= 25; // Assuming overdraft fee is 25
        }
    }

    public override string ToString()
    {
        return base.ToString() + ", Overdraft Limit: " + OverdraftLimit;
    }
}