using System;
using System.Collections.Generic;
using static DigitalPrettyCashLedgerSystem.TransactionLedger;

namespace DigitalPrettyCashLedgerSystem
{
    public class Program
    {
        #region Calculate Net Balance
        /// <summary>
        /// Method to Calculate Net Balance
        /// </summary>
        /// <param name="incomeLedger"></param>
        /// <param name="expenseLedger"></param>
        /// <returns></returns>
        public static decimal CalculateNetBalance(
            Ledger<IncomeTransaction> incomeLedger,
            Ledger<ExpenseTransaction> expenseLedger)
        {
            decimal income = incomeLedger.CalculateTotal();
            decimal expense = expenseLedger.CalculateTotal();
            return income - expense;
        }
        #endregion
        #region Merger Ledgers
        /// <summary>
        /// Method to merge incomeLedger and expenseLedger
        /// </summary>
        /// <param name="incomeLedger"></param>
        /// <param name="expenseLedger"></param>
        /// <returns></returns>
        public static List<Transaction> MergeLedgers(
            Ledger<IncomeTransaction> incomeLedger,
            Ledger<ExpenseTransaction> expenseLedger)
        {
            List<Transaction> allTransactions = new List<Transaction>();
            allTransactions.AddRange(incomeLedger.GetAllTransactions());
            allTransactions.AddRange(expenseLedger.GetAllTransactions());
            return allTransactions;
        }
        #endregion
        #region Print Summaries of Transactions
        /// <summary>
        /// Method to print Summaries of all transactions
        /// </summary>
        /// <param name="transactions"></param>
        public static void PrintSummaries(List<Transaction> transactions)
        {
            for (int i = 0; i < transactions.Count; i++)
            {
                Console.WriteLine(transactions[i].GetSummary());
            }
        }
        #endregion
        static void Main(string[] args)
        {
            #region Create Income and Transaction Ledgers
            Ledger<IncomeTransaction> incomeLedger = new TransactionLedger.Ledger<IncomeTransaction>();
            Ledger<ExpenseTransaction> expenseLedger = new TransactionLedger.Ledger<ExpenseTransaction>();
            #endregion
            #region Adding Transactions
            incomeLedger.AddEntry(new IncomeTransaction
            {
                Date = DateTime.Today,
                Amount = 500,
                Source = "Main Cash"
            });

            expenseLedger.AddEntry(new ExpenseTransaction
            {
                Date = DateTime.Today,
                Amount = 20,
                Category = "Stationery"
            });

            expenseLedger.AddEntry(new ExpenseTransaction
            {
                Date = DateTime.Today,
                Amount = 15,
                Category = "Team Snacks"
            });
            #endregion
            #region Transactions Details
            Console.WriteLine($"Total Income  : ${incomeLedger.CalculateTotal()}");
            Console.WriteLine($"Total Expense : ${expenseLedger.CalculateTotal()}");

            decimal netBalance = CalculateNetBalance(
                incomeLedger,
                expenseLedger);

            Console.WriteLine($"Net Balance   : ${netBalance}");
            Console.WriteLine();

            List<Transaction> allTransactions = MergeLedgers(incomeLedger, expenseLedger);

            PrintSummaries(allTransactions);
            #endregion
        }
    }
}
