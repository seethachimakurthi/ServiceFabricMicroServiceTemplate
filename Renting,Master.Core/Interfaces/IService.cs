using Renting.Master.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renting.Master.Core.Interfaces
{
    public interface IService<TId, TEntity, TEntityDto>
         where TId : struct
         where TEntityDto : EntityBase<TId>
    {
        Task<IEnumerable<TEntityDto>> GetAllAsync();
        IEnumerable<TEntityDto> GetAll();
        Task<TEntityDto> FindByIdAsync(TId id);
        TEntityDto FindById(TId id);
        Task AddAsync(TEntityDto entity);
        Task UpdateAsync(TEntityDto entity);
        Task DeleteAsync(TEntityDto entity);
        Task DeleteAsync(TId entityId);
        void Add(TEntityDto entity);
        void Update(TEntityDto entity);
        void Delete(TEntityDto entity);
        void Delete(TId entityId);
    }
}
