using System;

class Program
{
    static void Main(string[] args)
    {
        FinanceTracker tracker = new FinanceTracker();

        // categories
        Category groceries = new Category("Groceries");
        Category utilities = new Category("Utilities");
        Category entertainment = new Category("Entertainment");
        Category salary = new Category("Salary");

        List<Category> categories = new List<Category>();
        categories.Add(groceries);
        categories.Add(utilities);
        categories.Add(entertainment);
        categories.Add(salary);

        // make some accounts to start with
        CheckingAccount checking = new CheckingAccount("CHK001", "Main Checking", 1500, 500);
        SavingsAccount savings = new SavingsAccount("SAV001", "Emergency Fund", 5000, 0.03);
        CreditAccount credit = new CreditAccount("CRD001", "Visa Card", -320.50, 5000);

        tracker.AddAccount(checking);
        tracker.AddAccount(savings);
        tracker.AddAccount(credit);

        // budgets
        tracker.AddBudget(new Budget(groceries, 400));
        tracker.AddBudget(new Budget(utilities, 150));
        tracker.AddBudget(new Budget(entertainment, 100));

        int txnCount = 1;

        string choice = "";
        while (choice != "9")
        {
            Console.WriteLine();
            Console.WriteLine("===== Personal Finance Tracker =====");
            Console.WriteLine("1. View Accounts");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Log Transaction");
            Console.WriteLine("5. View Transactions");
            Console.WriteLine("6. Budget Summary");
            Console.WriteLine("7. Apply Interest");
            Console.WriteLine("8. Spending Summary");
            Console.WriteLine("9. Quit");
            Console.Write("Pick an option: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine();
                foreach (Account a in tracker.GetAccounts())
                {
                    Console.WriteLine(a.GetSummary());
                }
                Console.WriteLine("Total: $" + tracker.GetTotalBalance());
            }
            else if (choice == "2")
            {
                Account acct = PickAccount(tracker);
                if (acct != null)
                {
                    Console.Write("Amount to deposit: ");
                    double amount = double.Parse(Console.ReadLine());
                    acct.Deposit(amount);
                    Console.WriteLine("Deposited $" + amount + " to " + acct.GetAccountName());
                }
            }
            else if (choice == "3")
            {
                Account acct = PickAccount(tracker);
                if (acct != null)
                {
                    Console.Write("Amount to withdraw: ");
                    double amount = double.Parse(Console.ReadLine());
                    acct.Withdraw(amount);
                    Console.WriteLine("Withdrew $" + amount + " from " + acct.GetAccountName());
                }
            }
            else if (choice == "4")
            {
                Account acct = PickAccount(tracker);
                if (acct != null)
                {
                    Console.Write("(1) Income or (2) Expense? ");
                    string type = Console.ReadLine();

                    Console.Write("Amount: $");
                    double amount = double.Parse(Console.ReadLine());

                    // pick category
                    Console.WriteLine("Pick a category:");
                    for (int i = 0; i < categories.Count; i++)
                    {
                        Console.WriteLine("  " + (i + 1) + ". " + categories[i].GetName());
                    }
                    Console.Write("Choice: ");
                    int catChoice = int.Parse(Console.ReadLine());
                    Category cat = categories[catChoice - 1];

                    string id = "TXN" + txnCount;
                    txnCount++;

                    if (type == "1")
                    {
                        Console.Write("Source: ");
                        string source = Console.ReadLine();
                        Income income = new Income(id, amount, DateTime.Now, cat, source);
                        acct.AddTransaction(income);
                        acct.Deposit(amount);
                        Console.WriteLine("Income added.");
                    }
                    else
                    {
                        Console.Write("Vendor: ");
                        string vendor = Console.ReadLine();
                        Expense expense = new Expense(id, amount, DateTime.Now, cat, vendor);
                        acct.AddTransaction(expense);
                        acct.Withdraw(amount);

                        // add spending to matching budget
                        foreach (Budget b in tracker.GetBudgets())
                        {
                            if (b.GetCategory().GetName() == cat.GetName())
                            {
                                b.AddSpending(amount);
                            }
                        }
                        Console.WriteLine("Expense added.");
                    }
                }
            }
            else if (choice == "5")
            {
                Account acct = PickAccount(tracker);
                if (acct != null)
                {
                    Console.WriteLine("Transactions for " + acct.GetAccountName() + ":");
                    List<Transaction> txns = acct.GetTransactions();
                    if (txns.Count == 0)
                    {
                        Console.WriteLine("  No transactions yet.");
                    }
                    foreach (Transaction t in txns)
                    {
                        Console.WriteLine("  " + t.GetDetails());
                    }
                }
            }
            else if (choice == "6")
            {
                Console.WriteLine();
                foreach (Budget b in tracker.GetBudgets())
                {
                    Console.WriteLine(b.GetBudgetSummary());
                }
            }
            else if (choice == "7")
            {
                savings.ApplyInterest();
                Console.WriteLine("Interest applied. New balance: $" + savings.GetBalance());
            }
            else if (choice == "8")
            {
                Console.WriteLine(tracker.GenerateSpendingSummary());
            }
            else if (choice == "9")
            {
                Console.WriteLine("Bye!");
            }
            else
            {
                Console.WriteLine("Not a valid option, try again.");
            }
        }
    }

    static Account PickAccount(FinanceTracker tracker)
    {
        List<Account> accounts = tracker.GetAccounts();
        for (int i = 0; i < accounts.Count; i++)
        {
            Console.WriteLine("  " + (i + 1) + ". " + accounts[i].GetAccountName());
        }
        Console.Write("Pick account: ");
        int pick = int.Parse(Console.ReadLine());
        if (pick >= 1 && pick <= accounts.Count)
        {
            return accounts[pick - 1];
        }
        return null;
    }
}