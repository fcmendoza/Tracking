using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Xml;
using System.Configuration;

namespace Updater {
    public class ApiClient : IApiClient {
        public IEnumerable<Transaction> GetTransactions(DateTime from, DateTime to, int? accountID = null) {
            string url = String.Format("http://www.moneytrackin.com/api/rest/listTransactions?project={2}&startDate={0:yyyy-MM-dd}&endDate={1:yyyy-MM-dd}",
                from, to, accountID);

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.Headers.Add("Authorization", String.Format("Basic {0}", ConfigurationManager.AppSettings["ApiAuthorizationKey"]));

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse) {
                string xmlResponse;

                using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                    xmlResponse = reader.ReadToEnd();
                    xmlResponse = xmlResponse.Replace("result", "transactions");
                }

                var doc = new XmlDocument();
                doc.LoadXml(xmlResponse);

                var xdoc = doc.ToXDocument();

                var query = from c in xdoc.Descendants("transaction")
                            select new Transaction {
                                ID = (long)c.Attribute("id"),
                                Description = (string)c.Element("description"),
                                Date = (DateTime)c.Element("date"),
                                Amount = (decimal)c.Element("amount"),
                                Tags = c.Descendants("tags").Select(x => x.Element("tag").Value).ToList()
                            };

                return query.ToList();
            }
        }

        public bool InsertTransaction(Transaction transaction, out string errorMessage) {
            throw new NotImplementedException();
        }

        public bool EditTransaction(Transaction transaction, out string errorMessage) {
            throw new NotImplementedException();
        }

        public Transaction GetTransaction(Transaction transaction) {
            throw new NotImplementedException();
        }

        public bool DeleteTransaction(long transactionID, out string errorMessage) {
            throw new NotImplementedException();
        }
    }

    public interface IApiClient {
        IEnumerable<Transaction> GetTransactions(DateTime from, DateTime to, int? accountID = null);
        bool InsertTransaction(Transaction transaction, out string errorMessage);
        bool EditTransaction(Transaction transaction, out string errorMessage);
        Transaction GetTransaction(Transaction transaction);
        bool DeleteTransaction(long transactionID, out string errorMessage);
        //IEnumerable<Project> GetProjects();
    }

    public class Transaction {
        public long ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public IList<string> Tags { get; set; }
    }    
}
