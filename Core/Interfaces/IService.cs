﻿
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renting.Master.Core.Interfaces
{
    public interface IService<TId, TEntity, TEntityDto> where TId : struct where TEntity : Domain.Entities.EntityBase where TEntityDto: Core.Dtos.EntityBase
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> GetAll();
        Task<TEntity> FindByIdAsync(TId id);
        TEntity FindById(TId id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(TId entityId);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(TId entityId);
    }
}