using System;
using System.Linq;
using System.Threading;
using System.Configuration;
using Tracking.DataAccess.Base.Repositories;

namespace Updater {
    class DasUpdater {
        public DasUpdater(ITransactionRepository repo, IApiClient client) {
            _repo = repo;
            _client = client;
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
            var transactions = _client.GetTransactions(from, to);
            Console.WriteLine("{0} transactions retrieved.", transactions.Count());
            Console.WriteLine("Main Account - Saving Transactions...");

            var txns = transactions.Select(t => new Tracking.DataAccess.Base.Models.Transaction { 
                ID = t.ID, Description = t.Description, Amount = t.Amount, Date = t.Date, Tags = t.Tags, AccountName = "Main"
            });
            _repo.SaveTransactions(txns);
            Console.WriteLine("Main Account - Transactions saved.");

            Console.WriteLine("USA Account - Getting transactions from {0:yyyy-MM-dd} to {1:yyyy-MM-dd}...", from, to);
            transactions = _client.GetTransactions(from, to, accountID: 129569);
            Console.WriteLine("{0} transactions retrieved.", transactions.Count());
            Console.WriteLine("USA Account - Saving Transactions...");

            txns = transactions.Select(t => new Tracking.DataAccess.Base.Models.Transaction { 
                ID = t.ID, Description = t.Description, Amount = t.Amount, Date = t.Date, Tags = t.Tags, AccountName = "USA"
            });
            _repo.SaveTransactions(txns);
            Console.WriteLine("USA Account - Transactions saved.");
        }

        ITransactionRepository _repo;
        IApiClient _client;
    }
}