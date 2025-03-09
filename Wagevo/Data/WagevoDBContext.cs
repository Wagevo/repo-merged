using Wagevo.Models;
using Microsoft.EntityFrameworkCore;

namespace Wagevo.Data
{
    public class WagevoDBContext: DbContext
    {
        public WagevoDBContext(DbContextOptions<WagevoDBContext> options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }  // Represents the Users table
        public DbSet<Company> Companies { get; set; } // Represents the Companies table
    }
}

