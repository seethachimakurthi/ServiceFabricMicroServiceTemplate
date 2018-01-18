
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Renting.Master.Domain.IRepository;
using Autofac;
using Renting.Master.Domain;
using Microsoft.Azure.ServiceBus;
using System.Text;
using System.Linq;
using Renting.Master.Core.Services;
using Renting.Master.Core.Interfaces;
using Renting.Master.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Renting.Master.Core.Test
{
    [TestClass]
    public class VehicleBrandRepositoryTest
    {

        private static IContainer Container;

        [TestInitialize]
        public void Initialize()
        {
            var builder = new ContainerBuilder();
            Mapper.Reset();
            MappingConfig.Initialize();
            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database = LibraryDatabase; Trusted_Connection = True;");
            builder.RegisterType<LibraryContext>().As<IQueryableUnitOfWork>().WithParameter("schema", "masters").WithParameter("options",optionsBuilder.Options);
            builder.RegisterType<VehicleBrandService>().As<IVehicleBrandService>();
            builder.RegisterType<VehicleBrandRepository>().As<IVehicleBrandRepository>();
            Container = builder.Build();
        }

        [TestMethod]
        public void GetAllByRepoTest()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var brandRepository = scope.Resolve<IVehicleBrandRepository>();
                var result = brandRepository.GetAll();               
                Assert.IsTrue(result != null && result.Any());
            }
            
        }

        [TestMethod]
        public void GetAllByServiceTest()
        {
            using (var scope = Container.BeginLifetimeScope())
            {               
                var brandService = scope.Resolve<IVehicleBrandService>();
                var result = brandService.GetAll();
                Assert.IsTrue(result != null && result.Any());
            }

        }

    }
}
