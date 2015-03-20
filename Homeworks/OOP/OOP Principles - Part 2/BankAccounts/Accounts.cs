namespace BankAccounts
{
    using System;

    public abstract class Account
    {
        protected decimal balace;
        protected decimal interestRate;
        protected DateTime createdOn;
        protected int numberOfMonths;
        protected const decimal interesrRateConst = 10m;
        private CustomerType customer;

        public Account(DateTime date, CustomerType customer, decimal balance)
        {
            this.CreatedOn = date;
            this.Customer = customer;
            this.Balance = balance;
            this.NumberOfMonths = this.CalcMonths();
            this.InterestRate = this.CalculateInterestRate();
        }

        public CustomerType Customer
        {
            get { return this.customer; }
            set { this.customer = value; }
        }

        public decimal Balance
        {
            get { return this.balace; }
            set { this.balace = value; }
        }

        public decimal InterestRate
        {
            get { return this.interestRate; }
            protected set { this.interestRate = value; }
        }

        public DateTime CreatedOn
        {
            get { return this.createdOn; }
            set { this.createdOn = value; }
        }

        protected int NumberOfMonths
        {
            get { return this.numberOfMonths; }
            set { this.numberOfMonths = value; }
        }

        public enum CustomerType
        {
            Individual, Company
        }

        public abstract decimal CalculateInterestRate();

        public void Print()
        {
            string output = string.Format("{0,12} | {1,-16:dd.MM.yyyy} | {2,10} | {3,7} | {4}",
                this.GetType().Name, this.CreatedOn, this.Customer, this.Balance, this.InterestRate);
            Console.WriteLine(output);
        }

        protected int CalcMonths()
        {
            if (this.CreatedOn > DateTime.Now) throw new ArgumentException("The date of creation of account cannot be in the future!");

            this.numberOfMonths =DateTime.Now.Month - this.CreatedOn.Month + 12 * (DateTime.Now.Year - this.CreatedOn.Year);
            return this.numberOfMonths;
        }
    }
}
