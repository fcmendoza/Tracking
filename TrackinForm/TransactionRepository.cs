using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace TrackinForm {

    public interface ITransactionRepository {
        bool InsertTransaction(Transaction transaction, out string errorMessage);
        bool EditTransaction(Transaction transaction, out string errorMessage);
        IEnumerable<Transaction> GetTransactions(DateTime from, DateTime to);
        Transaction GetTransaction(Transaction transaction);
        bool DeleteTransaction(long transactionID, out string errorMessage);
        IEnumerable<Project> GetProjects();
    }

    public class TransactionRepository : ITransactionRepository {
        public bool InsertTransaction(Transaction transaction, out string errorMessage) {
            string url = String.Format("http://www.moneytrackin.com/api/rest/insertTransaction?project=&description={0}&amount={1}&date={2:yyyy-MM-dd}&tags={3}",
                transaction.Description, transaction.Amount, transaction.Date, string.Join(" ", transaction.Tags));

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.Headers.Add("Authorization", String.Format("Basic {0}", ConfigurationManager.AppSettings["ApiAuthorizationKey"]));
            
            bool success = false;
            errorMessage = null;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse) {
                string xmlResponse;

                using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                    xmlResponse = reader.ReadToEnd();
                }

                var doc = new XmlDocument();
                doc.LoadXml(xmlResponse);

                var xdoc = doc.ToXDocument();
                var code = (string)xdoc.Root.Attribute("code");

                var query = from c in xdoc.Descendants("error")
                            select new {
                                ErrorMessage = (string)c.Value
                            };

                success = code.ToLower() == "done";
                errorMessage = query.FirstOrDefault() != null ? query.FirstOrDefault().ErrorMessage : "Undefined error.";
            }

            return success;
        }

        public bool EditTransaction(Transaction transaction, out string errorMessage) {
            string url = String.Format("http://www.moneytrackin.com/api/rest/editTransaction?transactionID={4}&projectID=&description={0}&amount={1}&date={2:yyyy-MM-dd}&tags={3}",
                transaction.Description, transaction.Amount, transaction.Date, string.Join(" ", transaction.Tags), transaction.ID);

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.Headers.Add("Authorization", String.Format("Basic {0}", ConfigurationManager.AppSettings["ApiAuthorizationKey"]));

            bool success = false;
            errorMessage = null;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse) {
                string xmlResponse;

                using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                    xmlResponse = reader.ReadToEnd();
                }

                var doc = new XmlDocument();
                doc.LoadXml(xmlResponse);

                var xdoc = doc.ToXDocument();
                var code = (string)xdoc.Root.Attribute("code");

                var query = from c in xdoc.Descendants("error")
                            select new {
                                ErrorMessage = (string)c.Value
                            };

                success = code.ToLower() == "done";
                errorMessage = query.FirstOrDefault() != null ? query.FirstOrDefault().ErrorMessage : "Undefined error.";
            }

            return success;
        }

        public IEnumerable<Transaction> GetTransactions(DateTime from, DateTime to) {
            string url = String.Format("http://www.moneytrackin.com/api/rest/listTransactions?project=&startDate={0:yyyy-MM-dd}&endDate={1:yyyy-MM-dd}",
                from, to);

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

        public Transaction GetTransaction(Transaction transaction) {
            var transactions = GetTransactions(from: transaction.Date, to: transaction.Date);
            return transactions != null 
                ? transactions.Where(t => t.ID == transaction.ID).FirstOrDefault()
                : null;
        }

        public bool DeleteTransaction(long transactionID, out string errorMessage) {
            string url = String.Format("http://www.moneytrackin.com/api/rest/deleteTransaction?transactionID={0}", transactionID);

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.Headers.Add("Authorization", String.Format("Basic {0}", ConfigurationManager.AppSettings["ApiAuthorizationKey"]));

            bool success = false;
            errorMessage = null;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse) {
                string xmlResponse;

                using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                    xmlResponse = reader.ReadToEnd();
                }

                var doc = new XmlDocument();
                doc.LoadXml(xmlResponse);

                var xdoc = doc.ToXDocument();
                var code = (string)xdoc.Root.Attribute("code");

                var query = from c in xdoc.Descendants("error")
                            select new {
                                ErrorMessage = (string)c.Value
                            };

                success = code.ToLower() == "done";
                errorMessage = query.FirstOrDefault() != null ? query.FirstOrDefault().ErrorMessage : "Undefined error.";
            }

            return success;
        }

        public IEnumerable<Project> GetProjects() {
            string url = String.Format("http://www.moneytrackin.com/api/rest/listProjects", null);

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
                            select new Project {
                                ID = (long)c.Attribute("id"),
                                Name = (string)c.Element("name"),
                                Balance = (decimal)c.Element("balance")
                            };

                return query.ToList();
            }
        }
    }

    public class Transaction {
        public long ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public IList<string> Tags { get; set; }
        public string TagsJoined { get { return String.Join(" ", Tags); } }
    }

    public class Project {
        public long ID { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }

    public static class DocumentExtensions {
        public static XmlDocument ToXmlDocument(this XDocument xDocument) {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader()) {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

        public static XDocument ToXDocument(this XmlDocument xmlDocument) {
            using (var nodeReader = new XmlNodeReader(xmlDocument)) {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }
    }
}
