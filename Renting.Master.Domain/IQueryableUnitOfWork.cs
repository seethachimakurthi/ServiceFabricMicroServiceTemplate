using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace Renting.Master.Domain
{
    public interface IQueryableUnitOfWork : IDisposable
    {
        DbSet<TEntity> GetSet<TEntity, TId>() where TId : struct where TEntity : Domain.Entities.EntityBase<TId>;
        void Commit();
        Task CommitAsync();
    }
}
