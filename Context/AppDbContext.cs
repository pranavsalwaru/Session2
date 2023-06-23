using Microsoft.EntityFrameworkCore;
using Session2.Models;

namespace Session2.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Additional configuration if needed
    }
}
