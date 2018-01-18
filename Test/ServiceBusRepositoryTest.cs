
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Renting.Master.Domain.IRepository;
using Autofac;
using Renting.Master.Domain;
using Microsoft.Azure.ServiceBus;
using System.Text;

namespace Renting.Master.Core.Test
{
    [TestClass]
    public class ServiceBusRepositoryTest
    {

        private static IContainer Container;

        [TestInitialize]
        public void Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConfigProvider>().As<IConfigProvider>();
            builder.RegisterType<Renting.Master.Domain.Repository.ServiceBusRepository>().As<IServiceBusRepository>();
            Container = builder.Build();
        }

        [TestMethod]
        public void SendMessageToQueueTest()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var serviceBusRepository = scope.Resolve<IServiceBusRepository>();
                byte[] msg = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(new { abc = "" }));
                var message = new Message(msg);
                var result = serviceBusRepository.SendMessage("q1", message);
                result.Wait();
                Assert.IsTrue(result != null && result.IsCompleted);
            }
            
        }

        [TestMethod]
        public void SendMessageToTopicTest()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var serviceBusRepository = scope.Resolve<IServiceBusRepository>();
                byte[] msg = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(new { abc = "" }));
                var message = new Message(msg);
                var result = serviceBusRepository.SendMessageToTopic("t1", message);
                result.Wait();
                Assert.IsTrue(result != null && result.IsCompleted);
            }

        }
    }
}
