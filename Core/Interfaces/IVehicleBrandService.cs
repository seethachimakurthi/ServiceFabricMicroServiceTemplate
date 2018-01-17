using Renting.Master.Core.Dtos;
using Renting.Master.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renting.Master.Core.Interfaces
{
    public interface IVehicleBrandService 
    {

        Task<IEnumerable<VehicleBrand>> GetAllAsync();
        IEnumerable<VehicleBrand> GetAll();
        Task<VehicleBrand> FindByIdAsync(long id);
        VehicleBrand FindById(long id);

    }
}
