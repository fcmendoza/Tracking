using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using Autofac;
using Tracking.DataAccess.SqlServer;
using Tracking.DataAccess.Base.Repositories;

namespace CsvExporter {
    class Program {
        static void Main(string[] args) {
            try {
                IContainer container = ContainerConfig.Configure();

                using (var scope = container.BeginLifetimeScope()) {
                    var exporter = scope.Resolve<IExporter>();
                    exporter.Run();
                }

                Console.WriteLine("Done!");
            }
            catch (Exception ex) {
                Console.WriteLine("Unexpected error. {0}", ex.ToString());
                Environment.Exit(1); // 1 means error.
            }
        }
    }

    class ContainerConfig {
        public static IContainer Configure() {
            var builder = new ContainerBuilder();

            builder.RegisterType<Exporter>().As<IExporter>();
            builder.RegisterType<TransactionRepository>()
                .WithParameter(parameterName: "connectionString", parameterValue: ConfigurationManager.ConnectionStrings["dasConnection"].ToString())
                .As<ITransactionRepository>();
            
            return builder.Build();
        }
    }
}
