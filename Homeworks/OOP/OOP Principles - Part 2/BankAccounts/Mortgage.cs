namespace BankAccounts
{
    using System;
    public class Mortgage : Account, IDeposit
    {
        public Mortgage(DateTime date, CustomerType customer, decimal balance)
            : base(date, customer, balance)
        {
            this.NumberOfMonths = this.CalcMonths();
            this.InterestRate = this.CalculateInterestRate();
        }

        public override decimal CalculateInterestRate()
        {
            decimal firstYearInterestForCompanies = (12 * interesrRateConst) / 2;

            if (this.Customer.Equals(CustomerType.Company))
            {
                decimal secondYearInterestForCompanies = ((this.NumberOfMonths - 12) * interesrRateConst);
                if (this.NumberOfMonths <= 12)
                    return (this.NumberOfMonths * interesrRateConst) / 2;
                else
                    return firstYearInterestForCompanies + secondYearInterestForCompanies; // if customer is company and the acount is created before more than a year
            }
            if (this.Customer.Equals(CustomerType.Individual))
                if (this.NumberOfMonths <= 6)
                    return 0;

            return (this.NumberOfMonths - 6) * interesrRateConst;
        }

        public void DepositMoney(decimal amount)
        {
            this.Balance += amount;
        }
    }
}