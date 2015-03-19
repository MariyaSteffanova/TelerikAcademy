namespace BankAccounts
{
    using System;
    using System.Collections.Generic;
    public class Program
    {
        static void Main(string[] args)
        {
            var mortgages = new List<Mortgage>();
            mortgages.Add(new Mortgage(DateTime.Parse("16.12.2014"), Account.CustomerType.Individual, 1500m));
            mortgages.Add(new Mortgage(DateTime.Parse("16.12.2013"), Account.CustomerType.Individual, 2560));
            mortgages.Add(new Mortgage(DateTime.Parse("16.02.2015"), Account.CustomerType.Company, 5147));
            mortgages.Add(new Mortgage(DateTime.Parse("16.12.2013"), Account.CustomerType.Company, 1247));

            string outputTitle = string.Format("{0} | {1} | {2,10} | {3} | {4}",
                "ACCOUNT TYPE", "DATE OF CREATION", "CUSTOMER", "BALANCE", "INTEREST");
            Console.WriteLine(outputTitle + Environment.NewLine);
            foreach (var mortgage in mortgages)
            {
                mortgage.Print();
            }
            Console.WriteLine();
            var deposits = new List<Deposit>();
            deposits.Add(new Deposit(DateTime.Parse("16.12.2014"), Account.CustomerType.Individual, 1500m));
            deposits.Add(new Deposit(DateTime.Parse("16.12.2013"), Account.CustomerType.Individual, 2560));
            deposits.Add(new Deposit(DateTime.Parse("16.02.2015"), Account.CustomerType.Company, 5147));
            deposits.Add(new Deposit(DateTime.Parse("16.12.2013"), Account.CustomerType.Company, 1247));
            foreach (var deposit in deposits)
            {
                deposit.Print();
            }

            Console.WriteLine();
            var loans = new List<Loan>();
            loans.Add(new Loan(DateTime.Parse("16.09.2013"), Account.CustomerType.Individual, 1500));
            loans.Add(new Loan(DateTime.Parse("16.12.2013"), Account.CustomerType.Individual, 2560));
            loans.Add(new Loan(DateTime.Parse("16.02.2014"), Account.CustomerType.Company, 5147));
            loans.Add(new Loan(DateTime.Parse("16.12.2013"), Account.CustomerType.Company, 1247));
            foreach (var loan in loans)
            {
                loan.Print();
            }
        }
    }
}
