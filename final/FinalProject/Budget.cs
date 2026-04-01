public class Budget
{
    private Category _category;
    private double _limit;
    private double _spent;

    public Budget(Category category, double limit)
    {
        _category = category;
        _limit = limit;
        _spent = 0;
    }

    public Category GetCategory()
    {
        return _category;
    }

    public double GetLimit()
    {
        return _limit;
    }

    public double GetSpent()
    {
        return _spent;
    }

    public void AddSpending(double amount)
    {
        _spent += amount;
    }

    public bool IsOverBudget()
    {
        return _spent > _limit;
    }

    public string GetBudgetSummary()
    {
        // todo: make this show the spending vs the limit and if its over
        return $"{_category.GetName()}: (summary not yet implemented)";
    }
}
