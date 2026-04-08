public class CreditAccount : Account
{
    private double _creditLimit;

    public CreditAccount(string accountId, string accountName, double balance, double creditLimit)
        : base(accountId, accountName, balance)
    {
        _creditLimit = creditLimit;
    }

    public double GetCreditLimit()
    {
        return _creditLimit;
    }

    public override string GetSummary()
    {
        return "Credit - " + GetAccountName() + ": $" + GetBalance() + " (limit: $" + _creditLimit + ")";
    }

    public override double CalculateBalance()
    {
        return _creditLimit + GetBalance();
    }
}
