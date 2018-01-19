using Microsoft.Azure.ServiceBus;
using System.Threading.Tasks;

namespace Renting.Master.Core.Interfaces
{
    public interface IBusQueueClientService
    {
        Task SendMessage(string queue, Message msg);

        Task SendObject(string queue, object payload);
    }
}
