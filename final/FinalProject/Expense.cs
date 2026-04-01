public class Expense : Transaction
{
    private string _vendor;

    public Expense(string transactionId, double amount, DateTime date, Category category, string vendor)
        : base(transactionId, amount, date, category)
    {
        _vendor = vendor;
    }

    public string GetVendor()
    {
        return _vendor;
    }

    public override string GetDetails()
    {
        return "Expense: -$" + GetAmount() + " at " + _vendor + " on " + GetDate().ToShortDateString() + " (" + GetCategory().GetName() + ")";
    }
}
