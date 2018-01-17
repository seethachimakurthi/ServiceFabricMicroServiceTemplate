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
        private IConfigurationRoot configuration;

        public ServiceBusRepository()
        {
            InitConfig();
        }

        private void InitConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();

        }

        public void Dispose()
        {
            if (SbQueueClient.IsClosedOrClosing)
                SbQueueClient.CloseAsync();
            if (SbTopicClient.IsClosedOrClosing)
                SbTopicClient.CloseAsync();
        }

        public async Task SendMessage(string queue, Message msg)
        {
            try
            {
                LoadQueueSettings(queue);
                await SbQueueClient.SendAsync(msg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void LoadQueueSettings(string queue)
        {
            SbQueueClient = new QueueClient(configuration.GetConnectionString("SBConnString"), configuration.GetConnectionString(queue));
        }

        public async Task SendMessageToTopic(string topic, Message msg)
        {
            try
            {
                LoadTopicSettings(topic);
                await SbTopicClient.SendAsync(msg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void LoadTopicSettings(string topic)
        {
            SbTopicClient = new TopicClient(configuration.GetConnectionString("SBConnString"), configuration.GetConnectionString(topic));
        }
    }
}
