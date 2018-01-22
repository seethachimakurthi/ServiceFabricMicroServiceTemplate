using Microsoft.Azure.ServiceBus;
using System;
using System.Threading.Tasks;

namespace Renting.Master.Domain.IRepository
{
    public interface IServiceBusRepository : IDisposable
    {
        Task SendMessage(string queue, Message msg);        
    }
}
