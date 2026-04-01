public class CheckingAccount : Account
{
    private double _overdraftLimit;

    public CheckingAccount(string accountId, string accountName, double balance, double overdraftLimit)
        : base(accountId, accountName, balance)
    {
        _overdraftLimit = overdraftLimit;
    }

    public double GetOverdraftLimit()
    {
        return _overdraftLimit;
    }

    public override string GetSummary()
    {
        return "Checking - " + GetAccountName() + ": $" + GetBalance() + " (overdraft limit: $" + _overdraftLimit + ")";
    }

    public override double CalculateBalance()
    {
        // todo: need to do something with the overdraft limit here
        return 0;
    }
}
