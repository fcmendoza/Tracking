using System;
using System.Collections.Generic;
using Tracking.DataAccess.Base.Models;

namespace Tracking.DataAccess.Base.Repositories {
    public interface ITransactionRepository {
        IEnumerable<Transaction> GetTransactions(DateTime from, DateTime to);
        IEnumerable<Transaction> GetTransactions();
        void SaveTransactions(IEnumerable<Transaction> transactions);
    }
}
