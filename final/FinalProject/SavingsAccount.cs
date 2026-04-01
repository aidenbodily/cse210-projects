public class SavingsAccount : Account
{
    private double _interestRate;

    public SavingsAccount(string accountId, string accountName, double balance, double interestRate)
        : base(accountId, accountName, balance)
    {
        _interestRate = interestRate;
    }

    public double GetInterestRate()
    {
        return _interestRate;
    }

    public void ApplyInterest()
    {
        // todo: add the math for applying interest to the balance
    }

    public override string GetSummary()
    {
        return "Savings - " + GetAccountName() + ": $" + GetBalance() + " (rate: " + _interestRate + ")";
    }

    public override double CalculateBalance()
    {
        // todo: figure out how to factor in interest stuff here
        return 0;
    }
}
