using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracking.DataAccess.Base.Models;
using Tracking.DataAccess.Base.Repositories;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace Tracking.DataAccess.SqlServer {
    public class TransactionRepository : ITransactionRepository {
        public TransactionRepository(string connectionString) {
            _connectionString = connectionString;
        }
        public IEnumerable<Transaction> GetTransactions(DateTime from, DateTime to) {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetTransactions() {
            IEnumerable<Transaction> transactions;

            using (var cn = new SqlConnection(_connectionString)) {
                cn.Open();

                using (var multi = cn.QueryMultiple("dbo.GetAllTransactions", commandType: CommandType.StoredProcedure)) {
                    var results = multi.Read<TransactionDto>();
                    transactions = results.Select(x => new Transaction {
                        ID          = x.ID,
                        Description = x.Description,
                        Amount      = x.Amount,
                        Date        = x.Date,
                        Tags        = x.Tags.Split(',').Any() ? x.Tags.Split(',') : new string[] { x.Tags },
                        AccountName = x.AccountName
                    }).OrderBy(t => t.Date).ToList();
                }

                cn.Close();
            }

            return transactions;
        }

        public void SaveTransactions(IEnumerable<Transaction> transactions) {
            throw new NotImplementedException();
        }

        private string _connectionString;
    }

    class TransactionDto {
        public long ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Tags { get; set; }
        public string AccountName { get; set; }
    }
}
