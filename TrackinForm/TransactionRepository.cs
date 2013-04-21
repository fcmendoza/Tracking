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
        void InsertTransaction(Transaction transaction);
    }

    public class TransactionRepository : ITransactionRepository {
        public void InsertTransaction(Transaction transaction) {
            string url = String.Format("http://www.moneytrackin.com/api/rest/insertTransaction?project=&description={0}&amount={1}&date={2:yyyy-MM-dd}&tags={3}",
                transaction.Description, transaction.Amount, transaction.Date, string.Join(" ", transaction.Tags));

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.Headers.Add("Authorization", String.Format("Basic {0}", ConfigurationManager.AppSettings["ApiAuthorizationKey"]));

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

                bool success = code.ToLower() == "done";
                string errorMessage = query.FirstOrDefault() != null ? query.FirstOrDefault().ErrorMessage : "Undefined error.";
            }
        }
    }

    public class Transaction {
        public long ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public IList<string> Tags { get; set; }
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
