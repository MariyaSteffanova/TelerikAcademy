namespace BankAccounts
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            var mortgages = new List<Mortgage>();
            mortgages.Add(new Mortgage(DateTime.Parse("16.12.2014"), Account.CustomerType.Individual, 1000));
            mortgages.Add(new Mortgage(DateTime.Parse("16.12.2013"), Account.CustomerType.Individual, 2560));
            mortgages.Add(new Mortgage(DateTime.Parse("16.02.2015"), Account.CustomerType.Company, 5147));
            mortgages.Add(new Mortgage(DateTime.Parse("16.12.2013"), Account.CustomerType.Company, 1247));

            var deposits = new List<Deposit>();
            deposits.Add(new Deposit(DateTime.Parse("16.12.2014"), Account.CustomerType.Individual, 150));
            deposits.Add(new Deposit(DateTime.Parse("16.12.2013"), Account.CustomerType.Individual, 3460));
            deposits.Add(new Deposit(DateTime.Parse("16.02.2015"), Account.CustomerType.Company, 4047));
            deposits.Add(new Deposit(DateTime.Parse("16.12.2013"), Account.CustomerType.Company, 9847));

            var loans = new List<Loan>();
            loans.Add(new Loan(DateTime.Parse("16.09.2013"), Account.CustomerType.Individual, 1800));
            loans.Add(new Loan(DateTime.Parse("16.12.2013"), Account.CustomerType.Individual, 3560));
            loans.Add(new Loan(DateTime.Parse("16.02.2014"), Account.CustomerType.Company, 1047));
            loans.Add(new Loan(DateTime.Parse("16.12.2013"), Account.CustomerType.Company, 4709));

            string outputTitle = string.Format("{0} | {1} | {2,10} | {3} | {4}",
                "ACCOUNT TYPE", "DATE OF CREATION", "CUSTOMER", "BALANCE", "INTEREST AMOUNT");
            Console.WriteLine(outputTitle + Environment.NewLine);

            PrintListOfAccounts(mortgages);
            PrintListOfAccounts(deposits);
            PrintListOfAccounts(loans);

            Console.WriteLine();

            int index = new Random().Next(0, loans.Count);
            int amount = 20;

            TestIDepost(mortgages, index, amount);
            TestIDepost(loans, index, amount);
            TestIDepost(deposits, index, amount * 5);

            deposits[index].WithdrawMoney(amount);
            Console.WriteLine("BALANCE AFTER WITHDRAW {0} $: {1} $", amount, deposits[index].Balance);

            Console.WriteLine();
        }

        private static void TestIDepost<T>(List<T> accounts, int index, int amount) where T : Account, IDeposit
        {
            Console.WriteLine(Environment.NewLine + "BALANCE OF RANDOM {0} ACOUNT: {1} $", accounts[index].GetType().Name.ToUpper(), accounts[index].Balance);
            accounts[index].DepositMoney(amount);
            Console.WriteLine("BALANCE AFTER DEPOSIT {0} $: {1} $", amount, accounts[index].Balance);
        }

        private static void PrintListOfAccounts<T>(List<T> accounts) where T : Account
        {
            foreach (var account in accounts)
            {
                account.Print();
            }
            Console.WriteLine();
        }
    }
}