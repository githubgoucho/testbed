using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace Observer.DesignPattern
{
    /// <summary>
    /// Observer Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            // FuckPoint :: Create Siemens stock and attach investors

            Siemens siemens = new Siemens("Siemens", 120.00);
            siemens.Attach(new Investor("Otte"));
            siemens.Attach(new Investor("Trump"));

            // Preisänderungen benachrichtigen die Investoren

            siemens.Price = 160.40;
            siemens.Price = 161.00;
            siemens.Price = 160.50;
            siemens.Price = 160.75;

            // Wait for user

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Subject' abstract class
    /// Important Points: 
    /// Generally, we use abstract class at the time of inheritance.
    /// A user must use the override keyword before the method is declared as abstract in the child class, the abstract class is used to inherit in the child class.
    /// An abstract class cannot be inherited by structures.
    /// It can contain constructors or destructors.
    /// It can implement functions with non-Abstract methods.
    /// It cannot support multiple inheritances.
    /// It can’t be static.
    /// </summary>

    public abstract class Stock
    {
        private string symbol;
        private double price;
        private List<IInvestor> investors = new List<IInvestor>();

        // Constructor

        public Stock(string symbol, double price)
        {
            this.symbol = symbol;
            this.price = price;
        }

        public void Attach(IInvestor investor)
        {
            investors.Add(investor);
        }

        public void Detach(IInvestor investor)
        {
            investors.Remove(investor);
        }

        public void Notify()
        {
            foreach (IInvestor investor in investors)
            {
                investor.Update(this);
            }

            Console.WriteLine("");
        }

        // Gets or sets the price

        public double Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    Notify(); //  notification to all investors
                }
            }
        }

        // Gets the symbol

        public string Symbol
        {
            get { return symbol; }
        }
    }

    /// <summary>
    /// The 'ConcreteSubject' class
    /// due to inheritance the parent do the job
    /// </summary>

    public class Siemens : Stock
    {
        // Constructor

        public Siemens(string symbol, double price)
            : base(symbol, price) 
        {
        }
    }

    /// <summary>
    /// The 'Observer' interface for Updates
    /// </summary>

    public interface IInvestor
    {
        void Update(Stock stock);
    }

    /// <summary>
    /// The 'ConcreteObserver' class
    /// is notified when Updates occure
    /// </summary>

    public class Investor : IInvestor
    {
        private string name;
        private Stock stock;

        // Constructor

        public Investor(string name)
        {
            this.name = name;
        }

        public void Update(Stock stock)
        {
            Console.WriteLine("Notified {0} of {1}'s " +
                "change to {2:C}", name, stock.Symbol, stock.Price);
        }

        // Gets or sets the stock

        public Stock Stock
        {
            get { return stock; }
            set { stock = value; }
        }
    }
}
