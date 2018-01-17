using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace Renting.Master.Domain
{
    public interface IQueryableUnitOfWork : IDisposable
    {
        DbSet<Entity> GetSet<Entity>() where Entity : Domain.Entities.EntityBase;
        void Commit();
        Task CommitAsync();
    }
}
