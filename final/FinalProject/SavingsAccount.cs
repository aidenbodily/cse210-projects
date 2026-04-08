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
        double interest = GetBalance() * _interestRate;
        Deposit(interest);
    }

    public override string GetSummary()
    {
        return "Savings - " + GetAccountName() + ": $" + GetBalance() + " (rate: " + _interestRate + ")";
    }

    public override double CalculateBalance()
    {
        return GetBalance();
    }
}
