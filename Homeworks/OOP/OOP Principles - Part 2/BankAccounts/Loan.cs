namespace BankAccounts
{
    using System;

    public class Loan : Account, IDeposit
    {
        public Loan(DateTime date, CustomerType customer, decimal balance)
            : base(date, customer, balance)
        {
            this.NumberOfMonths = this.CalcMonths();
            this.InterestRate = this.CalculateInterestRate();
        }

        public override decimal CalculateInterestRate()
        {
            if (this.Customer.Equals(CustomerType.Individual) && this.NumberOfMonths <= 3)
                throw new ArgumentNullException("Loan accounts have no interest for the first 3 months if are held by individuals");

            if (this.Customer.Equals(CustomerType.Company) && this.NumberOfMonths <= 2)
                throw new ArgumentNullException("Loan accounts have no interest for the first 2 months if are held by a company.");

            return (decimal)this.NumberOfMonths * interesrRateConst;
        }

        public void DepositMoney(decimal amount)
        {
            this.Balance += amount;
        }
    }
}
