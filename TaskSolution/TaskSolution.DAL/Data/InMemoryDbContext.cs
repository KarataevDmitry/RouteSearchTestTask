using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using TaskSolution.DAL.Data.ContextConfigurations;
using TaskSolution.DAL.Models;

namespace TaskSolution.DAL.Data
{
    public class InMemoryDbContext : DbContext
    {
        public InMemoryDbContext()
        {
            Database.EnsureCreated();
            
        }
        [
            UseSorting,
            UseFiltering
        ]
        public DbSet<TravelRoute> TravelRoutes { get; set; }
        
        public InMemoryDbContext(DbContextOptions options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TravelRoute>().Property(e => e.TimeToLive)
                .HasConversion<long>();


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}