public abstract class Transaction
{
    private string _transactionId;
    private double _amount;
    private DateTime _date;
    private Category _category;

    public Transaction(string transactionId, double amount, DateTime date, Category category)
    {
        _transactionId = transactionId;
        _amount = amount;
        _date = date;
        _category = category;
    }

    public string GetTransactionId()
    {
        return _transactionId;
    }

    public double GetAmount()
    {
        return _amount;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public Category GetCategory()
    {
        return _category;
    }

    public abstract string GetDetails();
}
