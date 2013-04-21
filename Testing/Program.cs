using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                Insert();
                //Run();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();
        }

        private static void Insert() {
            string url = "http://www.moneytrackin.com/api/rest/insertTransaction?project=&description=lorem+ipsum&amount=-123&date=2013-04-20&tags=food";

            bool success = false;
            string errorMessage = String.Empty;

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.Headers.Add("Authorization", "Basic yourkeygoeshere");

            try {
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
                                select new  {
                                    ErrorMessage = (string)c.Value
                                };
                                
                    success = code.ToLower() == "done";
                    errorMessage = query.FirstOrDefault() != null ? query.FirstOrDefault().ErrorMessage : "Undefined error.";
                }

                //_logger.InfoFormat("Sent email for request commitment ID {0}", commitment.Id);
            }
            catch (WebException ex) {
                //_logger.Error(String.Format("Email for request commitment ID {0} could not be sent.", commitment.Id), ex);
                success = false;
            }

            Console.WriteLine("Success: {0}. Error Message: {1}", success, errorMessage);
        }

        private static void Run() {
            string url = "http://www.moneytrackin.com/api/rest/listTransactions?project=&startDate=2011-11-01&endDate=2011-11-30";

            bool success = false;

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.Headers.Add("Authorization", "Basic yourkeygoeshere");

            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    success = response.StatusCode == HttpStatusCode.OK;
                    string xmlResponse;
                    
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
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

                }
                
                //_logger.InfoFormat("Sent email for request commitment ID {0}", commitment.Id);
            }
            catch (WebException ex)
            {
                //_logger.Error(String.Format("Email for request commitment ID {0} could not be sent.", commitment.Id), ex);
                success = false;
            }
        }

        private bool SendRequest()
        {
            //string url = String.Format("{0}/{1}", ConfigurationManager.AppSettings["EmailServiceEndpoint"], commitment.Id);
            string url = "http://www.moneytrackin.com/api/rest/listTransactions?project=&startDate=2011-11-01&endDate=2011-11-30";

            bool success = false;

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";

            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    success = response.StatusCode == HttpStatusCode.OK;
                }

                //_logger.InfoFormat("Sent email for request commitment ID {0}", commitment.Id);
            }
            catch (WebException ex)
            {
                //_logger.Error(String.Format("Email for request commitment ID {0} could not be sent.", commitment.Id), ex);
                success = false;
            }

            return success;
        }
    }

    public static class DocumentExtensions
    {
        public static XmlDocument ToXmlDocument(this XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }
    }

    class Transacction  {
        public long ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public IList<string> Tags { get; set; }
    }
}
