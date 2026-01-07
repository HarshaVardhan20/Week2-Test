using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitalPrettyCashLedgerSystem
{
    #region IReportable Interface
    /// <summary>
    /// Interface with method GetSummary
    /// </summary>
    public interface IReportable
    {
        string GetSummary();
    }
    #endregion
    #region Transaction Base Class
    /// <summary>
    /// Transaction base class (Implements IReportable)
    /// </summary>
    public abstract class Transaction : IReportable
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public abstract string GetSummary();
    }
    #endregion
    #region ExpenseTransaction Class
    /// <summary>
    /// ExpenseTransaction class (Extends Transaction)
    /// </summary>
    public class ExpenseTransaction : Transaction
    {
        public string Category { get; set; }

        public override string GetSummary()
        {
            return $"Expense: ${Amount} for {Category}";
        }
    }
    #endregion
    #region IncomeTransaction Class
    /// <summary>
    /// IncomeTransaction class (Extends Transaction)
    /// </summary>
    public class IncomeTransaction : Transaction
    {
        public string Source { get; set; }

        public override string GetSummary()
        {
            return $"Income: ${Amount} from {Source}";
        }
    }
    #endregion
}
