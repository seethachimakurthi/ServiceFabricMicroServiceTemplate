using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Renting.Master.Core.Interfaces;
using Renting.Master.Domain.IRepository;

namespace Renting.Master.Core.Services
{
    public class BusQueueClientService : IBusQueueClientService
    {

        private IServiceBusRepository busClient;

        public BusQueueClientService(IServiceBusRepository busClient)
        {
            this.busClient = busClient;
        }

        public async Task SendMessage(string queue, Message msg)
        {
            await busClient.SendMessage(queue, msg);
        }

        public async Task SendObject(string queue, object payload)
        {
            var msg = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(payload));
            await busClient.SendMessage(queue, new Microsoft.Azure.ServiceBus.Message(msg));
        }
    }
}
