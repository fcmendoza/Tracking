using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tracking.DataAccess.Base.Models;
using Tracking.DataAccess.Base.Repositories;
using Tracking.DataAccess.SqlServer;

namespace Tracking.DataAccess.SqlServer.Tests {
    [TestClass]
    public class RepositoryTest {
        [TestMethod]
        public void Should_Retrieve_Transactions() {
            string connectionString = "Data Source=.;Initial Catalog=Trackin;Integrated Security=True";
            ITransactionRepository repo = new TransactionRepository(connectionString: connectionString);
            IEnumerable<Transaction> transactions = repo.GetTransactions();

            Assert.IsNotNull(transactions);
            Assert.IsTrue(transactions.Any());
        }
    }
}
