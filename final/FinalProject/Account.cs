public abstract class Account
{
    private string _accountId;
    private string _accountName;
    private double _balance;
    private List<Transaction> _transactions;

    public Account(string accountId, string accountName, double balance)
    {
        _accountId = accountId;
        _accountName = accountName;
        _balance = balance;
        _transactions = new List<Transaction>();
    }

    public string GetAccountId()
    {
        return _accountId;
    }

    public string GetAccountName()
    {
        return _accountName;
    }

    public double GetBalance()
    {
        return _balance;
    }

    protected void SetBalance(double balance)
    {
        _balance = balance;
    }

    public List<Transaction> GetTransactions()
    {
        return _transactions;
    }

    public void Deposit(double amount)
    {
        _balance += amount;
    }

    public void Withdraw(double amount)
    {
        _balance -= amount;
    }

    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
    }

    public virtual string GetSummary()
    {
        return _accountName + " (" + _accountId + "): $" + _balance;
    }

    public virtual double CalculateBalance()
    {
        return _balance;
    }
}
