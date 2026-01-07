using System.Collections.Generic;
using System.Linq;
using static DigitalPrettyCashLedgerSystem.TransactionLedger;

namespace DigitalPrettyCashLedgerSystem
{
    /// <summary>
    /// Utility static class
    /// </summary>
    public static class LedgerUtility
    {
        /// <summary>
        /// Method to Calculate Total
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ledger"></param>
        /// <returns></returns>
        public static decimal CalculateTotal<T>(Ledger<T> ledger)
            where T : Transaction
        {
            return ledger.GetAllTransactions().Sum(t => t.Amount);
        }        
    }
}
