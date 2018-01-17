using AutoMapper;
using Renting.Master.Core.Dtos;
using Renting.Master.Core.Interfaces;
using Renting.Master.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Renting.Master.Core.Services
{
    public class Service<TId, TEntity> : IService<TId, TEntity> where TId : struct where TEntity : EntityBase
    {
        private readonly IERepository<TId,Domain.Entities.EntityBase> repository;

        public Service(IERepository<TId, Domain.Entities.EntityBase> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return from entity in await repository.GetAllAsync()
                   select Mapper.Map<TEntity>(entity);
        }
        public async Task<TEntity> FindByIdAsync(TId id)
        {
            Domain.Entities.EntityBase entity = await repository.FindByIdAsync(id);
            return entity != null ? Mapper.Map<TEntity>(entity) : null;
        }
        public async Task AddAsync(TEntity entity)
        {
            await repository.AddAsync(Mapper.Map<Domain.Entities.EntityBase>(entity));
        }
        public async Task DeleteAsync(TEntity entity)
        {
            await repository.DeleteAsync(Mapper.Map<Domain.Entities.EntityBase>(entity));
        }
        public async Task DeleteAsync(TId entityId)
        {
            Domain.Entities.EntityBase entity = repository.FindById(entityId);
            await repository.DeleteAsync(entity);
        }
        public async Task UpdateAsync(TEntity entity)
        {
            await repository.UpdateAsync(Mapper.Map<Domain.Entities.EntityBase>(entity));
        }

        public IEnumerable<TEntity> GetAll()
        {
            return from entity in repository.GetAll()
                   select Mapper.Map<TEntity>(entity);
        }
        public TEntity FindById(TId id)
        {
            Domain.Entities.EntityBase entity = repository.FindById(id);
            return entity != null ? Mapper.Map<TEntity>(entity) : null;
        }
        public void Add(TEntity entity)
        {
            repository.Add(Mapper.Map<Domain.Entities.EntityBase>(entity));
        }
        public void Update(TEntity entity)
        {
            repository.Update(Mapper.Map<Domain.Entities.EntityBase>(entity));
        }
        public void Delete(TEntity entity)
        {
            repository.DeleteAsync(Mapper.Map<Domain.Entities.EntityBase>(entity));
        }
        public void Delete(TId entityId)
        {
            Domain.Entities.EntityBase entity = repository.FindById(entityId);
            repository.Delete(entity);
        }
    }
}
