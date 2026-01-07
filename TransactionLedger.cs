using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalPrettyCashLedgerSystem
{
    public class TransactionLedger
    {
        /// <summary>
        /// Ledger Class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Ledger<T> where T : Transaction
        {
            private List<T> transactions = new List<T>();

            /// <summary>
            /// Method to Add new transaction
            /// </summary>
            /// <param name="entry"></param>
            public void AddEntry(T entry)
            {
                transactions.Add(entry);
            }

            /// <summary>
            /// Method to Get Transactions By Date
            /// </summary>
            /// <param name="date"></param>
            /// <returns></returns>

            public List<T> GetTransactionsByDate(DateTime date)
            {
                return transactions
                    .Where(t => t.Date.Date == date.Date)
                    .ToList();
            }

            /// <summary>
            /// Method to Calculate Total
            /// </summary>
            /// <returns></returns>
            public decimal CalculateTotal()
            {
                return LedgerUtility.CalculateTotal(this);
            }

            /// <summary>
            /// Method to Get All Transactions
            /// </summary>
            /// <returns></returns>
            public List<T> GetAllTransactions()
            {
                return transactions;
            }
        }
    }
}
