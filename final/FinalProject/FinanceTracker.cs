public class FinanceTracker
{
    private List<Account> _accounts;
    private List<Budget> _budgets;

    public FinanceTracker()
    {
        _accounts = new List<Account>();
        _budgets = new List<Budget>();
    }

    public void AddAccount(Account a)
    {
        _accounts.Add(a);
    }

    public void AddBudget(Budget b)
    {
        _budgets.Add(b);
    }

    public List<Account> GetAccounts()
    {
        return _accounts;
    }

    public List<Budget> GetBudgets()
    {
        return _budgets;
    }

    public double GetTotalBalance()
    {
        double total = 0;
        foreach (Account account in _accounts)
        {
            total += account.CalculateBalance();
        }
        return total;
    }

    public string GenerateSpendingSummary()
    {
        // todo: loop through everything and build a nice summary string
        return "Spending summary not yet implemented.";
    }
}
