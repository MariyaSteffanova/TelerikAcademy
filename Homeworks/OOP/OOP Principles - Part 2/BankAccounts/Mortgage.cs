namespace BankAccounts
{
    using System;
   public class Mortgage : Account
    {
       public Mortgage(DateTime date, CustomerType customer, decimal balance)
           : base(date, customer, balance)
       {
           this.InterestRate = this.CalculateInterestRate();
       }

        public override decimal CalculateInterestRate()
        {
            if(this.Customer.Equals(CustomerType.Company) && this.NumberOfMonths <= 12)
                return (this.NumberOfMonths * interesrRateConst)/2;
            if (this.Customer.Equals(CustomerType.Individual) && this.NumberOfMonths <= 6)
                return 0;

            return (decimal)this.NumberOfMonths * interesrRateConst;
        }
    }
}
