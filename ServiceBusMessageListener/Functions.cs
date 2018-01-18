﻿using System;
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
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([QueueTrigger("%queueName%")] string message, TextWriter log)
        {
            log.WriteLine(message);
        }

        
        public static void ProcessTopicMessage([ServiceBusTrigger("%topicName%", "%subscriptionName%")] string message,
        TextWriter logger)
        {
            logger.WriteLine("Topic message: " + message);
        }
    }
}
