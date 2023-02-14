using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    // To use this class we need to register it in Program.cs
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        // AppUser is how we refer to user in our code but database would create a table called Users same as DbSet name.
        public DbSet<AppUser> Users { get; set; } 
        
    }
}