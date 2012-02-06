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
            int startyear = int.TryParse(ConfigurationManager.AppSettings["StartYear"], out result) ? result : 2008;
            int endyear = int.TryParse(ConfigurationManager.AppSettings["EndYear"], out result) ? result : 2012;

            for (int year = startyear; year <= endyear; year++) {
                for (int month = 1; month <= 12; month++) {
                    var from = new DateTime(year, month, 01);
                    Run(from, from.AddMonths(1).AddDays(-1));
                    Thread.Sleep(5000);
                }
            }
        }
        internal void Run(DateTime from, DateTime to) {
            Console.WriteLine("Getting transactions from {0:yyyy-MM-dd} to {1:yyyy-MM-dd}...", from, to);
            var transactions = _repo.GetTransactions(from, to);
            Console.WriteLine("{0} transactions retrieved.", transactions.Count());
            Console.WriteLine("Saving Transactions...");
            _repo.SaveTransactions(transactions);
            Console.WriteLine("Transactions saved.");
        }
        ITransactionRepository _repo;
    }
}