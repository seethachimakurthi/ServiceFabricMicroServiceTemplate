using Renting.Master.Core.Dtos;
using Renting.Master.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renting.Master.Core.Interfaces
{
    public interface IVehicleBrandService : IService<long, Domain.Entities.VehicleBrand, VehicleBrand>
    {
    }
}
