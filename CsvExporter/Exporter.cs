using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using DataAccess;

namespace CsvExporter {
	class Exporter {
		public Exporter(ITransactionRepository repo) {
			_repo = repo;
		}
		internal void Run() {
			string filename = String.Format("transactions_{0:yyyy-MM-ddThh_mm_ss}Z.csv", DateTime.UtcNow); // e.g.: transactions_2012-12-31T23:59:59Z.csv
			filename = Path.Combine(ConfigurationManager.AppSettings["BaseDir"], filename);

			Console.WriteLine("Starting exporting transactions to a CSV file {0}.", filename);

			var transactions = _repo.GetTransactions();

			StringBuilder sb = new StringBuilder();
            sb.Append("\"ID\",\"Description\",\"Amount\",\"Date\",\"Tags\",\"AccountName\"");
			sb.AppendLine();
			foreach (var transaction in transactions) {
                sb.Append(String.Format("\"{0}\",\"{1}\",\"{2}\",\"{3:yyyy-MM-dd}\",\"{4}\",\"{5}\"", transaction.ID, 
					transaction.Description, 
					transaction.Amount, 
					transaction.Date, String.Join(",", transaction.Tags), transaction.AccountName));
				sb.AppendLine();
			}

			string content = sb.ToString();

			using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename, true)) {
				sw.WriteLine(content);
			}

			Console.WriteLine("Export process finished succesfully.");
		}
		ITransactionRepository _repo;
	}
}
