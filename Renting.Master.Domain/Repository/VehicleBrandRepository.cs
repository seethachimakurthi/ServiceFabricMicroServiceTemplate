using Renting.Master.Domain.Entities;
using Renting.Master.Domain.IRepository;

namespace Renting.Master.Domain.Repository
{
    public  class VehicleBrandRepository : ERepository<long, VehicleBrand>, IVehicleBrandRepository
    {
        private readonly IQueryableUnitOfWork unitOfWork;
        public VehicleBrandRepository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
