namespace ExpenseTracker
{
    class Transaction
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }



    class Tracker
    {
        List<Transaction> transactions;

        public Tracker()
        {
            transactions = new List<Transaction>();
        }
        public void AddTransaction()
        {
            Console.WriteLine("Enter the Title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the Description:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter the Paid Amount:");
            int amount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Date (DD/MM/YYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Transaction transaction = new Transaction() { Title=title,Description = description, Amount=amount, Date=date };  
            transactions.Add(transaction);
        }

        public void ViewExpense()
        {
            Console.WriteLine("Expense Transactions:");
            Console.WriteLine("Title \t Description \t Amount \t Date");
            foreach (Transaction t in transactions)
            {
                if (t.Amount < 0)
                {
                    Console.WriteLine($"{t.Title} \t {t.Description} \t {t.Amount} \t {t.Date.ToShortDateString()}");
                }
            }
        }

        public void ViewIncome()
        {
            Console.WriteLine("Income Transactions:");
            Console.WriteLine("Title \t Description \t Amount \t Date");
            foreach (Transaction t in transactions)
            {
                if (t.Amount > 0)
                {
                    Console.WriteLine($"{t.Title} \t {t.Description} \t{t.Amount} \t {t.Date.ToShortDateString()}");
                }
            }
        }

        public void ShowBalance()
        {
            int totalIncome = 0;
            int totalExpense = 0;

            foreach (Transaction t in transactions)
            {
                if (t.Amount > 0)
                {
                    totalIncome = t.Amount;
                }
                else
                {
                    totalExpense = Math.Abs(t.Amount);
                }
            }

            int availableBalance = totalIncome - totalExpense;
            Console.WriteLine($"Total Income: {totalIncome}");
            Console.WriteLine($"Total Expenses: {totalExpense}");
            Console.WriteLine($"Available Balance: {availableBalance}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Tracker obj = new Tracker();
            string ans = "";
            do
            {
                Console.WriteLine("Welcome to Expense Tracker App");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Choose the Operation you would like to perform:");
                Console.WriteLine("1.Add Transaction");
                Console.WriteLine("2.View Expenses");
                Console.WriteLine("3.View Income");
                Console.WriteLine("4.Check Available Balance");
                
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            obj.AddTransaction();
                            break;
                        }
                    case 2:
                        {
                            obj.ViewExpense();
                            break;
                        }
                    case 3:
                        {
                            obj.ViewIncome();
                            break;
                        }
                    case 4:
                        {
                            obj.ShowBalance();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong Choice Entered");
                            break;
                        }
                }
                Console.WriteLine("Do you wish to continue? [y/n]");
                ans = Console.ReadLine();
            } while (ans.ToLower() == "y");
        }
    }
}