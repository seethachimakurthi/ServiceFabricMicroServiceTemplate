using System.Collections.Generic;
using System.Threading.Tasks;
using Renting.Master.Core.Dtos;
using Renting.Master.Core.Interfaces;
using System.Linq;
using Renting.Master.Domain.IRepository;
using AutoMapper;

namespace Renting.Master.Core.Services
{
    public class VehicleBrandService : IVehicleBrandService
    {
        private readonly IVehicleBrandRepository repository;

        public VehicleBrandService(IVehicleBrandRepository repository)
        {
            this.repository = repository;
        }

        public VehicleBrand FindById(long id)
        {
            Domain.Entities.EntityBase entity = repository.FindById(id);
            return entity != null ? Mapper.Map<VehicleBrand>(entity) : null;
        }

        public async Task<VehicleBrand> FindByIdAsync(long id)
        {
            Domain.Entities.EntityBase entity = await repository.FindByIdAsync(id);
            return entity != null ? Mapper.Map<VehicleBrand>(entity) : null;
        }

        public IEnumerable<VehicleBrand> GetAll()
        {
            return from entity in repository.GetAll()
                   select Mapper.Map<VehicleBrand>(entity);
        }

        public async Task<IEnumerable<VehicleBrand>> GetAllAsync()
        {
            return from entity in await repository.GetAllAsync()
                   select Mapper.Map<VehicleBrand>(entity);
        }
    }
}
