using Renting.Master.Core.Dtos;
using Renting.Master.Core.Interfaces;
using Renting.Master.Domain.IRepository;
using Renting.Master.Domain.Helpers;

namespace Renting.Master.Core.Services
{
    public class VehicleBrandService : Service<long, Domain.Entities.VehicleBrand, VehicleBrand>, IVehicleBrandService
    {
        private readonly IVehicleBrandRepository repository;

        public VehicleBrandService(IVehicleBrandRepository repository) : base(repository, new LoggerHelper())
        {
            this.repository = repository;
        }
    }
}
