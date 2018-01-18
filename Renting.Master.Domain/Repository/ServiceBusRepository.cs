using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Renting.Master.Domain.IRepository;

namespace Renting.Master.Domain.Repository
{
    public class ServiceBusRepository : IServiceBusRepository
    {
        private IQueueClient SbQueueClient;
        private ITopicClient SbTopicClient;
        private IConfigProvider config;
        //private IConfigurationRoot configuration;

        public ServiceBusRepository(IConfigProvider configuration)
        {            
            config = configuration;
        }
        

        public void Dispose()
        {
            if (SbQueueClient != null && SbQueueClient.IsClosedOrClosing)
                SbQueueClient.CloseAsync();
            if (SbTopicClient != null && SbTopicClient.IsClosedOrClosing)
                SbTopicClient.CloseAsync();
        }

        public async Task SendMessage(string queue, Message msg)
        {
            try
            {
                SbQueueClient = new QueueClient(config.GetVal("ConnectionStrings:SBConnString"), config.GetVal("Queues:" + queue));
                await SbQueueClient.SendAsync(msg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        

        public async Task SendMessageToTopic(string topic, Message msg)
        {
            try
            {
                SbTopicClient = new TopicClient(config.GetVal("ConnectionStrings:SBConnString"), config.GetVal("Topics:" + topic));
                await SbTopicClient.SendAsync(msg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
