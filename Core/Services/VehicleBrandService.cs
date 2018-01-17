using System.Collections.Generic;
using System.Threading.Tasks;
using Renting.Master.Core.Dtos;
using Renting.Master.Core.Interfaces;
using System.Linq;
using Renting.Master.Domain.IRepository;
using AutoMapper;

namespace Renting.Master.Core.Services
{
    public class VehicleBrandService : Service<long, Domain.Entities.VehicleBrand, VehicleBrand>, IVehicleBrandService
    {
        private readonly IVehicleBrandRepository repository;

        public VehicleBrandService(IVehicleBrandRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
