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
        private IConfigProvider config;
      

        public ServiceBusRepository(IConfigProvider configuration)
        {            
            config = configuration;
        }
        

        public void Dispose()
        {
            if (SbQueueClient != null && SbQueueClient.IsClosedOrClosing)
                SbQueueClient.CloseAsync();           
        }

        public async Task SendMessage(string queue, Message msg)
        {
            try
            {
                SbQueueClient = new QueueClient(config.GetVal("ServiceBus:Endpoint"), config.GetVal("Queues:" + queue));
                await SbQueueClient.SendAsync(msg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        

    }
}
