﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tracking.DataAccess;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;

namespace Updater {
    public interface ITransactionRepository {
        IEnumerable<Transacction> GetTransactions(DateTime from, DateTime to, int? accountID = null);
        void SaveTransactions(IEnumerable<Transacction> transactions, bool? isUsaAccount = null);
    }

    public class TransactionRepository : ITransactionRepository {

        public IEnumerable<Transacction> GetTransactions(DateTime from, DateTime to, int? accountID = null) {
            // get settings from config file
            // make request to mtrackin's api
            // convert request to IEnumerable<Transacction> and return it.

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
                            select new Transacction {
                                ID = (long)c.Attribute("id"),
                                Description = (string)c.Element("description"),
                                Date = (DateTime)c.Element("date"),
                                Amount = (decimal)c.Element("amount"),
                                Tags = c.Descendants("tags").Select(x => x.Element("tag").Value).ToList()
                            };

                return query.ToList();
            }
        }

        public void SaveTransactions(IEnumerable<Transacction> transactions, bool? isUsaAccount = null) {
            foreach (var transaction in transactions) {
                _db.SaveTransaction(transaction.ID
                    , transaction.Description
                    , transaction.Amount
                    , transaction.Date
                    , String.Join(",", transaction.Tags)
                    , isUsaAccount == true ? "USA" : "Main")
                    .Execute();
            }
        }

        private TrackinDB _db = new TrackinDB();
    }

    public class DummyTransactionRepository  {
        public IEnumerable<Transacction> GetTransactions() {
            var transactions = new List<Transacction>();
            transactions.Add(new Transacction {
                ID = 50722540,
                Description = "Lorem ipsum",
                Date = DateTime.Now,
                Amount = 100,
                Tags = new List<string> {"food"}
            });
            transactions.Add(new Transacction {
                ID = 50722541,
                Description = "Lorem ipsum 2",
                Date = DateTime.Now,
                Amount = 1002,
                Tags = new List<string> { "transportation" }
            });
            return transactions;
        }
        public void SaveTransactions(IEnumerable<Transacction> transactions) {
            foreach (var transaction in transactions) {
                _db.SaveTransaction(transaction.ID, transaction.Description, transaction.Amount, transaction.Date, String.Join(",", transaction.Tags))
                    .Execute();
            }
        }

        private TrackinDB _db = new TrackinDB();
    }

    public class Transacction {
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
