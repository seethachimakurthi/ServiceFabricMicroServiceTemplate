using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Renting.Master.Domain
{
    public class LibraryContext : DbContext, IQueryableUnitOfWork
    {
        private readonly string Schema;
        public LibraryContext(DbContextOptions<LibraryContext> options, string schema) : base(options)
        {
            Schema = schema;
        }
        
        public DbSet<TEntity> GetSet<TEntity, TId>() where TId : struct where TEntity : Domain.Entities.EntityBase<TId>
        {
            return Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.Entity<Domain.Entities.VehicleBrand>().ToTable("VehicleBrand"); ;
            base.OnModelCreating(modelBuilder);
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public async Task CommitAsync()
        {
            try
            {
                await SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
        }
    }
}
