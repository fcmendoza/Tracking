using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Updater {
    class Program {
        static void Main(string[] args) {
            try {
                new DasUpdater(new TransactionRepository()).Run();
                Console.WriteLine("Done");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            //Console.ReadLine();
        }
    }
}