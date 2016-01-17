using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Configuration;

namespace Updater {
    class DasUpdater {
        public DasUpdater(ITransactionRepository repo) {
            _repo = repo;
        }

        internal void Run() {
            int result = 0;
            int startyear = int.TryParse(ConfigurationManager.AppSettings["StartYear"], out result) ? result : 2007;
            int endyear = int.TryParse(ConfigurationManager.AppSettings["EndYear"], out result) ? result : 2016;

            for (int year = startyear; year <= endyear; year++) {
                var from = new DateTime(year, 01, 01);
                var to = new DateTime(year, 12, 31);
                Run(from, to);
                Thread.Sleep(2500);
            }
        }

        internal void Run(DateTime from, DateTime to) {
            Console.WriteLine("Main Account - Getting transactions from {0:yyyy-MM-dd} to {1:yyyy-MM-dd}...", from, to);
            var transactions = _repo.GetTransactions(from, to);
            Console.WriteLine("{0} transactions retrieved.", transactions.Count());
            Console.WriteLine("Main Account - Saving Transactions...");
            _repo.SaveTransactions(transactions);
            Console.WriteLine("Main Account - Transactions saved.");


            Console.WriteLine("USA Account - Getting transactions from {0:yyyy-MM-dd} to {1:yyyy-MM-dd}...", from, to);
            transactions = _repo.GetTransactions(from, to, accountID: 129569);
            Console.WriteLine("{0} transactions retrieved.", transactions.Count());
            Console.WriteLine("USA Account - Saving Transactions...");
            _repo.SaveTransactions(transactions, isUsaAccount: true);
            Console.WriteLine("USA Account - Transactions saved.");
        }

        ITransactionRepository _repo;
    }
}