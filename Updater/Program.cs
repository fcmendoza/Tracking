using System;
using Tracking.DataAccess.SqlServer;
using System.Configuration;

namespace Updater {
    class Program {
        static void Main(string[] args) {
            try {
                new DasUpdater(
                    new TransactionRepository(ConfigurationManager.ConnectionStrings["dasConnection"].ToString()), 
                    new ApiClient()).Run(); // TODO: use Autofac
                Console.WriteLine("\nDone!");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            //Console.ReadLine();
        }
    }
}