using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Renting.Master.MessageProcessor
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            var config = new JobHostConfiguration
            {
                NameResolver = new NameResolverSettings()
            };

            config.UseServiceBus();           

            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }

            config.LoggerFactory = new LoggerFactory().AddApplicationInsights(ConfigurationManager.AppSettings["appinsight"].ToString(), null).AddConsole();

            config.Tracing.ConsoleLevel = TraceLevel.Verbose;


            var host = new JobHost(config);
            
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();
        }
    }
}
