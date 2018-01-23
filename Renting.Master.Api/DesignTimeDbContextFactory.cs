using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Renting.Master.Domain;
using System.IO;

namespace Renting.Master.Api
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LibraryContext>
    {
        public LibraryContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var connectionString = configuration.GetConnectionString("LibraryConnection");
            builder.UseSqlServer(connectionString);
            return new LibraryContext(builder.Options, configuration.GetConnectionString("SchemaName"));
        }
    }
}
