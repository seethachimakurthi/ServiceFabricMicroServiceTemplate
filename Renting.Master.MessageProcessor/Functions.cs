using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace Renting.Master.MessageProcessor
{
    public class Functions
    {        
        // Esta función se ejecutará al llegar un mensaje a la cola %queueName%
        public static void ProcessTopicMessage([ServiceBusTrigger("%queueName%")] string message, TextWriter logger)
        {
            logger.WriteLine("Queue message: " + message);
        }
    }
}
