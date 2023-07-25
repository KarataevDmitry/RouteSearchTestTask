using Microsoft.EntityFrameworkCore;

using TaskSolution.DAL.Data.ContextConfigurations;
using TaskSolution.DAL.Models;

namespace TaskSolution.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        [
            UseSorting,
            UseFiltering
        ]
        public DbSet<TravelRoute> TravelRoutes { get; set; }
        
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TravelRouteContextConfiguration());
        }
    }
}