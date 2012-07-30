using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using DataAccess;

namespace CsvExporter {
	class Program {
		static void Main(string[] args) {
			try {
				new Exporter(new TransactionRepository()).Run();
				Console.WriteLine("Done");
			}
			catch (Exception ex) {
				Console.WriteLine("Unexpected error. {0}", ex.ToString());
				Environment.Exit(1); // 1 means error.
			}
		}
	}
}
