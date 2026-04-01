public class Income : Transaction
{
    private string _source;

    public Income(string transactionId, double amount, DateTime date, Category category, string source)
        : base(transactionId, amount, date, category)
    {
        _source = source;
    }

    public string GetSource()
    {
        return _source;
    }

    public override string GetDetails()
    {
        return "Income: +$" + GetAmount() + " from " + _source + " on " + GetDate().ToShortDateString() + " (" + GetCategory().GetName() + ")";
    }
}
