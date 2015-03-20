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
            if (this.Customer.Equals(CustomerType.Individual))
                if (this.NumberOfMonths <= 3)
                    return 0;   // throw new ArgumentNullException("Loan accounts have no interest for the first 3 months if are held by individuals");
                else return (this.NumberOfMonths - 3) * interesrRateConst;

            if (this.Customer.Equals(CustomerType.Company))
                if (this.NumberOfMonths <= 2)
                    return 0;
            return (this.NumberOfMonths - 2) * interesrRateConst;
        }

        public void DepositMoney(decimal amount)
        {
            this.Balance += amount;
        }
    }
}