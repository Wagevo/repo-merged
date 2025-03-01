using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Wagevo.Data
{
    public class WagevoDBContextFactory : IDesignTimeDbContextFactory<WagevoDBContext>
    {
        public WagevoDBContext CreateDbContext(string[] args)
        {
            // Load configuration
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<WagevoDBContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new WagevoDBContext(optionsBuilder.Options);
        }
    }
}